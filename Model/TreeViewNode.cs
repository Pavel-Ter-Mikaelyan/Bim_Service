using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bim_Service.Model
{
    public class TreeViewNodes
    {
        public string id { get; set; } = "";
        public string name { get; set; } = "";
        public List<TreeViewNodes> children { get; set; } =
            new List<TreeViewNodes>();
    }
}
