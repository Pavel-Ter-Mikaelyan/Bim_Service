using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Bim_Service.Model.Constants;

namespace Bim_Service.Model
{
    public class StandartNode : DataProvider
    {
        public override int Id { get; set; } = 0;
        public override string Name { get; set; }
        public override TreeViewNodeType NodeType { get; set; }
        public List<DataProvider> ChildNodes { get; set; }

        public StandartNode(TreeViewNodeType NodeType,
                            bool hasChild = false,
                            List<DataProvider> ChildNodes = null)
        {
            if (!hasChild)
            {
                ChildNodes = new List<DataProvider>();
            }
            if (ChildNodes != null) this.ChildNodes = ChildNodes;
            this.NodeType = NodeType;
        }
        public override TreeViewNode GetNode(int nodeId)
        {
            //информация по узлу
            TreeViewNodeInfo NI = TreeViewNodeInfos[NodeType];           
            return NodeConstructor(nodeId, NI.nodeName);
        }
        public override List<DataProvider> GetNodes()
        {
            return ChildNodes;
        }
    }
}
