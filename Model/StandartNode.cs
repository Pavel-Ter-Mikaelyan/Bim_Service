using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Bim_Service.Model.Constants;

namespace Bim_Service.Model
{
    public class StandartNode : TreeViewProvider
    {
        public override int Id { get; set; } = 0;
        public override string Name { get; set; }
        public override TreeViewNodeType NodeType { get; set; }
        public List<TreeViewProvider> ChildNodes { get; set; }

        public StandartNode(TreeViewNodeType NodeType,
                            bool hasChild = false,
                            List<TreeViewProvider> ChildNodes = null)
        {
            if (!hasChild)
            {
                ChildNodes = new List<TreeViewProvider>();
            }
            this.ChildNodes = ChildNodes;
            this.NodeType = NodeType;
        }
        public override TreeViewNode GetNode(int nodeId)
        {
            //информация по узлу
            TreeViewNodeInfo NI = TreeViewNodeInfos[NodeType];
            Name = NI.nodeName;
            return GetTreeViewNode(nodeId);
        }
        public override List<TreeViewProvider> GetNodes()
        {
            return ChildNodes;
        }
    }
}
