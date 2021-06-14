using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using static Bim_Service.Model.Constants;

namespace Bim_Service.Model
{
    public class DB_Stage : TreeViewProvider
    {
        public override int Id { get; set; }

        [NotMapped]
        public override TreeViewNodeType NodeType { get; set; } =
                           TreeViewNodeType.Stage;
        [NotMapped]
        public override string Name { get; set; }

        public DB_Object DB_Object { get; set; }
        public DB_Stage_const DB_Stage_const { get; set; }

        public List<DB_File> DB_Files { get; set; }
        public List<DB_Template> DB_Templates { get; set; }
        public List<DB_Plugin> DB_Plugins { get; set; }

        public override TreeViewNode GetNode(int nodeId)
        {
            Name = DB_Stage_const.Name;
            return GetTreeViewNode(nodeId);
        }
        public override List<TreeViewProvider> GetNodes()
        {
            StandartNode TemplatesNode =
                        new StandartNode(TreeViewNodeType.Templates,
                                         true,
                                         DB_Templates.Cast<TreeViewProvider>().ToList());
            StandartNode FilesNode =
                new StandartNode(TreeViewNodeType.Files,
                                 true,
                                 DB_Files.Cast<TreeViewProvider>().ToList());
            List<TreeViewProvider> Nodes =
                new List<TreeViewProvider> { TemplatesNode, FilesNode };
            return Nodes;
        }
    }
}
