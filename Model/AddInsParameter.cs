using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Bim_Service.Model.Constants;

namespace Bim_Service.Model
{    
    [Serializable]
    public class AddInsParameter : Attribute
    {
        public ControlType ControlType { get; set; }
        public bool InTable { get; set; }
        public string[] AvailableValue { get; set; }
        public string Value { get; set; }
        public string VisibleName { get; set; }
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }
        public int RowIndex { get; set; }
        public int ColumnIndex { get; set; }
        public string TableName { get; set; }
        public int TableId { get; set; }
    }
}
