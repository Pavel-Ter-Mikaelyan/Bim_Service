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
        ApplicationContext db = null;
        TableData_Client TableData = null;
        TreeViewNode currNode = null;

        public TableDataModifier(ApplicationContext db,
                                 TableData_Client TableData)
        {
            this.db = db;
            this.TableData = TableData;  
        }

        //модифицировать
        public bool Modify()
        {
            if (TableData == null) return false;
            TreeViewNodeConstructor TNC = new TreeViewNodeConstructor(db);
            TreeViewNode TVN = TNC.GetTreeViewNode();
            currNode = TreeViewNode.GetNode(TableData.selectedId, TVN);
            if (currNode == null) return false;

            TableData_Server newTD = TableData.TransformToServer();
            //currNode.NodeProvider.Modify(db, newTD);
            db.SaveChanges();
            return true;
        }
    }
}
