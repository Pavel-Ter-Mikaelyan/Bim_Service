using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bim_Service.Model
{
    //общий класс узла дерева
    public class TreeViewNode
    {
        public string name { get; set; } = "";
        public string systemName { get; set; } = "";
        public List<object> children { get; set; } =
            new List<object>();

        public TreeViewNode(string name,
                            string systemName)
        {
            this.name = name;
            this.systemName = systemName;
        }
        //добавить узел
        public void AddChildren(object child)
        {
            //добавить узел в коллекцию
            children.Add(child);
        }
        //добавить стандартный узел
        public TreeViewNodeStandart AddStandartChildren(Constants.TreeViewNodeType NT)
        {
            //информация по добавляемому стандартному узлу
            TreeViewNodeStandartInfo NI =
                Constants.TreeViewNodeNames[NT];
            var currNode = this as TreeViewNodeDB;
            if (currNode == null) return null;
            //создать стандартный узел
            var NS = 
                new TreeViewNodeStandart(NI.nodeName,
                                         NI.systemNodeName,
                                         currNode.id,
                                         systemName);
            //добавить стандартный узел в коллекцию
            children.Add(NS);
            return NS;
        }
    }
}
