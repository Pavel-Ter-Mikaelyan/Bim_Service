using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bim_Service.Model
{  
    //МОДУЛЬ В РАЗРАБОТКЕ
    public class TableData
    {
        public string tableName { get; set; } = "";       
        public List<string> rowIds { get; set; } = new List<string>();
        public List<ColumnData> columnData { get; set; } =
            new List<ColumnData>();
    }
    public class ColumnData
    {
        //тип контрола (0-textbox, 1-combobox, 2-checkbox)
        public string type { get; set; } = "";
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
    }
    public class rowVal
    {
        public string value { get; set; } = "";
    }
}
