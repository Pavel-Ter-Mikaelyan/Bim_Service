using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
using static Bim_Service.Model.Constants;

namespace Bim_Service.Model
{
    public class DB_Plugin : DataProvider
    {
        public override int Id { get; set; }
        [NotMapped]
        public override string Name { get; set; }
        public string CheckingData { get; set; }
        public string SettingData { get; set; }
        public string PluginVersion { get; set; }

        [NotMapped]
        public override TreeViewNodeType NodeType { get; set; } =
                           TreeViewNodeType.Plugin;   

        [Column("Плагин", "PluginName", ColumnDataType.Combobox, 0)]
        [NotMapped]
        public string PluginName { get; set; }
        [ColumnComboboxData("PluginName")]
        [NotMapped]
        public List<string> PluginNames { get; set; }

        public DB_Plugin_const DB_Plugin_const { get; set; }
        public DB_Template DB_Template { get; set; }
        public DB_Stage DB_Stage { get; set; }

        public override TreeViewNode GetNode(int nodeId)
        {
            return NodeConstructor(nodeId, DB_Plugin_const.Name);
        }       
        //метод для установки Childs и ChildType
        public override void SetNodes()
        {
            StandartNode CheckingNode = new StandartNode(TreeViewNodeType.Checking,
                                                         null,
                                                         null);
            StandartNode SettingNode = new StandartNode(TreeViewNodeType.Setting,
                                                         null,
                                                         null);
            Childs = new List<DataProvider> { CheckingNode, SettingNode };
            ChildType = typeof(DataProvider);
        }

        //задать значение свойств для последующего получения строки таблицы
        public override void SetPropertyForGetTableRowData(ApplicationContext db,
                                                           DataProvider ParentProvider)
        {
            //имя плагина
            PluginName = DB_Plugin_const == null ? "" : DB_Plugin_const.Name;
            //список плагинов
            PluginNames = db.DB_Plugins.Select(q => q.DB_Plugin_const.Name).ToList();
        }
    }
}
