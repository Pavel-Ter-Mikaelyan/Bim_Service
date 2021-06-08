using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bim_Service.Model
{
    //узел дерева, соответствующий таблице в базе
    public class TreeViewNodeDB : TreeViewNode
    {
        public int id { get; set; }

        public TreeViewNodeDB(int id,
                              string name,
                              string systemName,
                              bool standartNode) :
            base(name, systemName, standartNode)
        {
            this.id = id;
        }        
    }
}
