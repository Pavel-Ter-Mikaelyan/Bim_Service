using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Bim_Service.Model.Constants;

namespace Bim_Service.Model
{
    //узел дерева, соответствующий таблице в базе
    public class TreeViewNodeDB : TreeViewNode
    {
        public int id { get; set; }//id в базе данных

        public TreeViewNodeDB(int id,
                              string name,
                              string systemName,
                              bool standartNode) :
            base(name, systemName, standartNode)
        {
            this.id = id;
        }
        //добавить стандартный узел
        public TreeViewNodeStandart AddStandartChildren(
                                            TreeViewNodeType NT)
        {
            //информация по добавляемому стандартному узлу
            TreeViewNodeInfo NI = TreeViewNodeInfos[NT];        
            //создать стандартный узел
            var NS =
                new TreeViewNodeStandart(NI.nodeName,
                                         NI.systemNodeName,
                                         id,
                                         systemName,
                                         true);
            //добавить стандартный узел в коллекцию
            children.Add(NS);
            return NS;
        }
    }
}
