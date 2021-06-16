using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Bim_Service.Model.Constants;

namespace Bim_Service.Model
{
    public class StandartNode_Templates : DataProvider
    {
        public override string Name { get; set; }
        public override TreeViewNodeType NodeType { get; set; } =
                              TreeViewNodeType.Templates;
        public List<DB_Template> DB_Templates { get; set; }

        //конструктор
        public StandartNode_Templates(List<DB_Template> DB_Templates)
        {
            //информация по узлу
            TreeViewNodeInfo NI = TreeViewNodeInfos[NodeType];
            Name = NI.nodeName;
            this.DB_Templates = DB_Templates;
        }
       
        public override List<DataProvider> GetNodes()
        {
            if (DB_Templates == null)
            {
                return new List<DataProvider>();
            }
            else
            {
                return DB_Templates.Cast<DataProvider>().ToList();
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
                DB_Templates.Clear();
            }
            else
            {
                List<DB_Template> forAdd = new List<DB_Template>();
                foreach (RowContainer RC in newTD.RowContainers)
                {
                    DataProvider ProviderObject =
                        GetNodes().FirstOrDefault(q => q.Id == RC.Id);
                    //добавление нового объекта для строки в коллекцию
                    if (ProviderObject == null)
                    {
                        DB_Template obj = new DB_Template();
                        obj.SetRowData(db, RC);
                        forAdd.Add(obj);
                    }
                    else//изменение строки таблицы
                    {
                        ProviderObject.SetRowData(db, RC);
                    }
                }
                //добавление новой строки в таблицу
                if (forAdd.Count > 0) DB_Templates.AddRange(forAdd);
            }
            return true;
        }
    }
}
