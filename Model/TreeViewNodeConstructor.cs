using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Bim_Service.Model.Constants;

namespace Bim_Service.Model
{
    public class TreeViewNodeConstructor
    {
        ApplicationContext db { get; set; }
        int nodeId = 0;

        public TreeViewNodeConstructor(ApplicationContext db)
        {
            this.db = db;
        }

        //рекурсивное добавление узлов дерева
        public void AddTreeViewNodes(TreeViewNode MainNode,
                                     List<DataProvider> Nodes)
        {
            foreach (DataProvider Node in Nodes)
            {
                TreeViewNode ChildNode = Node.GetNode(++nodeId);
                //добавление узла
                MainNode.children.Add(ChildNode);
                //добавление подузлов
                AddTreeViewNodes(ChildNode, Node.GetNodes());
            }
        }
        //получить все узлы дерева
        public TreeViewNode GetTreeViewNode()
        {
            //корневой узел Клиенты
            StandartNode_Clients ClientsNode =
                new StandartNode_Clients(db.DB_Clients);
            TreeViewNode RootNode = ClientsNode.GetNode(++nodeId);

            //рекурсивное добавление подузлов
            AddTreeViewNodes(RootNode, ClientsNode.GetNodes());

            return RootNode;
        }
    }
}
