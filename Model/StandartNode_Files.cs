using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Bim_Service.Model.Constants;

namespace Bim_Service.Model
{
    public class StandartNode_Files : DataProvider
    {
        public override string Name { get; set; }
        public override TreeViewNodeType NodeType { get; set; } =
                              TreeViewNodeType.Files;
        public List<DB_File> DB_Files { get; set; }
        //конструктор
        public StandartNode_Files(List<DB_File> DB_Files)
        {
            //информация по узлу
            TreeViewNodeInfo NI = TreeViewNodeInfos[NodeType];
            Name = NI.nodeName;
            this.DB_Files = DB_Files;
        }

        public override List<DataProvider> GetNodes()
        {
            if (DB_Files == null)
            {
                return new List<DataProvider>();
            }
            else
            {
                return DB_Files.Cast<DataProvider>().ToList();
            }          
        }

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
