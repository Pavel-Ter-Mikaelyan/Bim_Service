using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bim_Service.Model
{
    //доп инфо по стандартным узлам
    public class TreeViewNodeInfo
    {
        public string SystemNodeName { get; set; }
        public string NodeName { get; set; }
        //узел, при выборе которого в дереве, на панели справа
        //будет отображаться таблица формата TableData
        public bool HasTableData { get; set; } = false;
        //имя таблицы TableData, которая отображается на панели справа
        public string TableName { get; set; }

        public TreeViewNodeInfo(string systemNodeName,
                                string nodeName,
                                bool hasTableData,
                                string tableName)
        {
            this.SystemNodeName = systemNodeName;
            this.NodeName = nodeName;
            this.HasTableData = hasTableData;
            this.TableName = tableName;
        }
    }
}
