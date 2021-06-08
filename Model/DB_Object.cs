using System.Collections.Generic;
using System.Linq;

namespace Bim_Service.Model
{
    public class DB_Object : ITreeView
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DB_Client DB_Client { get; set; }
        public List<DB_Stage> DB_Stages { get; set; }
              
        public TreeViewNodeDB GetNode()
        {
            return new TreeViewNodeDB(Id, Name, "Object", false);
        }
        public List<ITreeView> GetTreeViewNodes()
        {
            return DB_Stages.Cast<ITreeView>().ToList();
        }
    }
}
