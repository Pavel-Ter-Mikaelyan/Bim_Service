using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Bim_Service.Model.Constants;

namespace Bim_Service.Model
{
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
        [NonSerialized]
        ColumnDataType ColumnType;

        public ColumnData(ColumnDataType ColumnType,
                          string headerName,
                          string headerPropName,
                          string defVal,
                          List<rowVal> rowVals,
                          List<string> comboboxData = null)
        {
            type = (int)ColumnType;
            this.ColumnType = ColumnType;
            this.headerName = headerName;
            this.headerPropName = headerPropName;
            this.defVal = defVal;
            if (comboboxData != null) this.comboboxData = comboboxData;
            this.rowVals = rowVals;
        }
    }
    public class rowVal
    {
        public string value { get; set; } = "";
        public rowVal(string value)
        {
            this.value = value;
        }
    }
}
