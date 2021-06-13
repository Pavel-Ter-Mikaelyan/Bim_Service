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
        //узел, при выборе которого в дереве, на панели справа
        //будет отображаться таблица формата TableData
        public bool hasTableData { get; set; } = false;
        //подузлы
        public List<object> children { get; set; } =
            new List<object>();
        //идентификатор узла в дереве
        public int nodeId { get; set; }
        //идентификатор узла в базе (при наличии табличного аналога в базе)
        public int id { get; set; }
        //конструктор
        public TreeViewNode(string name,
                            string systemName,
                            int nodeId,
                            int id)
        {
            this.name = name;
            this.systemName = systemName;
            this.nodeId = nodeId;
            this.id = id;
            hasTableData =
                TreeViewNodeInfos.First(q => q.Value.systemNodeName ==
                                                       systemName)
                                 .Value.hasTableData;
        }
        //добавить узел
        public void AddChildren(object child)
        {
            //добавить узел в коллекцию
            children.Add(child);
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
        //добавить стандартный узел
        public TreeViewNode AddStandartChildren(TreeViewNodeType NT,
                                                int childNodeId)
        {
            //информация по добавляемому стандартному узлу
            TreeViewNodeInfo NI = TreeViewNodeInfos[NT];
            //создать стандартный узел
            var NS = new TreeViewNode(NI.nodeName,
                                      NI.systemNodeName,
                                      childNodeId,
                                      0);
            //добавить стандартный узел в коллекцию
            children.Add(NS);
            return NS;
        }
    }
}
