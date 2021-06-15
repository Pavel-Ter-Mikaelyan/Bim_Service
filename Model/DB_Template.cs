using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using static Bim_Service.Model.Constants;

namespace Bim_Service.Model
{
    public class DB_Template : DataProvider
    {
        public override int Id { get; set; }
        public override string Name { get; set; }

        [NotMapped]
        public override TreeViewNodeType NodeType { get; set; } =
                                TreeViewNodeType.Template;

        public DB_Stage DB_Stage { get; set; }
        public List<DB_Plugin> DB_Plugins { get; set; }

        public override List<DataProvider> GetNodes()
        {
            if (DB_Plugins == null)
            {
                return new List<DataProvider>();
            }
            else
            {
                return DB_Plugins.Cast<DataProvider>().ToList();
            }
        }
        public override TableData GetTableData(int nodeId,
                                               ApplicationContext db)
        {
            TreeViewNodeInfo NodeInfo = TreeViewNodeInfos[NodeType];
            if (!NodeInfo.hasTableData) return null;

            List<string> Plugins =
                     db.DB_Plugin_consts.Select(q => q.Name).ToList();
            if (Plugins.Count == 0) return null;
            return GetDefaultTableData(nodeId, Plugins[0], true, Plugins);
        }
    }
}
