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

        [Column("Стадия", "StageName", ColumnDataType.Combobox, 0)]
        [NotMapped]
        public string StageName { get; set; }
        [ColumnComboboxData("StageName")]
        [NotMapped]
        public List<string> StageNames { get; set; }

        public DB_Object DB_Object { get; set; }
        public DB_Stage_const DB_Stage_const { get; set; }

        public List<DB_File> DB_Files { get; set; }
        public List<DB_Template> DB_Templates { get; set; }
        public List<DB_Plugin> DB_Plugins { get; set; }

        public override TreeViewNode GetNode(int nodeId)
        {
            return NodeConstructor(nodeId, DB_Stage_const.Name);
        }
        //метод для установки Childs и ChildType
        public override void SetNodes()
        {
            StandartNode TemplatesNode =
                new StandartNode(TreeViewNodeType.Templates,
                                 DB_Templates,
                                 typeof(DB_Template));
            StandartNode FilesNode =
                new StandartNode(TreeViewNodeType.Files,
                                 DB_Files,
                                 typeof(DB_File));
            Childs = new List<DataProvider> { TemplatesNode, FilesNode };
            ChildType = typeof(DataProvider);
        }
        //задать значение свойств для последующего получения строки таблицы
        public override void SetPropertyForGetTableRowData(ApplicationContext db,
                                                           DataProvider ParentProvider)
        {
            //имя шаблона
            StageName = DB_Stage_const == null ? "" : DB_Stage_const.Name;
            //список шаблонов
            StageNames = db.DB_Stages.Select(q => q.DB_Stage_const.Name).ToList();
        }
    }
}
