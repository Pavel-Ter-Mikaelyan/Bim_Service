using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using static Bim_Service.Model.Constants;

namespace Bim_Service.Model
{
    public class DB_Stage : DataProvider
    {
        public override int Id { get; set; }
        [NotMapped]
        public override string Name { get; set; }

        [NotMapped]
        public override TreeViewNodeType NodeType { get; set; } =
                           TreeViewNodeType.Stage;

        [Column("Стадия", "StageName", ControlType.ComboBox, 0)]
        [NotMapped]
        public string StageName { get; set; }
        [ColumnComboboxData("StageName")]
        [NotMapped]
        public List<string> StageNames { get; set; } =
                       new List<string>();

        public DB_Object DB_Object { get; set; }
        public DB_Stage_const DB_Stage_const { get; set; }

        public List<DB_File> DB_Files { get; set; } =
                       new List<DB_File>();
        public List<DB_Template> DB_Templates { get; set; } =
                       new List<DB_Template>();

        public override TreeViewNode GetNode(int nodeId)
        {
            return NodeConstructor(nodeId, DB_Stage_const.Name);
        }
        //метод для установки Childs и ChildType
        public override void SetNodes()
        {
            StandartNode templatesNode =
                new StandartNode(TreeViewNodeType.Templates,
                                 DB_Templates,
                                 typeof(DB_Template));
            StandartNode filesNode =
                new StandartNode(TreeViewNodeType.Files,
                                 DB_Files,
                                 typeof(DB_File));
            Childs = new List<DataProvider> { templatesNode, filesNode };
            ChildType = typeof(DataProvider);
        }
        //задать значение свойств объекта для вывода информации (TableData) из БД
        public override void SetPropertyForGetTableData(ApplicationContext db,
                                                           DataProvider parentNode)
        {
            //имя стадии
            StageName = DB_Stage_const == null ? "" : DB_Stage_const.Name;
            //список стадий
            if (db.DB_Stage_consts != null && db.DB_Stage_consts.Count() > 0)
            {
                StageNames = db.DB_Stage_consts.Select(q => q.Name).ToList();
            }
        }
        //установить специфические данные объекта для модификации БД
        public override bool SetSpecificDataForModify(ApplicationContext db,
                                                     DataProvider parentNode)
        {
            DB_Object = (DB_Object)parentNode;
            DB_Stage_const =
                db.DB_Stage_consts.FirstOrDefault(q => q.Name == StageName);
            if (DB_Stage_const == null) return false;
            return true;
        }
    }
}
