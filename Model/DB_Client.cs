using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bim_Service.Model
{
    public class DB_Client
    {       
        public int Id { get; set; }
        public string Name { get; set; }

        public List<DB_Object> DB_Objects { get; set; }
    }
}
