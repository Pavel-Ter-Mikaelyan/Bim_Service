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
        TableData TableData = null;
        TreeViewNode currNode;

        public TableDataModifier(ApplicationContext db,
                                 TableData TableData)
        {
            this.db = db;
            this.TableData = TableData;
            TreeNodeConstructor TNC = new TreeNodeConstructor(db);
            TreeViewNode TVN = TNC.GetTreeViewNode();
            currNode = TreeViewNode.GetNode(TableData.selectedId,
                                            TVN);
        }

        //модифицировать
        public bool Modify()
        {
            if (currNode == null) return false;

            DB_Client Client = db.DB_Clients.First();



            db.SaveChanges();

            return true;
        }
    }
}
