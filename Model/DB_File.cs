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
        public List<string> TemplateNames { get; set; } =
                            new List<string>();

        public override TreeViewNode GetNode(int nodeId)
        {
            return NodeConstructor(nodeId, FileName);
        }     
        //задать значение свойств объекта для вывода информации (TableData) из БД
        public override void SetPropertyForGetTableData(ApplicationContext db,
                                                        DataProvider ParentNode)
        {
            //имя шаблона
            TemplateName = DB_Template == null ? "" : DB_Template.Name;
            DB_Stage Stage = (DB_Stage)ParentNode.ParentNode;
            //список шаблонов
            if (Stage.DB_Templates != null && Stage.DB_Templates.Count > 0)
            {
                TemplateNames = Stage.DB_Templates.Select(q => q.Name).ToList();
            }
        }
        //установить специфические данные объекта для модификации БД
        public override bool SetSecificDataForModify(ApplicationContext db,
                                                     DataProvider ParentNode)
        {
            DB_Stage = (DB_Stage)ParentNode.ParentNode;
            DB_Template= DB_Stage.DB_Templates
                                 .FirstOrDefault(q => q.Name == 
                                                        TemplateName);
            if (DB_Template == null) return false;
            return true;
        }
    }
}
