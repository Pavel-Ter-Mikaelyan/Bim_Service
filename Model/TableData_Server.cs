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
        public int nodeId { get; set; }
        public string tableName { get; set; } = "";
        public List<CellContainer> HeaderCellContainer { get; set; } =
           new List<CellContainer>();
        public List<RowContainer> RowContainers { get; set; } =
            new List<RowContainer>();
        public bool bAddNewRow { get; set; } = false;

        public TableData_Server(int nodeId,
                               string tableName,
                               List<CellContainer> HeaderCellContainer,
                               bool bAddNewRow,
                               List<RowContainer> RowContainers = null)
        {
            this.nodeId = nodeId;
            this.tableName = tableName;
            this.HeaderCellContainer = HeaderCellContainer;
            this.bAddNewRow = bAddNewRow;
            if (RowContainers != null) this.RowContainers = RowContainers;
        }
        //перевод данных в формат, удобный на клиенте
        public TableData_Client TransformToClient()
        {
            List<ColumnData> CDs = new List<ColumnData>();
            for (int i = 0; i < HeaderCellContainer.Count; i++)
            {
                IEnumerable<CellContainer> ValueContainers =
                    RowContainers.Select(q => q.ValueCellContainer[i]);
                IEnumerable<string> values =
                    ValueContainers.Select(q => q.value);
                List<TableDataCellValue> rowVals =
                    values.Select(q => new TableDataCellValue(q)).ToList();
                CellContainer HeaderContainer = HeaderCellContainer[i];
                ColumnData CD = new ColumnData(
                        (int)HeaderContainer.CI.ColumnType,
                        HeaderContainer.CI.headerName,
                        HeaderContainer.CI.headerPropName,
                        HeaderContainer.value,
                        rowVals,
                        HeaderContainer.CI.comboboxData);
                CDs.Add(CD);
            }
            List<int> rowIds = RowContainers.Select(q => q.Id).ToList();
            TableData_Client TDC =
               new TableData_Client(nodeId, tableName, bAddNewRow, CDs, rowIds);
            return TDC;
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
        public ColumnDataType ColumnType { get; set; }
        //данные комбобокса
        public List<string> comboboxData { get; set; } =
            new List<string>();

        public CellInfo(string headerName,
                        string headerPropName,
                        ColumnDataType ColumnType,
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
