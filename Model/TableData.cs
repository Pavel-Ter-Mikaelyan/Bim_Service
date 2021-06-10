using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bim_Service.Model
{      
    public class TableData
    {
        public string selectNodeInfo { get; set; } = "";
        public string tableName { get; set; } = "";       
        public List<int> rowIds { get; set; } = new List<int>();
        public List<ColumnData> columnData { get; set; } =
            new List<ColumnData>();
    }
    public class ColumnData
    {
        //тип контрола (0-textbox, 1-combobox, 2-checkbox)
        public int type { get; set; }
        //имя заголовка столбца
        public string headerName { get; set; } = "";
        //имя свойства для заголовка столбца
        public string headerPropName { get; set; } = "";
        //значение по умолчанию
        public string defVal { get; set; } = "";
        //данные комбобокса
        public List<string> comboboxData { get; set; } =
            new List<string>();
        //значения ячеек в одном столбце
        public List<rowVal> rowVals { get; set; } = 
            new List<rowVal>();
        public static ColumnData GetDefault()
        {
            ColumnData CD = new ColumnData();
            CD.type = 0;
            CD.headerName = "Название";
            CD.headerPropName = "name";
            CD.defVal = "";
            return CD;
        }
    }
    public class rowVal
    {
        public string value { get; set; } = "";
    }
}
