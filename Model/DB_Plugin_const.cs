using System.Collections.Generic;

namespace Bim_Service.Model
{
    public class DB_Plugin_const
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool HasCheckingForm { get; set; }
        public bool HasSettingForm { get; set; }
        public string PluginCategName { get; set; }
        public string SystemName { get; set; }

        public List<DB_Plugin> DB_Plugins { get; set; }
    }
}
