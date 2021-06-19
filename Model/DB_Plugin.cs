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

        [Column("Плагин", "PluginName", ControlType.ComboBox, 0)]
        [NotMapped]
        public string PluginName { get; set; }
        [ColumnComboboxData("PluginName")]
        [NotMapped]
        public List<string> PluginNames { get; set; } =
                              new List<string>();

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
        //задать значение свойств объекта для вывода информации (TableData) из БД
        public override void SetPropertyForGetTableData(ApplicationContext db,
                                                           DataProvider ParentNode)
        {
            //имя плагина
            PluginName = DB_Plugin_const == null ? "" : DB_Plugin_const.Name;
            //список плагинов
            if (db.DB_Plugin_consts != null && db.DB_Plugin_consts.Count() > 0)
            {
                PluginNames = db.DB_Plugin_consts.Select(q => q.Name).ToList();
            }
        }
        //установить специфические данные объекта для модификации БД
        public override bool SetSecificDataForModify(ApplicationContext db,
                                                     DataProvider ParentNode)
        {
            DB_Template = (DB_Template)ParentNode;
            DB_Stage = DB_Template.DB_Stage;
            DB_Plugin_const =
                db.DB_Plugin_consts.FirstOrDefault(q => q.Name == PluginName);
            if (DB_Plugin_const == null) return false;
            PluginVersion = DB_Plugin_const.PluginVersion;
            CheckingData = DB_Plugin_const.CheckingDataTemplate;
            SettingData = DB_Plugin_const.SettingDataTemplate;

            return true;
        }
    }
}
