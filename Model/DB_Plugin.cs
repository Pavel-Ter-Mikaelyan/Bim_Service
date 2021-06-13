using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Bim_Service.Model
{
    public class DB_Plugin : ITreeView
    {
        public int Id { get; set; }
        public string CheckingData { get; set; }
        public string SettingData { get; set; }
        public string PluginVersion { get; set; }

        public DB_Plugin_const DB_Plugin_const { get; set; }       
        public DB_Template DB_Template { get; set; }       
        public DB_Stage DB_Stage { get; set; }

        public TreeViewNode GetNode(int nodeId)
        {
            return new TreeViewNode(DB_Plugin_const.Name, "Plugin", nodeId, Id);
        }        
        public List<ITreeView> GetTreeViewNodes()
        {
            return new List<ITreeView>();
        }
    }
}
