using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Bim_Service.Model.Constants;

namespace Bim_Service.Model
{
    public class StandartNode_Clients : DataProvider
    {
        public override int Id { get; set; } = 0;
        public override string Name { get; set; }
        public override TreeViewNodeType NodeType { get; set; } =
                              TreeViewNodeType.Clients;
        public DbSet<DB_Client> DB_Clients { get; set; }

        public StandartNode_Clients(DbSet<DB_Client> DB_Clients)
        {
            //информация по узлу
            TreeViewNodeInfo NI = TreeViewNodeInfos[NodeType];
            Name = NI.nodeName;
            this.DB_Clients = DB_Clients;
        }
        public override List<DataProvider> GetNodes()
        {
            if (DB_Clients == null)
            {
                return new List<DataProvider>();
            }
            else
            {
                return DB_Clients.Cast<DataProvider>().ToList();
            }
        }
    }
}
