using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Bim_Service.Model.Constants;

namespace Bim_Service.Model
{
    public class StandartNode_Setting : DataProvider
    {
        public override int Id { get; set; } = 0;
        public override string Name { get; set; }
        public override TreeViewNodeType NodeType { get; set; } =
                              TreeViewNodeType.Setting;

        public StandartNode_Setting()
        {
            //информация по узлу
            TreeViewNodeInfo NI = TreeViewNodeInfos[NodeType];
            Name = NI.nodeName;
        }
    }
}
