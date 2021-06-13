using System.Collections.Generic;
using System.Linq;

namespace Bim_Service.Model
{
    public class DB_File : ITreeView
    {
        public int Id { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }

        public DB_Stage DB_Stage { get; set; }
        public DB_Template DB_Template { get; set; }

        public TreeViewNode GetNode(int nodeId)
        {            
            return new TreeViewNode (FileName, "File", nodeId, Id);
        }
        public List<ITreeView> GetTreeViewNodes()
        {
            return new List<ITreeView>();
        }
    }
}
