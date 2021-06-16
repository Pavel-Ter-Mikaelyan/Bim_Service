using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Bim_Service.Model.Constants;

namespace Bim_Service.Model
{
    public class StandartNode_Files : DataProvider
    {
        public override int Id { get; set; } = 0;
        public override string Name { get; set; }
        public override TreeViewNodeType NodeType { get; set; } =
                              TreeViewNodeType.Files;
        public List<DB_File> DB_Files { get; set; }

        public StandartNode_Files(List<DB_File> DB_Files)
        {
            //информация по узлу
            TreeViewNodeInfo NI = TreeViewNodeInfos[NodeType];
            Name = NI.nodeName;
            this.DB_Files = DB_Files;
        }
        public override List<DataProvider> GetNodes()
        {
            if (DB_Files == null)
            {
                return new List<DataProvider>();
            }
            else
            {
                return DB_Files.Cast<DataProvider>().ToList();
            }          
        }
    }
}
