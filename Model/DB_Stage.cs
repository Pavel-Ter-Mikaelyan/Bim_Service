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
        //назначить дочерние подузлы
        public override void SetNodes()
        {


            Childs = ;
        }



        //public static List<CellContainer> GetHeaderCellContainer(
        //                                            ApplicationContext db)
        //{
        //    List<string> Stages =
        //            db.DB_Stage_consts.Select(q => q.Name).ToList();
        //    if(Stages)

        //}

        //модификация
        public override bool Modify(ApplicationContext db,
                                    TableData_Server newTD)
        {
            //если в новой таблице нет строк
            if (newTD.RowContainers.Count == 0)
            {
                //удалить все строки
                DB_Files.Clear();
            }
            else
            {
                List<DB_File> forAdd = new List<DB_File>();
                foreach (RowContainer RC in newTD.RowContainers)
                {
                    DataProvider ProviderObject =
                        GetNodes().FirstOrDefault(q => q.Id == RC.Id);
                    //добавление нового объекта для строки в коллекцию
                    if (ProviderObject == null)
                    {
                        DB_File obj = new DB_File();
                        obj.SetRowData(db, RC);
                        forAdd.Add(obj);
                    }
                    else//изменение строки таблицы
                    {
                        ProviderObject.SetRowData(db, RC);
                    }
                }
                //добавление новой строки в таблицу
                if (forAdd.Count > 0) DB_Files.AddRange(forAdd);
            }
            return true;
        }
    }
}
