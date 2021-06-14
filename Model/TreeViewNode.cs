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
        public string name { get; set; } = "";
        //системное имя, например "Stage"
        public string systemName { get; set; } = "";
        //подузлы
        public List<TreeViewNode> children { get; set; } =
                new List<TreeViewNode>();
        //идентификатор узла в дереве
        public int nodeId { get; set; }
        //идентификатор узла в базе (при наличии табличного аналога в базе)
        public int id { get; set; }
        [NonSerialized] //тип узла 
        public TreeViewNodeType NodeType;
        [NonSerialized] //инфо узла
        public TreeViewNodeInfo NodeInfo;
        [NonSerialized] //объект узла
        public TreeViewProvider NodeProvider;
        //конструктор
        public TreeViewNode(string name,
                            int nodeId,
                            int id,
                            TreeViewProvider NodeProvider)
        {
            this.name = name;
            this.nodeId = nodeId;
            this.id = id;
            this.NodeProvider = NodeProvider;
            NodeType = NodeProvider.NodeType;
            NodeInfo = TreeViewNodeInfos[NodeType];
            systemName = NodeInfo.systemNodeName;
        }
        //поиск узла
        public static TreeViewNode GetNode(int nodeId,
                                           TreeViewNode TVN)
        {
            if (TVN.nodeId == nodeId)
            {
                return TVN;
            }
            else if (TVN.children.Count == 0)
            {
                return null;
            }
            else
            {
                foreach (TreeViewNode child in TVN.children)
                {
                    TreeViewNode childNode = GetNode(nodeId, child);
                    if (childNode != null) return childNode;
                }
                return null;
            }
        }

        //public TableData GetTableData()
        //{
        //    TableData TD = new TableData();

        //}
    }
}
