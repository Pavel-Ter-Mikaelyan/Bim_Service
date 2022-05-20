using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Bim_Service.Model.Constants;

namespace Bim_Service.Model
{
    //общий класс узла дерева
    public class TreeViewNode
    {
        //имя, например "Проектная документация"
        public string Name { get; set; } = "";
        //системное имя, например "Stage"
        public string SystemName { get; set; } = "";
        //подузлы
        public List<TreeViewNode> Children { get; set; } =
                new List<TreeViewNode>();
        //идентификатор узла в дереве
        public int NodeId { get; set; }
        //идентификатор узла в базе (при наличии табличного аналога в базе)
        public int Id { get; set; }
        [NonSerialized] //тип узла 
        public TreeViewNodeType NodeType;
        [NonSerialized] //инфо узла
        public TreeViewNodeInfo NodeInfo;
        [NonSerialized] //объект узла
        public DataProvider NodeProvider;
        //конструктор
        public TreeViewNode(string name,
                            int nodeId,
                            int id,
                            DataProvider nodeProvider)
        {
            if (name != null) this.Name = name;
            NodeId = nodeId;
            Id = id;
            NodeProvider = nodeProvider;
            NodeType = nodeProvider.NodeType;
            NodeInfo = TreeViewNodeInfos[NodeType];
            SystemName = NodeInfo.SystemNodeName;
        }
        //поиск узла
        public static TreeViewNode GetNode(int nodeId,
                                           TreeViewNode tvn)
        {
            if (tvn.NodeId == nodeId)
            {
                return tvn;
            }
            else if (tvn.Children.Count == 0)
            {
                return null;
            }
            else
            {
                foreach (TreeViewNode child in tvn.Children)
                {
                    TreeViewNode childNode = GetNode(nodeId, child);
                    if (childNode != null) return childNode;
                }
                return null;
            }
        }
    }
}
