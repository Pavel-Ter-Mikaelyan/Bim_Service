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
        public int selectedId { get; set; }
        public string tableName { get; set; } = "";
        public List<int> rowIds { get; set; } = new List<int>();
        public List<ColumnData> columnData { get; set; } =
            new List<ColumnData>();

        public TableData_Client(int selectedId,
                               string tableName,
                               List<ColumnData> columnData,
                               List<int> rowIds)
        {
            this.selectedId = selectedId;
            this.tableName = tableName;
            this.rowIds = rowIds;
            this.columnData = columnData;
        }
    }
    //данные столбца
    public class ColumnData
    {
        //тип контрола (0-textbox, 1-combobox, 2-checkbox)
        public int type { get; set; }
        //имя заголовка столбца
        public string headerName { get; set; } = "";
        //имя свойства для заголовка столбца
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
