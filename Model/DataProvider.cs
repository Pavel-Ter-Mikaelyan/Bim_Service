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
        bool bWasGetNodes = false;
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
            foreach (PropertyInfo PI in GetType().GetProperties())
            {
                //атрибут текущего объекта (false - без родителей)
                ChildsAttribute ChildsAttribute =
                    PI.GetCustomAttribute<ChildsAttribute>(false);
                if (ChildsAttribute != null)
                {
                    Childs = PI.GetValue(this);
                    ChildType = ChildsAttribute.ChildType;
                    break;
                }
            }
        }
        //получить подузлы
        public List<DataProvider> GetNodes()
        {
            if (bWasGetNodes) return ChildProviders;
            bWasGetNodes = true;
            ChildProviders = new List<DataProvider>();
            SetNodes();
            if (Childs == null) return ChildProviders;
            bool bDbSetType = false;
            if (this is StandartNode)
            {
                StandartNode SN = (StandartNode)this;
                bDbSetType = SN.bDbSetType;
            }
            IEnumerator enumerator;
            if (bDbSetType)
            {
                MethodInfo MI = Childs.GetType().GetMethod("AsQueryable");
                if (MI == null) return ChildProviders;
                IQueryable Collection = (IQueryable)MI.Invoke(Childs, null);
                enumerator = Collection.GetEnumerator();
            }
            else
            {
                MethodInfo MI = Childs.GetType().GetMethod("GetEnumerator");
                if (MI == null) return ChildProviders;
                enumerator = (IEnumerator)MI.Invoke(Childs, null);
            }
            if (enumerator != null)
            {
                while (enumerator.MoveNext())
                {
                    DataProvider Child = (DataProvider)enumerator.Current;
                    Child.ParentNode = this;
                    ChildProviders.Add(Child);
                }
            }
            return ChildProviders;
        }
        #endregion
        #region Работа с таблицами
        //установить данные объекта для модификации БД
        public bool SetDataForModify(ApplicationContext db,
                                     RowContainer RC,
                                     DataProvider ParentNode)
        {
            int nSetVal = 0;
            RC.ValueCellContainer.ForEach(Cell =>
            {
                foreach (PropertyInfo PI in GetType().GetProperties())
                {
                    //перебор атрибутов (false - без родителей)
                    foreach (ColumnAttribute Column in
                                PI.GetCustomAttributes<ColumnAttribute>(false))
                    {
                        //поиск по имени атрибута
                        if (Column.headerPropName == Cell.CI.headerPropName)
                        {
                            //установить значение свойства
                            PI.SetValue(this, Cell.value);
                            nSetVal++;
                        }
                    }
                }
            });
            if (RC.ValueCellContainer.Count != nSetVal) return false;

            //установить специфические данные для строки таблицы
            bool bSet = SetSecificDataForModify(db, ParentNode);
            if (!bSet) return false;
            return true;
        }
        //установить специфические данные объекта для модификации БД
        public virtual bool SetSecificDataForModify(ApplicationContext db,
                                                    DataProvider ParentNode)
        { return true; }
        //задать значение свойств объекта для вывода информации (TableData) из БД
        public virtual void SetPropertyForGetTableData(ApplicationContext db,
                                                          DataProvider ParentNode)
        { }
        //получить коллекцию ячеек для заголовка таблицы
        public List<CellContainer> GetCellContainers()
        {
            List<CellContainer> CellContainers = new List<CellContainer>();
            //словарь для выпадающего списка
            var DictCombobox = new Dictionary<string, List<string>>();
            foreach (PropertyInfo PI in GetType().GetProperties())
            {
                object oVal = PI.GetValue(this);
                //перебор атрибутов (false - без родителей)
                //заполнение колекций выпадающий списков
                foreach (ColumnComboboxDataAttribute ColumnCombobox in
                            PI.GetCustomAttributes<ColumnComboboxDataAttribute>(false))
                {
                    if (oVal == null) return null;
                    List<string> ComboboxVals = (List<string>)oVal;
                    if (ComboboxVals.Count == 0) return null;
                    string headerPropName = ColumnCombobox.headerPropName;
                    if (DictCombobox.ContainsKey(headerPropName)) continue;
                    DictCombobox.Add(headerPropName, ComboboxVals);
                }
            }
            foreach (PropertyInfo PI in GetType().GetProperties())
            {
                object oVal = PI.GetValue(this);
                //перебор атрибутов (false - без родителей)
                //заполнение коллекции заголовков ячеек таблицы (HeaderCellContainer)
                foreach (ColumnAttribute Column in
                            PI.GetCustomAttributes<ColumnAttribute>(false))
                {
                    CellContainer CC = GetCellContainer(Column, oVal, DictCombobox);
                    CellContainers.Add(CC);
                }
            }
            return CellContainers.OrderBy(q => q.CI.columnIndex).ToList();
        }
        CellContainer GetCellContainer(ColumnAttribute Column,
                                       object oVal,
                                       Dictionary<string, List<string>> DictCombobox)
        {
            string value = null;
            CellInfo CI = new CellInfo(Column.headerName,
                                       Column.headerPropName,
                                       Column.ColumnType,
                                       Column.index);
            if (Column.ColumnType == ControlType.TextBox)
            {
                value = oVal == null ? "" : oVal.ToString();
            }
            if (Column.ColumnType == ControlType.ComboBox)
            {
                if (!DictCombobox.ContainsKey(Column.headerPropName))
                { return null; }
                List<string> ComboboxVals = DictCombobox[Column.headerPropName];
                if (ComboboxVals.Count == 0) return null;
                CI = new CellInfo(Column.headerName,
                                  Column.headerPropName,
                                  Column.ColumnType,
                                  Column.index,
                                  ComboboxVals);
                value = ComboboxVals[0];
                if (oVal != null)
                {
                    string sVal = oVal.ToString();
                    if (sVal != "") value = sVal;
                }
            }
            if (Column.ColumnType == ControlType.CheckBox)
            {
                value = "false";
                if (oVal != null)
                {
                    string sVal = oVal.ToString();
                    if (sVal != "") value = sVal;
                }
            }
            return new CellContainer(value, CI);
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
            object ChildObject = Activator.CreateInstance(ChildType);
            if (ChildObject == null) return null;
            DataProvider newChild = (DataProvider)ChildObject;
            newChild.SetPropertyForGetTableData(db, this);
            List<CellContainer> HeaderCellContainer = newChild.GetCellContainers();
            if (HeaderCellContainer == null || HeaderCellContainer.Count == 0) return null;

            List<RowContainer> RowContainers = new List<RowContainer>();
            foreach (DataProvider Child in GetNodes())
            {
                Child.SetPropertyForGetTableData(db, this);
                List<CellContainer> ValueCellContainer = Child.GetCellContainers();
                if (ValueCellContainer == null &&
                    ValueCellContainer.Count == 0)
                {
                    return null;
                }
                RowContainer RC = new RowContainer(Child.Id, ValueCellContainer);
                RowContainers.Add(RC);
            }
            string TableName = TreeViewNodeInfos[NodeType].TableName;
            TableData_Server TDS =
                new TableData_Server(nodeId,
                                     TableName,
                                     HeaderCellContainer,
                                     true,
                                     RowContainers);
            return TDS;
        }
        //получить таблицу, если текущий узел - это Настройки или Проверки плагина
        public TableData_Server GetTableDataForPluginParameters(int nodeId)
        {
            string TableName = TreeViewNodeInfos[NodeType].TableName;
            //получить плагин
            DB_Plugin Plugin = (DB_Plugin)ParentNode;
            //получить параметры плагина
            List<AddInsParameter> ParameterList =
                            GetParameterList(Plugin.CheckingData,
                                             Plugin.SettingData);
            if (ParameterList == null || ParameterList.Count == 0) return null;

            //тип контролов (1 тип - таблица, 2 тип - таблица с одним рядом)
            bool tableType = false;
            if (ParameterList[0].InTable) tableType = true;

            //если тип контролов - таблица
            if (tableType)
            {
                return GetTableDataAsTableType(ParameterList, nodeId, TableName);
            }
            else //если тип контролов - таблица с одним рядом
            {
                return GetTableDataAsNotTableType(ParameterList, nodeId, TableName);
            }
        }
        TableData_Server GetTableDataAsTableType(
                              List<AddInsParameter> ParameterList,
                              int nodeId,
                              string TableName)
        {
            ParameterList = ParameterList.OrderBy(q => q.RowIndex).ToList();
            int oldRowIndex = ParameterList[0].RowIndex;
            List<CellContainer> CellContainers = new List<CellContainer>();
            List<RowContainer> RowContainers = new List<RowContainer>();
            for (int i = 0; i < ParameterList.Count; i++)
            {
                AddInsParameter Parameter = ParameterList[i];
                int newRowIndex = Parameter.RowIndex;
                CellContainer CC = GetCellContainer(ParameterList[i],
                                                    Parameter.ColumnIndex);
                if (oldRowIndex == newRowIndex)
                {
                    CellContainers.Add(CC);
                }
                if (oldRowIndex != newRowIndex || i == ParameterList.Count - 1)
                {
                    RowContainer RC = new RowContainer(0, CellContainers);
                    RowContainers.Add(RC);
                    if (i != ParameterList.Count - 1)
                    {
                        CellContainers = new List<CellContainer>();
                        CellContainers.Add(CC);
                    }
                }
                oldRowIndex = newRowIndex;
            }
            //проверка, что во всех строках равное число столбцов
            int CellCount = RowContainers[0].ValueCellContainer.Count();
            bool CellCountValid =
                RowContainers.Any(q => q.ValueCellContainer.Count != CellCount);
            if (CellCountValid) return null;

            return new TableData_Server(nodeId,
                                        TableName,
                                        RowContainers[0].ValueCellContainer,
                                        true,
                                        RowContainers);
        }
        TableData_Server GetTableDataAsNotTableType(
                              List<AddInsParameter> ParameterList,
                              int nodeId,
                              string TableName)
        {
            List<CellContainer> CellContainers = new List<CellContainer>();
            for (int i = 0; i < ParameterList.Count; i++)
            {
                CellContainer CC = GetCellContainer(ParameterList[i], i);
                CellContainers.Add(CC);
            }
            RowContainer RC = new RowContainer(0, CellContainers);
            return new TableData_Server(nodeId,
                                        TableName,
                                        CellContainers,
                                        false,
                                        new List<RowContainer> { RC });
        }
        CellContainer GetCellContainer(AddInsParameter Parameter, int columnIndex)
        {
            ControlType CDT = Parameter.ControlType;
            List<string> comboboxData = null;
            if (CDT == ControlType.ComboBox)
            {
                comboboxData = Parameter.AvailableValue.ToList();
            }
            CellInfo CI = new CellInfo(Parameter.VisibleName,
                                       Parameter.PropertyName,
                                       CDT,
                                       columnIndex,
                                       comboboxData);
            return new CellContainer(Parameter.Value, CI);
        }
        List<AddInsParameter> GetParameterList(string CheckingData,
                                               string SettingData)
        {
            string CurrData = null;
            if (NodeType == TreeViewNodeType.Setting)
            {
                CurrData = SettingData;
            }
            else if (NodeType == TreeViewNodeType.Checking)
            {
                CurrData = CheckingData;
            }
            if (CurrData == null || CurrData == "") return null;
            List<AddInsParameter> ParameterList = null;
            try
            {
                ParameterList =
                   JsonConvert.DeserializeObject<List<AddInsParameter>>(CurrData);
            }
            catch { }
            return ParameterList;
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
                StandartNode SN = (StandartNode)this;
                bDbSetType = SN.bDbSetType;
            }
            //если в новой таблице нет строк
            if (newTD.RowContainers.Count == 0 && !bDbSetType)
            {
                //удалить все строки
                MethodInfo MI = Childs.GetType().GetMethod("Clear");
                MI.Invoke(Childs, null);
            }
            else
            {
                foreach (RowContainer RC in newTD.RowContainers)
                {
                    DataProvider changeChild =
                                   GetNodes().FirstOrDefault(q => q.Id == RC.Id);
                    //добавление нового объекта для строки в коллекцию
                    if (changeChild == null)
                    {
                        DataProvider newChild =
                            (DataProvider)Activator.CreateInstance(ChildType);
                        newChild.SetDataForModify(db, RC, this);
                        MethodInfo MI = Childs.GetType().GetMethod("Add");
                        MI.Invoke(Childs, new object[] { newChild });
                    }
                    else//изменение строки таблицы
                    {
                        changeChild.SetDataForModify(db, RC, this);
                        db.Entry(changeChild).State = EntityState.Modified;
                    }
                }
                //удаление строк
                IEnumerable<DataProvider> delChilds =
                    GetNodes().Where(q => !newTD.RowContainers
                                                .Any(w => w.Id == q.Id));
                foreach (DataProvider delChild in delChilds)
                {
                    MethodInfo MI = Childs.GetType().GetMethod("Remove");
                    MI.Invoke(Childs, new object[] { delChild });
                }
            }
            return true;
        }
        //модификация базы данных, если текущий узел - это Настройки или Проверки плагина
        public virtual bool ModifyForPluginParameters(ApplicationContext db,
                                                      TableData_Server newTD)
        {            
            DB_Plugin Plugin = (DB_Plugin)ParentNode;

            List<AddInsParameter> AddInsParameters = new List<AddInsParameter>();
            List<RowContainer> RowContainers = newTD.RowContainers;
            for (int i = 0; i < RowContainers.Count; i++)
            {
                RowContainer RC = RowContainers[i];
                AddInsParameter Parameter = new AddInsParameter();
                Parameter.TableName = newTD.tableName;
                Parameter.InTable = newTD.bAddNewRow;
                Parameter.RowIndex = i;
                foreach (CellContainer CC in RC.ValueCellContainer)
                {
                    Parameter.Value = CC.value;
                    Parameter.VisibleName = CC.CI.headerName;
                    Parameter.PropertyName = CC.CI.headerPropName;
                    Parameter.ErrorMessage = "";
                    Parameter.ColumnIndex = CC.CI.columnIndex;
                    Parameter.ControlType = CC.CI.ColumnType;
                    Parameter.AvailableValue = CC.CI.comboboxData.ToArray();
                }
                AddInsParameters.Add(Parameter);
            }
            string SerializeValue = JsonConvert.SerializeObject(AddInsParameters);
            if (SerializeValue == null || SerializeValue == "") return false;

            if (NodeType == TreeViewNodeType.Checking)
            {
                Plugin.CheckingData = SerializeValue;
            }
            if (NodeType == TreeViewNodeType.Setting)
            {
                Plugin.SettingData = SerializeValue;
            }

            return true;
        }
        #endregion
    }
}
