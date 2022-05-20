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
        public string HeaderName { get; set; }
        //системное имя для заголовка столбца
        public string HeaderPropName { get; set; }
        //тип столбца
        public ControlType ColumnType { get; set; }
        public int Index { get; set; } = 0;
        public ColumnAttribute(string headerName,
                               string headerPropName,
                               ControlType columnType,
                               int index)
        {
            HeaderName = headerName;
            HeaderPropName = headerPropName;
            ColumnType = columnType;
            Index = index;
        }
    }
    public class ColumnComboboxDataAttribute : Attribute
    {
        //системное имя для заголовка столбца
        public string HeaderPropName { get; set; }
        public ColumnComboboxDataAttribute(string headerPropName)
        {
            HeaderPropName = headerPropName;           
        }
    }
}
