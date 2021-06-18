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
        public bool bDbSetType { get; set; }
        object ChildsParam;
        Type ChildTypeParam;

        //конструктор
        public StandartNode(TreeViewNodeType NodeType,                            
                            object ChildsParam,
                            Type ChildTypeParam,
                            bool bDbSetType = false)
        {
            //информация по узлу
            TreeViewNodeInfo NI = TreeViewNodeInfos[NodeType];
            Name = NI.nodeName;
            this.bDbSetType = bDbSetType;
            this.ChildsParam = ChildsParam;
            this.ChildTypeParam = ChildTypeParam;
            this.NodeType = NodeType;
        }
        public override void SetNodes()
        {
            Childs = ChildsParam;
            ChildType = ChildTypeParam;
        }
    }
}
