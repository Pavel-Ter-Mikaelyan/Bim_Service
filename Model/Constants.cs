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
        //Типы узлов
        public enum ColumnDataType
        {
            Textbox,
            Combobox,
            Checkbox
        }
        //словарь узлов
        public static Dictionary<TreeViewNodeType, TreeViewNodeInfo>
            TreeViewNodeInfos =
            new Dictionary<TreeViewNodeType, TreeViewNodeInfo>() {
                {TreeViewNodeType.Clients,
                  new TreeViewNodeInfo("Clients","Заказчики",true,"Заказчики")},
                { TreeViewNodeType.Client,
                  new TreeViewNodeInfo("Client","Заказчик",true,"Объекты")},
                 { TreeViewNodeType.Object,
                  new TreeViewNodeInfo("Object","Объект",true,"Стадии")},
                  { TreeViewNodeType.Stage,
                  new TreeViewNodeInfo("Stage","Стадия",false,"")},
                {TreeViewNodeType.Templates,
                  new TreeViewNodeInfo("Templates","Шаблоны",true,"Шаблоны")},
                {TreeViewNodeType.Template,
                  new TreeViewNodeInfo("Template","Шаблон", true,"Плагины")},
                {TreeViewNodeType.Files,
                  new TreeViewNodeInfo("Files","Файлы", true,"Файлы и шаблоны")},
                {TreeViewNodeType.File,
                  new TreeViewNodeInfo("File","Файл", false,"")},
                 {TreeViewNodeType.Plugin,
                  new TreeViewNodeInfo("Plugin","Плагин", false,"")},
                {TreeViewNodeType.Checking,
                  new TreeViewNodeInfo("Checking","Проверки", true,"Параметры проверок")},
                {TreeViewNodeType.Setting,
                  new TreeViewNodeInfo("Setting","Настройки", true,"Параметры настроек")},
            };
    }
}
