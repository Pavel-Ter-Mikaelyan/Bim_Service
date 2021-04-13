using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bim_Service.Model
{
    public class DB_Stage_const
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<DB_Stage> DB_Stages { get; set; }
    }
}
