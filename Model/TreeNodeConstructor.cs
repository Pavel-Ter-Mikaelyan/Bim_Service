using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bim_Service.Model
{
    public class TreeNodeConstructor
    {
        public ApplicationContext db { get; set; }
        public TreeNodeConstructor(ApplicationContext db)
        {
            this.db = db;
        }
        public TreeViewNode GetTreeViewNode()
        {
            //корневой узел
            var ClientsNode = Constants.GetTreeViewClients();

            //заполнение всех узлов дерева
            foreach (DB_Client Client in db.DB_Clients)
            {
                var ClientNode = Client.GetNode();
                ClientsNode.AddChildren(ClientNode);

                foreach (DB_Object Object in Client.DB_Objects)
                {
                    var ObjectNode = Object.GetNode();
                    ClientNode.AddChildren(ObjectNode);

                    foreach (DB_Stage Stage in Object.DB_Stages)
                    {
                        var StageNode = Stage.GetNode();
                        ObjectNode.AddChildren(StageNode);

                        //добавление стандартных узлов
                        var TemplatesNode =
                            StageNode.AddStandartChildren(Constants.TreeViewNodeType.Templates);
                        var FilesNode =
                            StageNode.AddStandartChildren(Constants.TreeViewNodeType.Files);

                        if (FilesNode != null)
                        {
                            foreach (DB_File File in Stage.DB_Files)
                            {
                                var FileNode = File.GetNode();
                                FilesNode.AddChildren(FileNode);
                            }
                        }

                        if (TemplatesNode != null)
                        {
                            foreach (DB_Template Template in Stage.DB_Templates)
                            {
                                var TemplateNode = Template.GetNode();
                                TemplatesNode.AddChildren(TemplateNode);

                                foreach (DB_Plugin Plugin in Template.DB_Plugins)
                                {
                                    var PluginNode = Plugin.GetNode();
                                    TemplateNode.AddChildren(PluginNode);

                                    //добавление стандартных узлов
                                    PluginNode.AddStandartChildren(Constants.TreeViewNodeType.Checking);
                                    PluginNode.AddStandartChildren(Constants.TreeViewNodeType.Setting);
                                }
                            }
                        }
                    }
                }
            }
            return ClientsNode;
        }
    }
}
