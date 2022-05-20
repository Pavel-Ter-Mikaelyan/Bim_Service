using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Bim_Service.Model.Constants;

namespace Bim_Service.Model
{
    //модификатор базы данных на основе данных таблицы
    public class TableDataModifier
    {
        ApplicationContext _db = null;
        TableData_Client _tableData = null;
        TreeViewNode _currNode = null;

        public TableDataModifier(ApplicationContext db,
                                 TableData_Client tableData)
        {
            this._db = db;
            this._tableData = tableData;  
        }

        //модифицировать
        public bool Modify()
        {
            if (_tableData == null) return false;
            TreeViewNodeConstructor tnc = new TreeViewNodeConstructor(_db);
            TreeViewNode tvn = tnc.GetTreeViewNode();
            _currNode = TreeViewNode.GetNode(_tableData.SelectedId, tvn);
            if (_currNode == null) return false;

            TableData_Server newTD = _tableData.TransformToServer();
            _currNode.NodeProvider.Modify(_db, newTD);
            _db.SaveChanges();           
            return true;
        }
    }
}
