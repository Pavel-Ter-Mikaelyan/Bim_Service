using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bim_Service.Model
{
    public static class Constants
    {
        //Типы узлов
        public enum TreeViewNodeType
        {
            Client,
            Clients,
            Object,
            Stage,
            Template,
            Templates,
            Plugin,
            Files,
            File,
            Checking,
            Setting, 
        }
        //словарь узлов
        public static Dictionary<TreeViewNodeType, TreeViewNodeInfo>
            TreeViewNodeNames =
            new Dictionary<TreeViewNodeType, TreeViewNodeInfo>() {
                {TreeViewNodeType.Clients,
                  new TreeViewNodeInfo("Clients","Заказчики")},
                { TreeViewNodeType.Client,
                  new TreeViewNodeInfo("Client","Заказчик")},
                 { TreeViewNodeType.Object,
                  new TreeViewNodeInfo("Object","Объект")},
                  { TreeViewNodeType.Stage,
                  new TreeViewNodeInfo("Stage","Стадия")},
                {TreeViewNodeType.Templates,
                  new TreeViewNodeInfo("Templates","Шаблоны")},
                {TreeViewNodeType.Template,
                  new TreeViewNodeInfo("Template","Шаблон")},
                {TreeViewNodeType.Files,
                  new TreeViewNodeInfo("Files","Файлы")},
                {TreeViewNodeType.File,
                  new TreeViewNodeInfo("File","Файл")},
                 {TreeViewNodeType.Plugin,
                  new TreeViewNodeInfo("Plugin","Плагин")},
                {TreeViewNodeType.Checking,
                  new TreeViewNodeInfo("Checking","Проверки")},
                {TreeViewNodeType.Setting,
                  new TreeViewNodeInfo("Setting","Настройки")},
            };
        //получить корневой узел
        public static TreeViewNodeStandart GetTreeViewClients()
        {
            //информация по корневому узлу
            TreeViewNodeInfo NI =
                TreeViewNodeNames[TreeViewNodeType.Clients];
            //создать корневой узел
            return new TreeViewNodeStandart(NI.nodeName,
                                            NI.systemNodeName,
                                            0,
                                            "root",
                                            true);
        }
    }
}
