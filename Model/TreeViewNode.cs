using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Bim_Service.Model.Constants;

namespace Bim_Service.Model
{
    //общий класс узла дерева
    public class TreeViewNode
    {
        public string name { get; set; } = "";
        public string systemName { get; set; } = "";
        public bool standartNode { get; set; } = false;
        public List<object> children { get; set; } =
            new List<object>();

        public TreeViewNode(string name,
                            string systemName,
                            bool standartNode)
        {
            this.name = name;
            this.systemName = systemName;
            this.standartNode = standartNode;
        }
        //добавить узел
        public void AddChildren(object child)
        {
            //добавить узел в коллекцию
            children.Add(child);
        }        
    }
}
