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
        //стандартный узел (не имеющий табличного аналога в базе)
        public bool standartNode { get; set; } = false;
        //узел, при выборе которого в дереве, на панели справа
        //будет отображаться таблица формата TableData
        public bool hasTableData { get; set; } = false;
        //подузлы
        public List<object> children { get; set; } =
            new List<object>();
        //конструктор
        public TreeViewNode(string name,
                            string systemName,
                            bool standartNode)
        {
            this.name = name;
            this.systemName = systemName;
            this.standartNode = standartNode;
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
        //рекурсивный поиск узла 
        public static TreeViewNode FindNode(string systemName_,
                                            int id_,
                                            string parentSystemName_,
                                            int parentId_,
                                            TreeViewNode currNode)
        {
            try
            {
                if (currNode.systemName == systemName_)
                {
                    if (currNode.standartNode)
                    {
                        TreeViewNodeStandart TVNS =
                            (TreeViewNodeStandart)currNode;
                        if (TVNS.parentId == parentId_ &&
                            TVNS.parentSystemName == parentSystemName_)
                        {
                            return currNode;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        TreeViewNodeDB TVNDB = (TreeViewNodeDB)currNode;
                        if (TVNDB.id == id_)
                        {
                            return currNode;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
                else
                {
                    foreach (TreeViewNode TVN in currNode.children)
                    {
                        TreeViewNode returnVal =
                            FindNode(systemName_,
                                     id_,
                                     parentSystemName_,
                                     parentId_,
                                     TVN);
                        if (returnVal != null) return returnVal;
                    }
                    return null;
                }
            }
            catch { return null; }
        }
    }
}
