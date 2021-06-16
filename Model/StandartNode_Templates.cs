using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Bim_Service.Model.Constants;

namespace Bim_Service.Model
{
    public class StandartNode_Templates : DataProvider
    {
        public override int Id { get; set; } = 0;
        public override string Name { get; set; }
        public override TreeViewNodeType NodeType { get; set; } =
                              TreeViewNodeType.Templates;
        public List<DB_Template> DB_Templates { get; set; }

        public StandartNode_Templates(List<DB_Template> DB_Templates)
        {
            //информация по узлу
            TreeViewNodeInfo NI = TreeViewNodeInfos[NodeType];
            Name = NI.nodeName;
            this.DB_Templates = DB_Templates;
        }
        public override List<DataProvider> GetNodes()
        {
            if (DB_Templates == null)
            {
                return new List<DataProvider>();
            }
            else
            {
                return DB_Templates.Cast<DataProvider>().ToList();
            }           
        }
    }
}
