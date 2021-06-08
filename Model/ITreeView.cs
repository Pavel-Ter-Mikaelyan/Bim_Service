using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bim_Service.Model
{
    //интерфейс для возможности приведения объектов базы данных 
    //(например, DB_Client) к типу узла дерева (TreeViewNode)
    public interface ITreeView
    {
        public TreeViewNodeDB GetNode();
        public List<ITreeView> GetTreeViewNodes();
    }
}
