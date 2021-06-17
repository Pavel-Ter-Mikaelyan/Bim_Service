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
    //абстрактный класс для возможности передачи данных из объектов БД
    //(например, DB_Client) в узлы дерева (TreeViewNode) и связанные
    //с ними таблицы данных (TableData)
    public abstract class DataProvider
    {
        public virtual int Id { get; set; }
        public abstract string Name { get; set; }

        [NotMapped]
        public abstract TreeViewNodeType NodeType { get; set; }
        [NotMapped]
        public virtual object Childs { get; set; }
        [NotMapped]
        public virtual Type ChildType { get; set; }

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
        public virtual void SetNodes() { }
        //получить подузлы
        public virtual IEnumerator GetNodes()
        {
            SetNodes();
            if (Childs == null) return null;
            MethodInfo MI = Childs.GetType().GetMethod("GetEnumerator");
            if (MI == null) return null;
            IEnumerator returnVal = (IEnumerator)MI.Invoke(Childs, null);
            return returnVal;
        }
        //установить данные для строки таблицы
        public void SetRowData(ApplicationContext db, RowContainer RC)
        {
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
                        }
                    }
                }
            });
        }

        public virtual void SetPropertyForGetTableRowData(ApplicationContext db,
                                                          DataProvider ParentProvider)
        { }
        //получить коллекцию ячеек для заголовка таблицы
        public List<CellContainer> GetCellContainers()
        {
            List<CellContainer> CellContainers = new List<CellContainer>();
            foreach (PropertyInfo PI in GetType().GetProperties())
            {
                object oVal = PI.GetValue(this);
                //словарь для выпадающего списка
                Dictionary<string, List<string>> DictCombobox =
                    new Dictionary<string, List<string>>();
                //перебор атрибутов (false - без родителей)
                //заполнение колекций выпадающий списков
                foreach (ColumnComboboxDataAttribute ColumnCombobox in
                            PI.GetCustomAttributes<ColumnComboboxDataAttribute>(false))
                {
                    if (oVal == null) return null;
                    List<string> ComboboxVals = (List<string>)oVal;
                    if (ComboboxVals.Count == 0) return null;
                    DictCombobox.Add(ColumnCombobox.headerPropName, ComboboxVals);
                }
                //перебор атрибутов (false - без родителей)
                //заполнение коллекции заголовков ячеек таблицы (HeaderCellContainer)
                foreach (ColumnAttribute Column in
                        PI.GetCustomAttributes<ColumnAttribute>(false))
                {
                    CellContainer CC = null;
                    CellInfo CI = null;
                    string value = null;
                    if (Column.ColumnType == ColumnDataType.Textbox)
                    {
                        CI = new CellInfo(Column.headerName,
                                          Column.headerPropName,
                                          Column.ColumnType);
                        value = oVal == null ? "" : oVal.ToString();
                    }
                    if (Column.ColumnType == ColumnDataType.Combobox)
                    {
                        if (!DictCombobox.ContainsKey(Column.headerPropName))
                        { return null; }
                        List<string> ComboboxVals = DictCombobox[Column.headerPropName];
                        if (ComboboxVals.Count == 0) return null;
                        CI = new CellInfo(Column.headerName,
                                          Column.headerPropName,
                                          Column.ColumnType,
                                          ComboboxVals);
                        value = oVal == null ? ComboboxVals[0] : oVal.ToString();
                    }
                    if (Column.ColumnType == ColumnDataType.Checkbox)
                    {
                        CI = new CellInfo(Column.headerName,
                                          Column.headerPropName,
                                          Column.ColumnType);
                        value = oVal == null ? "false" : oVal.ToString();
                    }
                    CC = new CellContainer(value, CI);
                    CellContainers.Add(CC);
                }
            }
            return CellContainers;
        }


        //модификация
        public abstract bool Modify(ApplicationContext db,
                                    TableData_Server newTD);


        //получить таблицу для текущего выбранного узла
        public virtual TableData_Server GetTableData(ApplicationContext db,
                                                     int nodeId)
        {
            //метод для установки Childs и ChildType
            SetNodes();//запускаю на всякий случай (если ранее этот метод не запускался в GetNodes)

            if (ChildType == null) return null;
            DataProvider newChild = (DataProvider)Activator
                                         .CreateInstance(ChildType.GetType());
            newChild.SetPropertyForGetTableRowData(db, this);
            List<CellContainer> HeaderCellContainer = newChild.GetCellContainers();
            if (HeaderCellContainer == null) return null;

            IEnumerator enumerator = GetNodes();
            while (enumerator.MoveNext())
            {
                DataProvider Child = (DataProvider)enumerator.Current;
                Child.SetPropertyForGetTableRowData(db, this);



            }

            return null;
        }



    }
}
