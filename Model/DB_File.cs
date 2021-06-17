using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using static Bim_Service.Model.Constants;

namespace Bim_Service.Model
{
    public class DB_File : DataProvider
    {
        public override int Id { get; set; }
        [NotMapped]
        public override string Name { get; set; }

        [Column("Путь к файлу", "FilePath", ColumnDataType.Textbox, 1)]
        public string FilePath { get; set; }
        [Column("Имя файла", "FileName", ColumnDataType.Textbox, 2)]
        public string FileName { get; set; }

        public DB_Stage DB_Stage { get; set; }
        public DB_Template DB_Template { get; set; }

        [NotMapped]
        public override TreeViewNodeType NodeType { get; set; } =
                          TreeViewNodeType.File;

        [Column("Шаблон", "TemplateName", ColumnDataType.Combobox, 0)]
        [NotMapped]
        public string TemplateName { get; set; }
        [ColumnComboboxData("TemplateName")]
        [NotMapped]
        public List<string> TemplateNames { get; set; }

        public override TreeViewNode GetNode(int nodeId)
        {
            return NodeConstructor(nodeId, FileName);
        }

        //изменить данные для строки таблицы
        public void ChangeTableRowData(ApplicationContext db)
        {
            //имя шаблона
            TemplateName = DB_Template == null ? "" : DB_Template.Name;
            //шаблоны для текущей стадии
            TemplateNames =
                db.DB_Templates
                  .Where(q => q.DB_Stage.Id == DB_Stage.Id)
                  .Select(q => q.Name)
                  .ToList();
        }



        public static List<CellContainer> HeaderCellContainer
                           (ApplicationContext db, DataProvider TableNode)
        {


        }


        //модификация
        public override bool Modify(ApplicationContext db,
                                    TableData_Server newTD)
        {
            return true;
        }
    }
}
