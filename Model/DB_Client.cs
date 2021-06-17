using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using static Bim_Service.Model.Constants;

namespace Bim_Service.Model
{
    public class DB_Client : DataProvider
    {
        public override int Id { get; set; }

        [Column("Название", "Name", ColumnDataType.Textbox, 0)]
        public override string Name { get; set; }

        [NotMapped]
        public override TreeViewNodeType NodeType { get; set; } =
                             TreeViewNodeType.Client;

        public List<DB_Object> DB_Objects { get; set; }

        //назначить дочерние подузлы
        public override void SetNodes()
        {
            Childs = DB_Objects;
            ChildType = typeof(DB_Object);           
        }
        //модификация
        public override bool Modify(ApplicationContext db,
                                    TableData_Server newTD)
        {
            //если в новой таблице нет строк
            if (newTD.RowContainers.Count == 0)
            {
                //удалить все строки
                DB_Objects.Clear();
            }
            else
            {
                List<DB_Object> forAdd = new List<DB_Object>();
                foreach (RowContainer RC in newTD.RowContainers)
                {
                    DataProvider ProviderObject =
                        GetNodes().FirstOrDefault(q => q.Id == RC.Id);
                    //добавление нового объекта для строки в коллекцию
                    if (ProviderObject == null)
                    {
                        DB_Object obj = new DB_Object();
                        obj.SetRowData(db, RC);
                        forAdd.Add(obj);
                    }
                    else//изменение строки таблицы
                    {
                        ProviderObject.SetRowData(db, RC);
                    }
                }
                //добавление новой строки в таблицу
                if (forAdd.Count > 0) DB_Objects.AddRange(forAdd);
            }
            return true;
        }
    }
}
