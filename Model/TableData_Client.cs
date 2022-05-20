using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Bim_Service.Model.Constants;

namespace Bim_Service.Model
{
    //данные таблицы (в формате, удобном в веб клиенте)
    public class TableData_Client
    {
        public int SelectedId { get; set; }
        public string TableName { get; set; } = "";
        public List<int> RowIds { get; set; } = new List<int>();
        public List<ColumnData> ColumnData { get; set; } = new List<ColumnData>();
        public bool AddNewRow { get; set; } = false;

        public TableData_Client(int selectedId,
                                string tableName,
                                bool addNewRow,
                                List<ColumnData> columnData = null,
                                List<int> rowIds = null)
        {
            SelectedId = selectedId;
            TableName = tableName;
            AddNewRow = addNewRow;
            if (rowIds != null) RowIds = rowIds;
            if (columnData != null) ColumnData = columnData;
        }
        //перевод данных в формат, удобный на сервере
        public TableData_Server TransformToServer()
        {
            List<CellContainer> headerCellContainer =
                new List<CellContainer>();
            for (int i = 0; i < ColumnData.Count; i++)
            {
                ColumnData cd = ColumnData[i];
                CellInfo ci = new CellInfo(cd.headerName,
                                           cd.headerPropName,
                                           (ControlType)cd.type,
                                           i,
                                           cd.comboboxData);
                CellContainer cc =
                     new CellContainer(cd.defVal, ci);
                headerCellContainer.Add(cc);
            }             
            List<RowContainer> rowContainers = new List<RowContainer>();    
            for (int x = 0; x < RowIds.Count; x++)
            {
                List<CellContainer> valueCellContainer =
                    new List<CellContainer>();
                for (int y = 0; y < ColumnData.Count; y++)
                {
                    CellInfo ci = headerCellContainer[y].CI;
                    string value = ColumnData[y].rowVals[x].value;
                    CellContainer cc = new CellContainer(value, ci);
                    valueCellContainer.Add(cc);
                }
                RowContainer rc = new(RowIds[x], valueCellContainer);
                rowContainers.Add(rc);
            }
            TableData_Server tds =
                new TableData_Server(SelectedId,
                                     TableName,
                                     headerCellContainer,
                                     AddNewRow,
                                     rowContainers);

            return tds;
        }
    }
    //данные столбца
    public class ColumnData
    {
        //тип контрола (0-textbox, 1-combobox, 2-checkbox)
        public int type { get; set; }
        //имя заголовка столбца
        public string headerName { get; set; } = "";
        //системное имя для заголовка столбца
        public string headerPropName { get; set; } = "";
        //данные комбобокса
        public List<string> comboboxData { get; set; } =
            new List<string>();
        //значение по умолчанию
        public string defVal { get; set; } = "";
        //значения ячеек в одном столбце
        public List<TableDataCellValue> rowVals { get; set; } =
            new List<TableDataCellValue>();

        public ColumnData(int type,
                          string headerName,
                          string headerPropName,
                          string defVal = null,
                          List<TableDataCellValue> rowVals = null,
                          List<string> comboboxData = null)
        {
            this.type = type;
            this.headerName = headerName;
            this.headerPropName = headerPropName;
            if (defVal != null) this.defVal = defVal;
            if (rowVals != null) this.rowVals = rowVals;
            if (comboboxData != null) this.comboboxData = comboboxData;
        }
    }
}
