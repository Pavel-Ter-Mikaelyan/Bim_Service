using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using static Bim_Service.Model.Constants;

namespace Bim_Service.Model
{
    public class DB_Object : DataProvider
    {
        public override int Id { get; set; }
        [Column("Название", "Name", ControlType.TextBox, 0)]
        public override string Name { get; set; }

        [NotMapped]
        public override TreeViewNodeType NodeType { get; set; } =
                             TreeViewNodeType.Object;

        public DB_Client DB_Client { get; set; }

        [Childs(typeof(DB_Stage))]
        public List<DB_Stage> DB_Stages { get; set; } =
                              new List<DB_Stage>();

        //установить специфические данные объекта для модификации БД
        public override bool SetSpecificDataForModify(ApplicationContext db,
                                                     DataProvider ParentNode)
        {
            DB_Client = (DB_Client)ParentNode;
            return true;
        }
    }
}
