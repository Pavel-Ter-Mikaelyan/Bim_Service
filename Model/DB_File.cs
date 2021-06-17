using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
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

        //задать значение свойств для последующего получения строки таблицы
        public override void SetPropertyForGetTableRowData(ApplicationContext db,
                                                           DataProvider ParentProvider)
        {
            //имя шаблона
            TemplateName = DB_Template == null ? "" : DB_Template.Name;
            DB_Stage Stage = (DB_Stage)ParentProvider;
            //список шаблонов
            List<string> TemplateNames = Stage.DB_Templates.Select(q => q.Name).ToList();
        }   

        //модификация
        public override bool Modify(ApplicationContext db,
                                    TableData_Server newTD)
        {
            return true;
        }
    }
}
