﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using static Bim_Service.Model.Constants;

namespace Bim_Service.Model
{
    public class DB_Template : DataProvider
    {
        public override int Id { get; set; }
     
        [Column("Название", "Name", ControlType.TextBox, 0)]
        public override string Name { get; set; }

        [NotMapped]
        public override TreeViewNodeType NodeType { get; set; } =
                                TreeViewNodeType.Template;

        public DB_Stage DB_Stage { get; set; }

        [Childs(typeof(DB_Plugin))]
        public List<DB_Plugin> DB_Plugins { get; set; } =
                     new List<DB_Plugin>();     

        //установить специфические данные объекта для модификации БД
        public override bool SetSpecificDataForModify(ApplicationContext db,
                                                     DataProvider parentNode)
        {
            DB_Stage = (DB_Stage)parentNode.ParentNode;           
            return true;
        }

    }
}
