using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bim_Service.Model
{
    public class ChildsAttribute : Attribute
    {
        public Type ChildType { get; set; }
        public ChildsAttribute(Type ChildType)
        {
            this.ChildType = ChildType;
        }
    }
}
