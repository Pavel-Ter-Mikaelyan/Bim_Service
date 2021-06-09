using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Bim_Service.Model.Constants;

namespace Bim_Service.Model
{
    public class TreeNodeConstructor
    {
        public ApplicationContext db { get; set; }
        public TreeNodeConstructor(ApplicationContext db)
        {
            this.db = db;
        }
        //рекурсивное добавление узлов дерева
        public void AddTreeViewNodes(TreeViewNode MainNode,
                                     List<ITreeView> Nodes)
        {
            foreach (ITreeView Node in Nodes)
            {
                TreeViewNodeDB ChildNode = Node.GetNode();
                //добавление узла
                MainNode.AddChildren(ChildNode);
                //для узла 'Стадия'
                if (Node is DB_Stage)
                {
                    DB_Stage Stage = (DB_Stage)Node;
                    //добавление стандартных узлов
                    var TemplatesNode = //"Шаблоны"
                        ChildNode.AddStandartChildren(TreeViewNodeType.Templates);
                    var FilesNode =//"Файлы"
                        ChildNode.AddStandartChildren(TreeViewNodeType.Files);
                    //добавление подузлов в узел "Шаблоны"
                    AddTreeViewNodes(TemplatesNode, Stage.GetTemplatesTreeViewNodes());
                    //добавление подузловв узел "Файлы"
                    AddTreeViewNodes(FilesNode, Stage.GetFilesTreeViewNodes());
                }
                //для узла 'Плагин'
                else if (Node is DB_Plugin)
                {
                    //добавление стандартных узлов
                    ChildNode.AddStandartChildren(TreeViewNodeType.Checking);
                    ChildNode.AddStandartChildren(TreeViewNodeType.Setting);
                }
                else //для остальных узлов
                {
                    //добавление подузлов
                    AddTreeViewNodes(ChildNode, Node.GetTreeViewNodes());
                }
            }
        }
        //получить все узлы дерева
        public TreeViewNode GetTreeViewNode()
        {
            //корневой узел
            var ClientsNode = GetTreeViewClients();

            //рекурсивное добавление подузлов
            AddTreeViewNodes(ClientsNode,
                db.DB_Clients.Cast<ITreeView>().ToList());
                        
            return ClientsNode;
        }
    }
}
