using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Bim_Service.Model.Constants;

namespace Bim_Service.Model
{
    public class TableData
    {
        public int selectedId { get; set; }
        public string tableName { get; set; } = "";
        public List<int> rowIds { get; set; } = new List<int>();
        public List<ColumnData> columnData { get; set; } =
            new List<ColumnData>();

        public TableData(int selectedId,
                         string tableName,
                         List<ColumnData> columnData = null,
                         List<int> rowIds = null)
        {
            this.selectedId = selectedId;
            this.tableName = tableName;
            if (rowIds != null) this.rowIds = rowIds;
            if (columnData != null) this.columnData = columnData;
        }
    }
}
