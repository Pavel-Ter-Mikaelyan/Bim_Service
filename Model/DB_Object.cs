using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using static Bim_Service.Model.Constants;

namespace Bim_Service.Model
{
    public class DB_Object : DataProvider
    {
        public override int Id { get; set; }       
        [Column("Название", "Name", ColumnDataType.Textbox, 0)]
        public override string Name { get; set; }

        [NotMapped]
        public override TreeViewNodeType NodeType { get; set; } =
                             TreeViewNodeType.Object;

        public DB_Client DB_Client { get; set; }
        public List<DB_Stage> DB_Stages { get; set; }
              
        //назначить дочерние подузлы
        public override void SetNodes()
        {
            Childs = DB_Stages;
        }
        //модификация
        public override bool Modify(ApplicationContext db,
                                    TableData_Server newTD)
        {
            //если в новой таблице нет строк
            if (newTD.RowContainers.Count == 0)
            {
                //удалить все строки
                DB_Stages.Clear();
            }
            else
            {
                List<DB_Stage> forAdd = new List<DB_Stage>();
                foreach (RowContainer RC in newTD.RowContainers)
                {
                    DataProvider ProviderObject =
                        GetNodes().FirstOrDefault(q => q.Id == RC.Id);
                    //добавление нового объекта для строки в коллекцию
                    if (ProviderObject == null)
                    {
                        DB_Stage obj = new DB_Stage();
                        obj.SetRowData(db, RC);
                        forAdd.Add(obj);
                    }
                    else//изменение строки таблицы
                    {
                        ProviderObject.SetRowData(db, RC);
                    }
                }
                //добавление новой строки в таблицу
                if (forAdd.Count > 0) DB_Stages.AddRange(forAdd);
            }
            return true;
        }
    }
}
