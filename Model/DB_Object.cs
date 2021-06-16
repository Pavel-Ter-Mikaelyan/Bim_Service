using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using static Bim_Service.Model.Constants;

namespace Bim_Service.Model
{
    public class DB_Object : DataProvider
    {
        public override int Id { get; set; }
        public override string Name { get; set; }

        [NotMapped]
        public override TreeViewNodeType NodeType { get; set; } =
                             TreeViewNodeType.Object;

        public DB_Client DB_Client { get; set; }
        public List<DB_Stage> DB_Stages { get; set; }

        public override List<DataProvider> GetNodes()
        {
            if (DB_Stages == null)
            {
                return new List<DataProvider>();
            }
            else
            {
                return DB_Stages.Cast<DataProvider>().ToList();
            }
        }
        public override TableData_Client GetTableData(int nodeId,
                                               ApplicationContext db)
        {
            TreeViewNodeInfo NodeInfo = TreeViewNodeInfos[NodeType];
            if (!NodeInfo.hasTableData) return null;

            if (db.DB_Stage_consts == null) return null;
            List<string> Stages =
                     db.DB_Stage_consts.Select(q => q.Name).ToList();
            if (Stages.Count == 0) return null;
            return GetDefaultTableData(nodeId, Stages[0], true, Stages);
        }

        public override bool Modify(ApplicationContext db,
                                    TableData_Client newTD)
        {
            if (newTD == null) return false;
            if (DB_Stages == null) return false;
            if (newTD.columnData.Count == 0) return false;

            for (int i = 0; i < newTD.rowIds.Count; i++)
            {
                DataProvider ChildNode =
                   GetNodes().FirstOrDefault(q => q.Id == newTD.rowIds[i]);
                if (ChildNode != null) 
                {

                    ColumnData columnData = newTD.columnData[0].rowVals[i];

                    Node.ChangeName(db,);
                }


            }


            DB_Stages.Add(Stage);
        }
    }
}
