using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using static Bim_Service.Model.Constants;

namespace Bim_Service.Model
{
    //абстрактный класс для унифицированного доступа к объектам БД
    //(например: DB_Client), для формирования TreeViewNode и TableData
    public abstract class DataProvider
    {
        public virtual int Id { get; set; }
        public abstract string Name { get; set; }

        [NotMapped]
        public abstract TreeViewNodeType NodeType { get; set; }
        [NotMapped]
        public virtual object Childs { get; set; } = null;
        [NotMapped]
        public virtual Type ChildType { get; set; } = null;
        [NotMapped]
        List<DataProvider> ChildProviders { get; set; }
        [NotMapped]
        bool WasGetNodes = false;
        [NotMapped]
        public DataProvider ParentNode { get; set; }

        #region Работа с деревом 
        //получить объект дерева текущего узла(nodeId-идентификатор в дереве)
        //переопределенные методы тоже должны возвращать 
        //результат выполнения метода NodeConstructor
        public virtual TreeViewNode GetNode(int nodeId)
        {
            return NodeConstructor(nodeId);
        }
        //конструктор объекта дерева, nodeId-идентификатор в дереве
        public TreeViewNode NodeConstructor(int nodeId, string newName = null)
        {
            if (newName != null) Name = newName;
            return new TreeViewNode(Name, nodeId, Id, this);
        }
        //метод для установки Childs и ChildType
        public virtual void SetNodes()
        {
            foreach (PropertyInfo pi in GetType().GetProperties())
            {
                //атрибут текущего объекта (false - без родителей)
                ChildsAttribute ChildsAttribute =
                    pi.GetCustomAttribute<ChildsAttribute>(false);
                if (ChildsAttribute != null)
                {
                    Childs = pi.GetValue(this);
                    ChildType = ChildsAttribute.ChildType;
                    break;
                }
            }
        }
        //получить подузлы
        public List<DataProvider> GetNodes()
        {
            if (WasGetNodes) return ChildProviders;
            WasGetNodes = true;
            ChildProviders = new List<DataProvider>();
            SetNodes();
            if (Childs == null) return ChildProviders;
            bool bDbSetType = false;
            if (this is StandartNode)
            {
                StandartNode sn = (StandartNode)this;
                bDbSetType = sn.DbSetType;
            }
            IEnumerator enumerator;
            if (bDbSetType)
            {
                MethodInfo mi = Childs.GetType().GetMethod("AsQueryable");
                if (mi == null) return ChildProviders;
                IQueryable collection = (IQueryable)mi.Invoke(Childs, null);
                enumerator = collection.GetEnumerator();
            }
            else
            {
                MethodInfo mi = Childs.GetType().GetMethod("GetEnumerator");
                if (mi == null) return ChildProviders;
                enumerator = (IEnumerator)mi.Invoke(Childs, null);
            }
            if (enumerator != null)
            {
                while (enumerator.MoveNext())
                {
                    DataProvider child = (DataProvider)enumerator.Current;
                    child.ParentNode = this;
                    ChildProviders.Add(child);
                }
            }
            return ChildProviders;
        }
        #endregion
        #region Работа с таблицами
        //установить данные объекта для модификации БД
        public bool SetDataForModify(ApplicationContext db,
                                     RowContainer rc,
                                     DataProvider parentNode)
        {
            int nSetVal = 0;
            rc.ValueCellContainer.ForEach(Cell =>
            {
                foreach (PropertyInfo pi in GetType().GetProperties())
                {
                    //перебор атрибутов (false - без родителей)
                    foreach (ColumnAttribute Column in
                                pi.GetCustomAttributes<ColumnAttribute>(false))
                    {
                        //поиск по имени атрибута
                        if (Column.HeaderPropName == Cell.CI.headerPropName)
                        {
                            //установить значение свойства
                            pi.SetValue(this, Cell.value);
                            nSetVal++;
                        }
                    }
                }
            });
            if (rc.ValueCellContainer.Count != nSetVal) return false;

            //установить специфические данные для строки таблицы
            bool bSet = SetSpecificDataForModify(db, parentNode);
            if (!bSet) return false;
            return true;
        }
        //установить специфические данные объекта для модификации БД
        public virtual bool SetSpecificDataForModify(ApplicationContext db,
                                                    DataProvider parentNode)
        { return true; }
        //задать значение свойств объекта для вывода информации (TableData) из БД
        public virtual void SetPropertyForGetTableData(ApplicationContext db,
                                                          DataProvider parentNode)
        { }
        //получить коллекцию ячеек для заголовка таблицы
        public List<CellContainer> GetCellContainers()
        {
            List<CellContainer> cellContainers = new List<CellContainer>();
            //словарь для выпадающего списка
            var dictCombobox = new Dictionary<string, List<string>>();
            foreach (PropertyInfo pi in GetType().GetProperties())
            {
                object oVal = pi.GetValue(this);
                //перебор атрибутов (false - без родителей)
                //заполнение колекций выпадающий списков
                foreach (ColumnComboboxDataAttribute columnCombobox in
                            pi.GetCustomAttributes<ColumnComboboxDataAttribute>(false))
                {
                    if (oVal == null) return null;
                    List<string> comboboxVals = (List<string>)oVal;
                    if (comboboxVals.Count == 0) return null;
                    string headerPropName = columnCombobox.HeaderPropName;
                    if (dictCombobox.ContainsKey(headerPropName)) continue;
                    dictCombobox.Add(headerPropName, comboboxVals);
                }
            }
            foreach (PropertyInfo pi in GetType().GetProperties())
            {
                object oVal = pi.GetValue(this);
                //перебор атрибутов (false - без родителей)
                //заполнение коллекции заголовков ячеек таблицы (HeaderCellContainer)
                foreach (ColumnAttribute Column in
                            pi.GetCustomAttributes<ColumnAttribute>(false))
                {
                    CellContainer cc = GetCellContainer(Column, oVal, dictCombobox);
                    cellContainers.Add(cc);
                }
            }
            return cellContainers.OrderBy(q => q.CI.columnIndex).ToList();
        }
        CellContainer GetCellContainer(ColumnAttribute column,
                                       object oVal,
                                       Dictionary<string, List<string>> dictCombobox)
        {
            string value = null;
            CellInfo ci = new CellInfo(column.HeaderName,
                                       column.HeaderPropName,
                                       column.ColumnType,
                                       column.Index);
            if (column.ColumnType == ControlType.TextBox)
            {
                value = oVal == null ? "" : oVal.ToString();
            }
            if (column.ColumnType == ControlType.ComboBox)
            {
                if (!dictCombobox.ContainsKey(column.HeaderPropName))
                { return null; }
                List<string> comboboxVals = dictCombobox[column.HeaderPropName];
                if (comboboxVals.Count == 0) return null;
                ci = new CellInfo(column.HeaderName,
                                  column.HeaderPropName,
                                  column.ColumnType,
                                  column.Index,
                                  comboboxVals);
                value = comboboxVals[0];
                if (oVal != null)
                {
                    string sVal = oVal.ToString();
                    if (sVal != "") value = sVal;
                }
            }
            if (column.ColumnType == ControlType.CheckBox)
            {
                value = "false";
                if (oVal != null)
                {
                    string sVal = oVal.ToString();
                    if (sVal != "") value = sVal;
                }
            }
            return new CellContainer(value, ci);
        }
        //получить таблицу для текущего выбранного узла
        public virtual TableData_Server GetTableData(ApplicationContext db,
                                                     int nodeId)
        {
            if (NodeType == TreeViewNodeType.Checking ||
                NodeType == TreeViewNodeType.Setting)
            {
                return GetTableDataForPluginParameters(nodeId);
            }
            if (ChildType == null) return null;
            object childObject = Activator.CreateInstance(ChildType);
            if (childObject == null) return null;
            DataProvider newChild = (DataProvider)childObject;
            newChild.SetPropertyForGetTableData(db, this);
            List<CellContainer> headerCellContainer = newChild.GetCellContainers();
            if (headerCellContainer == null || headerCellContainer.Count == 0) return null;

            List<RowContainer> rowContainers = new List<RowContainer>();
            foreach (DataProvider child in GetNodes())
            {
                child.SetPropertyForGetTableData(db, this);
                List<CellContainer> valueCellContainer = child.GetCellContainers();
                if (valueCellContainer == null &&
                    valueCellContainer.Count == 0)
                {
                    return null;
                }
                RowContainer rc = new RowContainer(child.Id, valueCellContainer);
                rowContainers.Add(rc);
            }
            string tableName = TreeViewNodeInfos[NodeType].TableName;
            TableData_Server tds =
                new TableData_Server(nodeId,
                                     tableName,
                                     headerCellContainer,
                                     true,
                                     rowContainers);
            return tds;
        }
        //получить таблицу, если текущий узел - это Настройки или Проверки плагина
        public TableData_Server GetTableDataForPluginParameters(int nodeId)
        {
            string tableName = TreeViewNodeInfos[NodeType].TableName;
            //получить плагин
            DB_Plugin plugin = (DB_Plugin)ParentNode;
            //получить параметры плагина
            List<AddInsParameter> parameterList =
                            GetParameterList(plugin.CheckingData,
                                             plugin.SettingData);
            if (parameterList == null || parameterList.Count == 0) return null;

            //тип контролов (1 тип - таблица, 2 тип - таблица с одним рядом)
            bool tableType = false;
            if (parameterList[0].InTable) tableType = true;

            //если тип контролов - таблица
            if (tableType)
            {
                return GetTableDataAsTableType(parameterList, nodeId, tableName);
            }
            else //если тип контролов - таблица с одним рядом
            {
                return GetTableDataAsNotTableType(parameterList, nodeId, tableName);
            }
        }
        TableData_Server GetTableDataAsTableType(
                              List<AddInsParameter> parameterList,
                              int nodeId,
                              string tableName)
        {
            parameterList = parameterList.OrderBy(q => q.RowIndex).ToList();
            int oldRowIndex = parameterList[0].RowIndex;
            List<CellContainer> cellContainers = new List<CellContainer>();
            List<RowContainer> rowContainers = new List<RowContainer>();
            for (int i = 0; i < parameterList.Count; i++)
            {
                AddInsParameter parameter = parameterList[i];
                int newRowIndex = parameter.RowIndex;
                CellContainer cc = GetCellContainer(parameterList[i],
                                                    parameter.ColumnIndex);
                if (oldRowIndex == newRowIndex)
                {
                    cellContainers.Add(cc);
                }
                if (oldRowIndex != newRowIndex || i == parameterList.Count - 1)
                {
                    RowContainer rc = new RowContainer(0, cellContainers);
                    rowContainers.Add(rc);
                    if (i != parameterList.Count - 1)
                    {
                        cellContainers = new List<CellContainer>();
                        cellContainers.Add(cc);
                    }
                }
                oldRowIndex = newRowIndex;
            }
            //проверка, что во всех строках равное число столбцов
            int cellCount = rowContainers[0].ValueCellContainer.Count();
            bool cellCountValid =
                rowContainers.Any(q => q.ValueCellContainer.Count != cellCount);
            if (cellCountValid) return null;

            return new TableData_Server(nodeId,
                                        tableName,
                                        rowContainers[0].ValueCellContainer,
                                        true,
                                        rowContainers);
        }
        TableData_Server GetTableDataAsNotTableType(
                              List<AddInsParameter> parameterList,
                              int nodeId,
                              string tableName)
        {
            List<CellContainer> cellContainers = new List<CellContainer>();
            for (int i = 0; i < parameterList.Count; i++)
            {
                CellContainer cc = GetCellContainer(parameterList[i], i);
                cellContainers.Add(cc);
            }
            RowContainer rc = new RowContainer(0, cellContainers);
            return new TableData_Server(nodeId,
                                        tableName,
                                        cellContainers,
                                        false,
                                        new List<RowContainer> { rc });
        }
        CellContainer GetCellContainer(AddInsParameter parameter, int columnIndex)
        {
            ControlType cdt = parameter.ControlType;
            List<string> comboboxData = null;
            if (cdt == ControlType.ComboBox)
            {
                comboboxData = parameter.AvailableValue.ToList();
            }
            CellInfo ci = new CellInfo(parameter.VisibleName,
                                       parameter.PropertyName,
                                       cdt,
                                       columnIndex,
                                       comboboxData);
            return new CellContainer(parameter.Value, ci);
        }
        List<AddInsParameter> GetParameterList(string checkingData,
                                               string settingData)
        {
            string currData = null;
            if (NodeType == TreeViewNodeType.Setting)
            {
                currData = settingData;
            }
            else if (NodeType == TreeViewNodeType.Checking)
            {
                currData = checkingData;
            }
            if (currData == null || currData == "") return null;
            List<AddInsParameter> parameterList = null;
            try
            {
                parameterList =
                   JsonConvert.DeserializeObject<List<AddInsParameter>>(currData);
            }
            catch { }
            return parameterList;
        }

