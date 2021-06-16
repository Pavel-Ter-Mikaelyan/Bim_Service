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
        public override TreeViewNodeType NodeType { get; set; } =
                           TreeViewNodeType.Stage;
        [NotMapped]
        public override string Name { get; set; }

        public DB_Object DB_Object { get; set; }
        public DB_Stage_const DB_Stage_const { get; set; }

        public List<DB_File> DB_Files { get; set; }
        public List<DB_Template> DB_Templates { get; set; }
        public List<DB_Plugin> DB_Plugins { get; set; }

        public override TreeViewNode GetNode(int nodeId)
        {
            return NodeConstructor(nodeId, DB_Stage_const.Name);
        }
        public override List<DataProvider> GetNodes()
        {
            StandartNode_Templates TemplatesNode =
                        new StandartNode_Templates(DB_Templates);
            StandartNode_Files FilesNode =
                 new StandartNode_Files(DB_Files); ;

            List<DataProvider> Nodes =
                new List<DataProvider> { TemplatesNode, FilesNode };
            return Nodes;
        }

        public override TableData_Client GetTableData(int nodeId,
                                               ApplicationContext db)
        {
            TreeViewNodeInfo NodeInfo = TreeViewNodeInfos[NodeType];
            if (!NodeInfo.hasTableData) return null;

            if (DB_Templates == null || DB_Templates.Count == 0)
            {
                return null;
            }

            List<string> Templates = DB_Templates.Select(q => q.Name).ToList();

            ColumnData TemplateCD = new ColumnData(ColumnDataType.Combobox,
                                                   "Шаблон",
                                                   "Template",
                                                   Templates[0],
                                                   Templates);
            ColumnData FilePathCD = new ColumnData(ColumnDataType.Textbox,
                                                   "Путь к файлу",
                                                   "FilePath",
                                                   "");
            ColumnData FileNameCD = new ColumnData(ColumnDataType.Textbox,
                                                   "Имя файла",
                                                   "FileName",
                                                   "");

            TableData_Client TD = new TableData(nodeId,
                                         NodeInfo.TableName,
                                         new List<ColumnData> {
                                                    TemplateCD,
                                                    FilePathCD,
                                                    FileNameCD
                                         });
            if (DB_Files != null)
            {
                DB_Files.ForEach(q =>
                {
                    TD.rowIds.Add(q.Id);
                    TemplateCD.rowVals.Add(new TableDataCellValue(q.DB_Template.Name));
                    FilePathCD.rowVals.Add(new TableDataCellValue(q.FilePath));
                    FileNameCD.rowVals.Add(new TableDataCellValue(q.FileName));
                });
            }
            return TD;
        }

        public override void ChangeName(ApplicationContext db,
                                        string newName)
        {
            if (db.DB_Stage_consts == null) return;
            if (newName == Name) return;

            DB_Stage_const Stage_const =
                db.DB_Stage_consts
                  .FirstOrDefault(q => q.Name == newName);
            if (Stage_const == null) return;

            DB_Stage_const = Stage_const;           
        }
    }
}
