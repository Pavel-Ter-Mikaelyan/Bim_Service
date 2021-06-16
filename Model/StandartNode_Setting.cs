using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Bim_Service.Model.Constants;

namespace Bim_Service.Model
{
    public class StandartNode_Setting : DataProvider
    {
        public override string Name { get; set; }
        public override TreeViewNodeType NodeType { get; set; } =
                              TreeViewNodeType.Setting;
        //конструктор
        public StandartNode_Setting()
        {
            //информация по узлу
            TreeViewNodeInfo NI = TreeViewNodeInfos[NodeType];
            Name = NI.nodeName;
        }

        public override bool Modify(ApplicationContext db, 
                                    TableData_Server newTD)
        {
            return true;
        }
    }
}
