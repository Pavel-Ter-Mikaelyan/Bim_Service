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
        TreeViewNode _currNode = null;
        ApplicationContext _db = null;
        int _selectedId;

        //если в дереве был выбран стандартный узел
        public TableDataConstructor(ApplicationContext db,
                                    int selectedId)
        {
            _db = db;
            _selectedId = selectedId;
            TreeViewNodeConstructor tnc = new TreeViewNodeConstructor(db);
            TreeViewNode tvn = tnc.GetTreeViewNode();
            _currNode = TreeViewNode.GetNode(selectedId, tvn);
        }

        //получить данные для таблицы выбранного узла
        public TableData_Client GetAllTableData()
        {
            if (_currNode == null) return null;

            TreeViewNodeInfo currNodeInfo = _currNode.NodeInfo;
            if (currNodeInfo.HasTableData == false) return null;

            TableData_Server tds =
                _currNode.NodeProvider.GetTableData(_db, _selectedId);
            if (tds == null) return null;

            return tds.TransformToClient();
        }
    }
}
