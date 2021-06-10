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
        string selectNodeInfo;
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
            selectNodeInfo = systemName + "/true/" +
                parentSystemName + "/" + parentId;
        }
        //если в дереве был выбран узел, соответствующий таблице БД
        public TableDataConstructor(ApplicationContext db,
                                    string systemName,
                                    int id)
        {
            this.db = db;
            this.systemName = systemName;
            this.id = id;
            selectNodeInfo = systemName + "/false/" + id;
        }

        //получить данные для таблицы выбранного узла
        public TableData GetAllTableData()
        {
            //получить общую информацию о выбранном узле
            var CurrNodeInfos =
                TreeViewNodeInfos.FirstOrDefault(q =>
                                                 q.Value
                                                  .systemNodeName ==
                                                   systemName);
            if (CurrNodeInfos.Value == null) return null;
            TreeViewNodeType CurrNodeType = CurrNodeInfos.Key;
            TreeViewNodeInfo CurrNodeInfo = CurrNodeInfos.Value;
            if (CurrNodeInfo.hasTableData == false) return null;

            return GetAllTableData(CurrNodeInfo, CurrNodeType);
        }
        //получить данные для таблицы выбранного узла
        TableData GetAllTableData(TreeViewNodeInfo CurrNodeInfo,
                                  TreeViewNodeType CurrNodeType)
        {
            TableData TD = new TableData();
            TD.tableName = CurrNodeInfo.TableName;
            TD.selectNodeInfo = selectNodeInfo;
                       
            //если выбран узел 'Стадия'
            if (CurrNodeType == TreeViewNodeType.Stage)
            {
                DB_Stage Stage =
                    db.DB_Stages.FirstOrDefault(q => q.Id == id);
                if (Stage == null) return null;
                ColumnData TemplateCD = new ColumnData();
                ColumnData FileNameCD = new ColumnData();
                ColumnData FilePathCD = new ColumnData();
                

            }
            //если выбран узел 'Шаблон'
            else if (CurrNodeType == TreeViewNodeType.Template)
            {
                return null;
            }
            //если выбран узел 'Объект'
            else if (CurrNodeType == TreeViewNodeType.Object)
            {
                //получить информацию по столбцу 
                ColumnData CD = GetObjectColumnData();
                //добавить информацию по умолчанию для таблицы
                AddDefaultTableData(TD, CD, CurrNodeType);
            }
            else//если выбран узел по умолчанию 
                //(дочерние элементы которого соответствуют строкам БД)
            {
                //получить информацию по столбцу 
                ColumnData CD = ColumnData.GetDefault();
                //добавить информацию по умолчанию для таблицы
                AddDefaultTableData(TD, CD, CurrNodeType);                
            }                        
            return TD;
        }
        //получить информацию по столбцу таблицы для узла Object
        ColumnData GetObjectColumnData()
        {
            ColumnData CD = ColumnData.GetDefault();
            //тип ячеек таблицы - комбобокс
            CD.type = 1;
            //заполнение списка стадий
            CD.comboboxData =
                db.DB_Stage_consts.Select(q => q.Name).ToList();
            //значение по умолчанию
            CD.defVal = CD.comboboxData.Count > 0 ?
                                    CD.comboboxData[0] : "";
            return CD;
        }
        //добавить информацию по умолчанию для таблицы
        void AddDefaultTableData(TableData TD, ColumnData CD,
                                 TreeViewNodeType CurrNodeType)
        {
            //текущий выбранный узел
            TreeViewNode CurrNode = GetFoundNode(CurrNodeType);
            CurrNode.children.ForEach(q =>
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
            //добавить столбец в таблицу
            TD.columnData.Add(CD);
        }
        //записать данные из базы в объект типа TreeViewNode
        TreeViewNode GetFoundNode(TreeViewNodeType CurrNodeType)
        {
            TreeNodeConstructor TNC = new TreeNodeConstructor(db);
            TreeViewNode ClientsNode = TNC.GetTreeViewNode();
            if (CurrNodeType == TreeViewNodeType.Clients)
            {
                return ClientsNode;
            }
            else
            {
                return TreeViewNode.FindNode(systemName,
                                          id,
                                          parentSystemName,
                                          parentId,
                                          ClientsNode);
            }
        }
    }
}
