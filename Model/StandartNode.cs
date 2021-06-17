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
    }
}
