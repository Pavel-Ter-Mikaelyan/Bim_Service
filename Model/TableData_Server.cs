using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Bim_Service.Model.Constants;

namespace Bim_Service.Model
{
    //данные таблицы (в формате, удобном на сервере)    
    public class TableData_Server
    {
        public int NodeId { get; set; }
        public string TableName { get; set; } = "";
        public List<CellContainer> HeaderCellContainer { get; set; } =
           new List<CellContainer>();
        public List<RowContainer> RowContainers { get; set; } =
            new List<RowContainer>();
        public bool AddNewRow { get; set; } = false;

        public TableData_Server(int nodeId,
                               string tableName,
                               List<CellContainer> headerCellContainer,
                               bool addNewRow,
                               List<RowContainer> rowContainers = null)
        {
            NodeId = nodeId;
            TableName = tableName;
            HeaderCellContainer = headerCellContainer;
            AddNewRow = addNewRow;
            if (rowContainers != null) RowContainers = rowContainers;
        }
        //перевод данных в формат, удобный на клиенте
        public TableData_Client TransformToClient()
        {
            List<ColumnData> cds = new List<ColumnData>();
            HeaderCellContainer =
                HeaderCellContainer.OrderBy(q => q.CI.columnIndex).ToList();
            for (int i = 0; i < HeaderCellContainer.Count; i++)
            {
                IEnumerable<CellContainer> ValueContainers =
                    RowContainers.Select(q => q.ValueCellContainer[i]);
                IEnumerable<string> values =
                    ValueContainers.Select(q => q.value);
                List<TableDataCellValue> rowVals =
                    values.Select(q => new TableDataCellValue(q)).ToList();
                CellContainer HeaderContainer = HeaderCellContainer[i];
                ColumnData cd = new ColumnData(
                        (int)HeaderContainer.CI.ColumnType,
                        HeaderContainer.CI.headerName,
                        HeaderContainer.CI.headerPropName,
                        HeaderContainer.value,
                        rowVals,
                        HeaderContainer.CI.comboboxData);
                cds.Add(cd);
            }
            List<int> rowIds = RowContainers.Select(q => q.Id).ToList();
            TableData_Client tdc =
               new TableData_Client(NodeId, TableName, AddNewRow, cds, rowIds);
            return tdc;
        }
    }
    //контейнер для строки таблицы
    public class RowContainer
    {
        public int Id { get; set; }
        public List<CellContainer> ValueCellContainer { get; set; } =
                new List<CellContainer>();

        public RowContainer(int Id, List<CellContainer> ValueCellContainer)
        {
            this.Id = Id;
            this.ValueCellContainer = ValueCellContainer;
        }
    }
    //контейнер для ячейки таблицы
    public class CellContainer
    {
        public string value { get; set; } //значение ячейки таблицы
        public CellInfo CI { get; set; }//информация по ячейке таблицы

        public CellContainer(string value, CellInfo CI)
        {
            this.value = value;
            this.CI = CI;
        }
    }
    //информация по ячейке таблицы
    public class CellInfo
    {
        //индекс столбца
        public int columnIndex { get; set; }
        //имя заголовка столбца
        public string headerName { get; set; } = "";
        //имя свойства для заголовка столбца
        public string headerPropName { get; set; } = "";
        //тип столбца
        public ControlType ColumnType { get; set; }
        //данные комбобокса
        public List<string> comboboxData { get; set; } =
            new List<string>();

        public CellInfo(string headerName,
                        string headerPropName,
                        ControlType ColumnType,
                        int columnIndex,
                        List<string> comboboxData = null)
        {
            this.headerName = headerName;
            this.headerPropName = headerPropName;
            this.ColumnType = ColumnType;
            this.columnIndex = columnIndex;
            if (comboboxData != null) this.comboboxData = comboboxData;
        }
    }
}
