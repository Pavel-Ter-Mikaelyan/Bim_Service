using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bim_Service.Model
{
    //доп инфо по стандартным узлам
    public class TreeViewNodeInfo
    {
        public string systemNodeName { get; set; }
        public string nodeName { get; set; }
        //узел, при выборе которого в дереве, на панели справа
        //будет отображаться таблица формата TableData
        public bool hasTableData { get; set; } = false;
        //имя таблицы TableData, которая отображается на панели справа
        public string TableName { get; set; }

        public TreeViewNodeInfo(string systemNodeName,
                                string nodeName,
                                bool hasTableData,
                                string TableName)
        {
            this.systemNodeName = systemNodeName;
            this.nodeName = nodeName;
            this.hasTableData = hasTableData;
            this.TableName = TableName;
        }
    }
}
