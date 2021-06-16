using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Bim_Service.Model.Constants;

namespace Bim_Service.Model
{
    public class ColumnAttribute : Attribute
    {
        //имя заголовка столбца
        public string headerName;
        //имя свойства для заголовка столбца
        public string headerPropName;
        //тип столбца
        public ColumnDataType ColumnType { get; set; }
        public int index = 0;
        public ColumnAttribute(string headerName,
                               string headerPropName,
                               ColumnDataType ColumnType,
                               int index)
        {
            this.headerName = headerName;
            this.headerPropName = headerPropName;
            this.ColumnType = ColumnType;
            this.index = index;
        }
    }
}
