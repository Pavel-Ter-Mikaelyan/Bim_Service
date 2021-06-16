using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static Bim_Service.Model.Constants;

namespace Bim_Service.Model
{
    //абстрактный класс для возможности передачи данных из объектов БД
    //(например, DB_Client) в узлы дерева (TreeViewNode) и связанные
    //с ними таблицы данных (TableData)
    public abstract class DataProvider
    {
        public abstract int Id { get; set; }
        public abstract string Name { get; set; }
      
        [NotMapped]
        public abstract TreeViewNodeType NodeType { get; set; }

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
        //получить подузлы
        public virtual List<DataProvider> GetNodes()
        {
            return new List<DataProvider>();
        }
        //получить таблицу для текущего выбранного узла
        public virtual TableData_Client GetTableData(int nodeId,
                                              ApplicationContext db)
        {
            return GetDefaultTableData(nodeId);
        }
        //стандартная таблица данных
        public TableData_Client GetDefaultTableData(int nodeId,
                                             string defVal = "",
                                             bool bCombobox = false,
                                             List<string> comboboxData = null)
        {
            TreeViewNodeInfo NodeInfo = TreeViewNodeInfos[NodeType];
            if (!NodeInfo.hasTableData) return null;

            if (comboboxData == null) comboboxData = new List<string>();

            List<TableDataCellValue> rowVals = new List<TableDataCellValue>();
            List<int> rowIds = new List<int>();
            GetNodes().ForEach(q =>
            {
                rowVals.Add(new TableDataCellValue(q.Name));
                rowIds.Add(q.Id);
            });
            ColumnDataType DataType =
                bCombobox ? ColumnDataType.Combobox :
                            ColumnDataType.Textbox;

            ColumnData CD = new ColumnData(DataType,
                                           "Название",
                                           "name",
                                           defVal,
                                           comboboxData,
                                           rowVals);
            TableData_Client TD = new TableData_Client(nodeId,
                                         NodeInfo.TableName,
                                         new List<ColumnData> { CD },
                                         rowIds);
            return TD;
        }

        //public abstract void AddChildNode();
        //public abstract void DeleteChildNode();
        //public abstract void ChangeChildNode();
        public virtual void ChangeName(ApplicationContext db,
                                       string newName)
        {
            Name = newName;
        }
        public virtual bool Modify(ApplicationContext db,
                                   TableData_Client newTD)
        {







        }
    }
}
