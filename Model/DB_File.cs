using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bim_Service.Model
{
    public class DB_File
    {
        public int Id { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }

        public DB_Stage DB_Stage { get; set; }
        public DB_Template DB_Template { get; set; }
    }
}