        //модификация базы данных
        public virtual bool Modify(ApplicationContext db,
                                   TableData_Server newTD)
        {
            if (NodeType == TreeViewNodeType.Checking ||
                NodeType == TreeViewNodeType.Setting)
            {
                return ModifyForPluginParameters(db, newTD);
            }
            bool bDbSetType = false;
            if (this is StandartNode)
            {
                StandartNode sn = (StandartNode)this;
                bDbSetType = sn.DbSetType;
            }
            //если в новой таблице нет строк
            if (newTD.RowContainers.Count == 0 && !bDbSetType)
            {
                //удалить все строки
                MethodInfo mi = Childs.GetType().GetMethod("Clear");
                mi.Invoke(Childs, null);
            }
            else
            {
                foreach (RowContainer rc in newTD.RowContainers)
                {
                    DataProvider changeChild =
                                   GetNodes().FirstOrDefault(q => q.Id == RC.Id);
                    //добавление нового объекта для строки в коллекцию
                    if (changeChild == null)
                    {
                        DataProvider newChild =
                            (DataProvider)Activator.CreateInstance(ChildType);
                        newChild.SetDataForModify(db, rc, this);
                        MethodInfo MI = Childs.GetType().GetMethod("Add");
                        MI.Invoke(Childs, new object[] { newChild });
                    }
                    else//изменение строки таблицы
                    {
                        changeChild.SetDataForModify(db, rc, this);
                        db.Entry(changeChild).State = EntityState.Modified;
                    }
                }
                //удаление строк
                IEnumerable<DataProvider> delChilds =
                    GetNodes().Where(q => !newTD.RowContainers
                                                .Any(w => w.Id == q.Id));
                foreach (DataProvider delChild in delChilds)
                {
                    MethodInfo mi = Childs.GetType().GetMethod("Remove");
                    mi.Invoke(Childs, new object[] { delChild });
                }
            }
            //если после удаления шаблона остался файл с пустым шаблоном,
            //то удалить этот файл из таблицы шаблонов
            if (NodeType == TreeViewNodeType.Templates)
            {
                foreach (DB_File file in
                              db.DB_Files.Where(q => q.DB_Template == null))
                {
                    db.DB_Files.Remove(file);
                }
            }
            return true;
        }
        //модификация базы данных, если текущий узел - это Настройки или Проверки плагина
        public virtual bool ModifyForPluginParameters(ApplicationContext db,
                                                      TableData_Server newTD)
        {
            DB_Plugin plugin = (DB_Plugin)ParentNode;

            List<AddInsParameter> addInsParameters = new List<AddInsParameter>();
            List<RowContainer> rowContainers = newTD.RowContainers;
            for (int i = 0; i < rowContainers.Count; i++)
            {
                RowContainer rc = rowContainers[i];                
                foreach (CellContainer cc in rc.ValueCellContainer)
                {
                    AddInsParameter Parameter = new AddInsParameter();
                    Parameter.TableName = newTD.TableName;
                    Parameter.InTable = newTD.AddNewRow;
                    Parameter.RowIndex = i;
                    Parameter.Value = cc.value;
                    Parameter.VisibleName = cc.CI.headerName;
                    Parameter.PropertyName = cc.CI.headerPropName;
                    Parameter.ErrorMessage = "";
                    Parameter.ColumnIndex = cc.CI.columnIndex;
                    Parameter.ControlType = cc.CI.ColumnType;
                    Parameter.AvailableValue = cc.CI.comboboxData.ToArray();
                    addInsParameters.Add(Parameter);
                }
            }
            string serializeValue = JsonConvert.SerializeObject(addInsParameters);
            if (serializeValue == null || serializeValue == "") return false;

            if (NodeType == TreeViewNodeType.Checking)
            {
                plugin.CheckingData = serializeValue;
            }
            if (NodeType == TreeViewNodeType.Setting)
            {
                plugin.SettingData = serializeValue;
            }

            return true;
        }
        #endregion
    }
}
