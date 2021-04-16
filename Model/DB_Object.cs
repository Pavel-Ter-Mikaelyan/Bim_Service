using System.Collections.Generic;

namespace Bim_Service.Model
{
    public class DB_Object
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DB_Client DB_Client { get; set; }
        public List<DB_Stage> DB_Stages { get; set; }
    }
}
