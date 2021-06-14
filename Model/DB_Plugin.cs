using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
using static Bim_Service.Model.Constants;

namespace Bim_Service.Model
{
    public class DB_Plugin : TreeViewProvider
    {
        public override int Id { get; set; }
        public string CheckingData { get; set; }
        public string SettingData { get; set; }
        public string PluginVersion { get; set; }

        [NotMapped]
        public override TreeViewNodeType NodeType { get; set; } =
                           TreeViewNodeType.Plugin;
        [NotMapped]
        public override string Name { get; set; }

        public DB_Plugin_const DB_Plugin_const { get; set; }
        public DB_Template DB_Template { get; set; }
        public DB_Stage DB_Stage { get; set; }

        public override TreeViewNode GetNode(int nodeId)
        {
            Name = DB_Plugin_const.Name;
            return GetTreeViewNode(nodeId);
        }
        public override List<TreeViewProvider> GetNodes()
        {
            StandartNode CheckingNode =
                new StandartNode(TreeViewNodeType.Checking, false);
            StandartNode SettingNode =
                new StandartNode(TreeViewNodeType.Setting, false);
            List<TreeViewProvider> Nodes =
                new List<TreeViewProvider> { CheckingNode, SettingNode };
            return Nodes;
        }
    }
}
