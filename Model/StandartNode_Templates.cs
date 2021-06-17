using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using static Bim_Service.Model.Constants;

namespace Bim_Service.Model
{
    public class StandartNode_Templates : DataProvider
    {

    }


    public class StandartNode : DataProvider
    {
        public override string Name { get; set; }
        public override TreeViewNodeType NodeType { get; set; }
        public override Type ChildType { get; set; }

        //конструктор
        public StandartNode(TreeViewNodeType NodeType,
                            object Childs,
                            Type ChildType)
        {
            //информация по узлу
            TreeViewNodeInfo NI = TreeViewNodeInfos[NodeType];
            Name = NI.nodeName;
            this.Childs = Childs;
            this.ChildType = ChildType;
        }

        //модификация
        public override bool Modify(ApplicationContext db,
                                    TableData_Server newTD)
        {
            //если в новой таблице нет строк
            if (newTD.RowContainers.Count == 0)
            {
                //удалить все строки
                MethodInfo MI = Childs.GetType().GetMethod("Clear");
                MI.Invoke(Childs, null);
            }
            else
            {
                List<DB_Template> forAdd = new List<DB_Template>();
                foreach (RowContainer RC in newTD.RowContainers)
                {
                    IEnumerator enumerator = GetNodes();
                    bool bNewObject = true;
                    DataProvider ProviderObject = null;
                    if (enumerator != null) 
                    {                      
                        while (enumerator.MoveNext())
                        {
                            ProviderObject = (DataProvider)enumerator.Current;
                            if (ProviderObject.Id == RC.Id)
                            {
                                bNewObject = false;
                                break;
                            }
                        }
                    }
                    //добавление нового объекта для строки в коллекцию
                    if (bNewObject)
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
