using System.Collections.Generic;
using System.Linq;

namespace Bim_Service.Model
{
    public class DB_Stage : ITreeView
    {
        public int Id { get; set; }

        public DB_Object DB_Object { get; set; }
        public DB_Stage_const DB_Stage_const { get; set; }

        public List<DB_File> DB_Files { get; set; }
        public List<DB_Template> DB_Templates { get; set; }
        public List<DB_Plugin> DB_Plugins { get; set; }

        public TreeViewNode GetNode(int nodeId)
        {
            return new TreeViewNode(DB_Stage_const.Name, "Stage", nodeId, Id);
        }
        public List<ITreeView> GetTreeViewNodes()
        {
            return new List<ITreeView>();
        }
        public List<ITreeView> GetFilesTreeViewNodes()
        {
            return DB_Files.Cast<ITreeView>().ToList();
        }
        public List<ITreeView> GetTemplatesTreeViewNodes()
        {
            return DB_Templates.Cast<ITreeView>().ToList();
        }
    }
}
