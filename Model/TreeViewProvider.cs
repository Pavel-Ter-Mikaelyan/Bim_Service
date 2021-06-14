using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static Bim_Service.Model.Constants;

namespace Bim_Service.Model
{
    //класс для возможности приведения объектов базы данных 
    //(например, DB_Client) к типу узла дерева (TreeViewNode)
    public abstract class TreeViewProvider
    {
        public abstract int Id { get; set; }
        public abstract string Name { get; set; }

        [NotMapped]
        private int nodeId { get; set; }
        [NotMapped]
        public abstract TreeViewNodeType NodeType { get; set; }

        public virtual TreeViewNode GetNode(int nodeId)
        {
            return GetTreeViewNode(nodeId);
        }
        public TreeViewNode GetTreeViewNode(int nodeId)
        {
            this.nodeId = nodeId;
            return new TreeViewNode(Name, nodeId, Id, this);
        }
        public virtual List<TreeViewProvider> GetNodes()
        {
            return new List<TreeViewProvider>();
        }
        //public abstract void AddChildNode(TreeViewProvider ChildNode);
        //public abstract void DeleteChildNode(TreeViewProvider ChildNode);
        //public abstract void ChangeChildNode(TreeViewProvider ChildNode);
        public virtual TableData GetTableData()
        {
            TreeViewNodeInfo NodeInfo = TreeViewNodeInfos[NodeType];
            if (!NodeInfo.hasTableData) return null;

            List<rowVal> rowVals = new List<rowVal>();
            List<int> rowIds = new List<int>();
            GetNodes().ForEach(q =>
            {
                rowVals.Add(new rowVal(q.Name));
                rowIds.Add(q.Id);
            });
            ColumnData CD = new ColumnData(ColumnDataType.Textbox,
                                           "Название",
                                           "name",
                                           "",
                                           rowVals);
            TableData TD = new TableData(nodeId,
                                         NodeInfo.TableName,
                                         rowIds,
                                         new List<ColumnData> { CD });
            return TD;
        }
    }
}
