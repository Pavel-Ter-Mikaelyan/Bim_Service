using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bim_Service.Model
{
    public class DB_Stage
    {
        public int Id { get; set; }

        public DB_Object DB_Object { get; set; }
        public DB_Stage_const DB_Stage_const { get; set; }

        public List<DB_File> DB_Files { get; set; }
        public List<DB_Template> DB_Templates { get; set; }
        public List<DB_Plugin> DB_Plugins { get; set; }
    }
}
