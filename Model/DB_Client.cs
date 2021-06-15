using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using static Bim_Service.Model.Constants;

namespace Bim_Service.Model
{
    public class DB_Client : DataProvider
    {
        public override int Id { get; set; }
        public override string Name { get; set; }

        [NotMapped]
        public override TreeViewNodeType NodeType { get; set; } =
                             TreeViewNodeType.Client;

        public List<DB_Object> DB_Objects { get; set; }

        public override List<DataProvider> GetNodes()
        {
            if (DB_Objects == null)
            {
                return new List<DataProvider>();
            }
            else
            {
                return DB_Objects.Cast<DataProvider>().ToList();
            }
        }
    }
}
