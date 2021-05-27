using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bim_Service.Model
{
    //стандартный узел (не имеющий табличного представления в базе)
    public class TreeViewNodeStandart : TreeViewNode
    {
        public int parentId { get; set; }
        public string parentSystemName { get; set; }

        public TreeViewNodeStandart(string name,
                                    string systemName,
                                    int parentId,
                                    string parentSystemName) :
            base(name, systemName)
        {
            this.parentId = parentId;
            this.parentSystemName = parentSystemName;
        }
    }
}
