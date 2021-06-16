using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bim_Service.Model
{
    //значение ячейки таблицы
    public class TableDataCellValue
    {
        public string value { get; set; } = "";
        public TableDataCellValue(string value)
        {
            if (value != null) this.value = value;
        }
    }
}
