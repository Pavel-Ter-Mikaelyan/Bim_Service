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

        public override TreeViewNode GetNode(int nodeId)
        {
            return NodeConstructor(nodeId, FileName);
        }

        //модификация
        public override bool Modify(ApplicationContext db,
                                    TableData_Server newTD)
        {           
            return true;
        }
    }
}
