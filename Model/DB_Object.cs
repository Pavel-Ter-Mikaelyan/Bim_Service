using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using static Bim_Service.Model.Constants;

namespace Bim_Service.Model
{
    public class DB_Object : TreeViewProvider
    {
        public override int Id { get; set; }
        public override string Name { get; set; }

        [NotMapped]
        public override TreeViewNodeType NodeType { get; set; } =
                             TreeViewNodeType.Object;

        public DB_Client DB_Client { get; set; }
        public List<DB_Stage> DB_Stages { get; set; }
                      
        public override List<TreeViewProvider> GetNodes()
        {
            return DB_Stages.Cast<TreeViewProvider>().ToList();
        }
    }
}
