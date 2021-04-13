using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bim_Service.Model
{
    public class DB_Template
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DB_Stage DB_Stage { get; set; }
        public List<DB_Plugin> DB_Plugins { get; set; }
    }
}
