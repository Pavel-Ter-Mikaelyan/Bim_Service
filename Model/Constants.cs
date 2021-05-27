using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bim_Service.Model
{
    public static class Constants
    {
        //Типы стандартных узлов
        public enum TreeViewNodeType
        {
            Clients,
            Templates,
            Files,
            Checking,
            Setting,
        }
        //словарь стандартных узлов
        public static Dictionary<TreeViewNodeType, TreeViewNodeStandartInfo>
            TreeViewNodeNames =
            new Dictionary<TreeViewNodeType, TreeViewNodeStandartInfo>() {
                {TreeViewNodeType.Clients,
                  new TreeViewNodeStandartInfo("Clients","Заказчики")},
                {TreeViewNodeType.Templates,
                  new TreeViewNodeStandartInfo("Templates","Шаблоны")},
                {TreeViewNodeType.Files,
                  new TreeViewNodeStandartInfo("Files","Файлы")},
                {TreeViewNodeType.Checking,
                  new TreeViewNodeStandartInfo("Checking","Проверки")},
                {TreeViewNodeType.Setting,
                  new TreeViewNodeStandartInfo("Setting","Настройки")},
            };
        //получить корневой узел
        public static TreeViewNodeStandart GetTreeViewClients()
        {
            //информация по корневому узлу
            TreeViewNodeStandartInfo NI =
                TreeViewNodeNames[TreeViewNodeType.Clients];
            //создать корневой узел
            return new TreeViewNodeStandart(NI.nodeName,
                                            NI.systemNodeName,
                                            0,
                                            null);
        }
    }
}
