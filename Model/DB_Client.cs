using System.Collections.Generic;
using System.Linq;

namespace Bim_Service.Model
{
    public class DB_Client : ITreeView
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<DB_Object> DB_Objects { get; set; }

        public TreeViewNodeDB GetNode()
        {
            return new TreeViewNodeDB(Id, Name, "Client", false);
        }
        public List<ITreeView> GetTreeViewNodes()
        {
            return DB_Objects.Cast<ITreeView>().ToList();
        }
    }
}
