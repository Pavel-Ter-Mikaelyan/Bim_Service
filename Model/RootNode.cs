using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Bim_Service.Model.Constants;

namespace Bim_Service.Model
{
    public class RootNode : DataProvider
    {
        public override string Name { get; set; }
        public override TreeViewNodeType NodeType { get; set; } =
                              TreeViewNodeType.Clients;
        public DbSet<DB_Client> DB_Clients { get; set; }

        //конструктор
        public RootNode(DbSet<DB_Client> DB_Clients)
        {
            //информация по узлу
            TreeViewNodeInfo NI = TreeViewNodeInfos[NodeType];
            Name = NI.nodeName;
            this.DB_Clients = DB_Clients;
        }

        //public override IEnumerator GetNodes()
        //{           
        //    IEnumerator returnVal = DB_Clients.AsEnumerable().GetEnumerator();     
        //    return returnVal;
        //}
        ////модификация
        //public override bool Modify(ApplicationContext db,
        //                            TableData_Server newTD)
        //{
        //    //если в новой таблице нет строк
        //    if (newTD.RowContainers.Count == 0)
        //    {
        //        if (DB_Clients.Count() != 0)
        //        {
        //            //удалить все строки
        //            DB_Clients.RemoveRange(DB_Clients);
        //        }
        //    }
        //    else
        //    {
        //        List<DB_Client> forAdd = new List<DB_Client>();
        //        foreach (RowContainer RC in newTD.RowContainers)
        //        {
        //            DataProvider ProviderObject =
        //                GetNodes().FirstOrDefault(q => q.Id == RC.Id);
        //            //добавление нового объекта для строки в коллекцию
        //            if (ProviderObject == null)
        //            {
        //                DB_Client obj = new DB_Client();
        //                obj.SetRowData(db, RC);
        //                forAdd.Add(obj);
        //            }
        //            else//изменение строки таблицы
        //            {
        //                ProviderObject.SetRowData(db, RC);
        //            }
        //        }
        //        //добавление новой строки в таблицу
        //        if (forAdd.Count > 0) DB_Clients.AddRange(forAdd);
        //    }
        //    return true;
        //}
    }
}
