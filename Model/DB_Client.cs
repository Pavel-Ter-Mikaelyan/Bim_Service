using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using static Bim_Service.Model.Constants;

namespace Bim_Service.Model
{
    public class DB_Client : DataProvider
    {
        public override int Id { get; set; }

        [Column("Название", "Name", ColumnDataType.Textbox, 0)]
        public override string Name { get; set; }

        [NotMapped]
        public override TreeViewNodeType NodeType { get; set; } =
                             TreeViewNodeType.Client;

        public List<DB_Object> DB_Objects { get; set; } = 
                               new List<DB_Object>();

        //назначить дочерние подузлы
        public override void SetNodes()
        {
            Childs = DB_Objects;
            ChildType = typeof(DB_Object);           
        }       
    }
}
