using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Bim_Service.Model.Constants;

namespace Bim_Service.Model
{
    public class TreeViewNodeConstructor
    {
        ApplicationContext _db;
        int nodeId = 0;

        public TreeViewNodeConstructor(ApplicationContext db)
        {
            _db = db;
        }

        //рекурсивное добавление узлов дерева
        public void AddTreeViewNodes(TreeViewNode mainNode,
                                     List<DataProvider> nodes)
        {           
            foreach (DataProvider node in nodes)
            {         
                TreeViewNode childNode = node.GetNode(++nodeId);
                //добавление узла
                mainNode.Children.Add(childNode);
                //добавление подузлов
                AddTreeViewNodes(childNode, node.GetNodes());
            }
        }
        //получить все узлы дерева
        public TreeViewNode GetTreeViewNode()
        {
            //корневой узел Клиенты
            StandartNode clientsNode =
                new StandartNode(TreeViewNodeType.Clients,
                                 _db.DB_Clients,
                                 typeof(DB_Client),
                                 true);           
            TreeViewNode mainNode = clientsNode.GetNode(++nodeId);        
            //рекурсивное добавление подузлов
            AddTreeViewNodes(mainNode, clientsNode.GetNodes());

            return mainNode;
        }
    }
}
