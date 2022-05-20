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
        public bool DbSetType { get; set; }

        //конструктор
        public StandartNode(TreeViewNodeType nodeType,
                            object childsParam,
                            Type childTypeParam,
                            bool dbSetType = false)
        {
            //информация по узлу
            TreeViewNodeInfo ni = TreeViewNodeInfos[nodeType];
            Name = ni.NodeName;
            DbSetType = dbSetType;
            Childs = childsParam;
            ChildType = childTypeParam;
            NodeType = nodeType;
        }
    }
}
