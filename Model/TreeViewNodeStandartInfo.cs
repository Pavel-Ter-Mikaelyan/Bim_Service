using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bim_Service.Model
{
    //доп инфо по стандартным узлам
    public class TreeViewNodeStandartInfo
    {
        public string systemNodeName { get; set; }
        public string nodeName { get; set; }
        public TreeViewNodeStandartInfo(string systemNodeName,
                                       string nodeName)
        {
            this.systemNodeName = systemNodeName;
            this.nodeName = nodeName;
        }
    }
}
