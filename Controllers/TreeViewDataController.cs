using Bim_Service.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bim_Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TreeViewController : ControllerBase
    {
        private ApplicationContext db;
        public TreeViewController(ApplicationContext context)
        {
            db = context;
            db.DB_Clients.Load();
            db.DB_Files.Load();
            db.DB_Objects.Load();
            db.DB_Plugins.Load();
            db.DB_Plugin_consts.Load();
            db.DB_Stages.Load();
            db.DB_Stage_consts.Load();
            db.DB_Templates.Load();
        }

        //получить все узлы дерева
        [HttpGet("GetNodes")]
        public TreeViewNodes Get()
        {
            var ClientsNode = new TreeViewNodes();
            ClientsNode.id = "0_Clients";
            ClientsNode.name = "Заказчики";
            //заполнение колекции узлов дерева
            foreach (DB_Client Client in db.DB_Clients)
            {
                var ClientNode = new TreeViewNodes();
                ClientNode.id = Client.Id + "_Client";
                ClientNode.name = Client.Name;
                ClientsNode.children.Add(ClientNode);
                foreach (DB_Object Object in Client.DB_Objects)
                {
                    var ObjectNode = new TreeViewNodes();
                    ObjectNode.id = Object.Id + "_Object";
                    ObjectNode.name = Object.Name;
                    ClientNode.children.Add(ObjectNode);
                    foreach (DB_Stage Stage in Object.DB_Stages)
                    {
                        var StageNode = new TreeViewNodes();
                        StageNode.id = Stage.Id + "_Stage";
                        StageNode.name = Stage.DB_Stage_const.Name;
                        ObjectNode.children.Add(StageNode);

                        var TemplatesNode = new TreeViewNodes();
                        TemplatesNode.id = "StageId=" + Stage.Id + "_Templates";
                        TemplatesNode.name = "Шаблоны";
                        StageNode.children.Add(TemplatesNode);

                        var FilesNode = new TreeViewNodes();
                        FilesNode.id = "StageId=" + Stage.Id + "_Files";
                        FilesNode.name = "Файлы";
                        StageNode.children.Add(FilesNode);
                        foreach (DB_File File in Stage.DB_Files)
                        {
                            var FileNode = new TreeViewNodes();
                            FileNode.id = File.Id + "_File";
                            FileNode.name = File.FileName;
                            FilesNode.children.Add(FileNode);
                        }
                        foreach (DB_Template Template in Stage.DB_Templates)
                        {
                            var TemplateNode = new TreeViewNodes();
                            TemplateNode.id = Template.Id + "_Template";
                            TemplateNode.name = Template.Name;
                            TemplatesNode.children.Add(TemplateNode);
                            foreach (DB_Plugin Plugin in Template.DB_Plugins)
                            {
                                var PluginNode = new TreeViewNodes();
                                PluginNode.id = Plugin.Id + "_Plugin";
                                PluginNode.name = Plugin.DB_Plugin_const.Name;
                                TemplateNode.children.Add(PluginNode);

                                var CheckingNode = new TreeViewNodes();
                                CheckingNode.id = "PluginId=" + Plugin.Id + "_Checking";
                                CheckingNode.name = "Проверки";
                                PluginNode.children.Add(CheckingNode);

                                var SettingNode = new TreeViewNodes();
                                SettingNode.id = "PluginId=" + Plugin.Id + "_Setting";
                                SettingNode.name = "Настройки";
                                PluginNode.children.Add(SettingNode);                               
                            }
                        }
                    }
                }
            }
            return ClientsNode;
        }
    }
}
