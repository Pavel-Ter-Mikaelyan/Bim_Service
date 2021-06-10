using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Bim_Service.Model.Constants;

namespace Bim_Service.Model
{
    //конструктор данных для таблиц
    public class TableDataConstructor
    {
        //данные для поиска выбранного в дереве узла -----------------
        string systemName { get; set; } = null;
        int id { get; set; }
        string parentSystemName { get; set; } = null;
        int parentId { get; set; }
        //------------------------------------------------------------
        ApplicationContext db { get; set; }

        //если в дереве был выбран стандартный узел
        public TableDataConstructor(ApplicationContext db,
                                    string systemName,
                                    string parentSystemName,
                                    int parentId)
        {
            this.db = db;
            this.systemName = systemName;
            this.parentSystemName = parentSystemName;
            this.parentId = parentId;
        }
        //если в дереве был выбран узел, соответствующий таблице БД
        public TableDataConstructor(ApplicationContext db,
                                    string systemName,
                                    int id)
        {
            this.db = db;
            this.systemName = systemName;
            this.id = id;
        }

        //получить данные для таблиц
        public TableData GetTableData()
        {
            var CurrNodeInfos =
                TreeViewNodeInfos.FirstOrDefault(q =>
                                                 q.Value
                                                  .systemNodeName ==
                                                   systemName);
            if (CurrNodeInfos.Value == null) return null;
            TreeViewNodeType CurrNodeType = CurrNodeInfos.Key;
            TreeViewNodeInfo CurrNodeInfo = CurrNodeInfos.Value;
            if (CurrNodeInfo.hasTableData == false) return null;

            TableData TD = null;
            //если выбран узел 'Стадия'
            if (CurrNodeType == TreeViewNodeType.Stage)
            {
                return null;
            }
            //если выбран узел 'Шаблон'
            else if (CurrNodeType == TreeViewNodeType.Template)
            {
                return null;
            }
            else//если выбран узел по умолчанию 
                //(дочерние элементы которого соответствуют строкам БД)
            {
                //данные
                TD = GetDefaultTableData(CurrNodeInfo, CurrNodeType);
            }

            return TD;
        }
        //получить таблицу для узла по умолчанию
        //(дочерние элементы которого соответствуют строкам БД)
        TableData GetDefaultTableData(TreeViewNodeInfo CurrNodeInfo,
                                      TreeViewNodeType CurrNodeType)
        {
            TreeNodeConstructor TNC = new TreeNodeConstructor(db);
            TreeViewNode ClientsNode = TNC.GetTreeViewNode();

            TreeViewNode FoundNode = null;
            if (CurrNodeType == TreeViewNodeType.Clients)
            {
                FoundNode = ClientsNode;
            }
            else
            {
                FoundNode = TreeViewNode.FindNode(systemName,
                                          id,
                                          parentSystemName,
                                          parentId,
                                          ClientsNode);
            }              
            if (FoundNode == null) return null;

            TableData TD = new TableData();
            TD.tableName = CurrNodeInfo.TableName;
            ColumnData CD = ColumnData.GetDefault();
            FoundNode.children.ForEach(q =>
            {
                if (q is TreeViewNodeDB)
                {
                    TreeViewNodeDB ViewNode =
                               (TreeViewNodeDB)q;
                    rowVal rv = new rowVal { value = ViewNode.name };
                    CD.rowVals.Add(rv);
                    TD.rowIds.Add(ViewNode.id);
                }
            });
            TD.columnData.Add(CD);
            return TD;
        }
    }
}
