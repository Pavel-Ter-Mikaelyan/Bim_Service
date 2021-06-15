using Newtonsoft.Json;
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
        TreeViewNode currNode = null;
        ApplicationContext db = null;
        int selectedId;

        //если в дереве был выбран стандартный узел
        public TableDataConstructor(ApplicationContext db,
                                    int selectedId)
        {
            this.db = db;
            this.selectedId = selectedId;
            TreeViewNodeConstructor TNC = new TreeViewNodeConstructor(db);
            TreeViewNode TVN = TNC.GetTreeViewNode();
            currNode = TreeViewNode.GetNode(selectedId, TVN);
        }

        //получить данные для таблицы выбранного узла
        public TableData GetAllTableData()
        {
            if (currNode == null) return null;

            TreeViewNodeInfo CurrNodeInfo = currNode.NodeInfo;
            if (CurrNodeInfo.hasTableData == false) return null;

            return currNode.NodeProvider.GetTableData(selectedId, db);
        }
    }
}
