using System.Collections.Generic;
using System.Linq;

namespace Bim_Service.Model
{
    public class DB_Template : ITreeView
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DB_Stage DB_Stage { get; set; }
        public List<DB_Plugin> DB_Plugins { get; set; }

        public TreeViewNode GetNode(int nodeId)
        {
            return new TreeViewNode(Name, "Template", nodeId, Id);
        }
        public List<ITreeView> GetTreeViewNodes()
        {
            return DB_Plugins.Cast<ITreeView>().ToList();
        }
    }
}
