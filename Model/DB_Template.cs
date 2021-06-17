using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using static Bim_Service.Model.Constants;

namespace Bim_Service.Model
{
    public class DB_Template : DataProvider
    {
        public override int Id { get; set; }
     
        [Column("Название", "Name", ColumnDataType.Textbox, 0)]
        public override string Name { get; set; }

        [NotMapped]
        public override TreeViewNodeType NodeType { get; set; } =
                                TreeViewNodeType.Template;

        public DB_Stage DB_Stage { get; set; }
        public List<DB_Plugin> DB_Plugins { get; set; }
      
        //назначить дочерние подузлы
        public override void SetNodes()
        {
            Childs = DB_Plugins;
            ChildType = typeof(DB_Plugin);
        }
       
    }
}
