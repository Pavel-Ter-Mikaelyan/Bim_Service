using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using static Bim_Service.Model.Constants;

namespace Bim_Service.Model
{
    public class DB_Object : DataProvider
    {
        public override int Id { get; set; }       
        [Column("Название", "Name", ColumnDataType.Textbox, 0)]
        public override string Name { get; set; }

        [NotMapped]
        public override TreeViewNodeType NodeType { get; set; } =
                             TreeViewNodeType.Object;

        public DB_Client DB_Client { get; set; }
        public List<DB_Stage> DB_Stages { get; set; }
              
        //назначить дочерние подузлы
        public override void SetNodes()
        {
            Childs = DB_Stages;
            ChildType = typeof(DB_Stage);
        }        
    }
}
