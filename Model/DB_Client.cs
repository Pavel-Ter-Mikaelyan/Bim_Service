using System.Collections.Generic;

namespace Bim_Service.Model
{
    public class DB_Client
    {       
        public int Id { get; set; }
        public string Name { get; set; }

        public List<DB_Object> DB_Objects { get; set; }
    }
}
