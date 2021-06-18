using Bim_Service.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bim_Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TreeViewController : ControllerBase
    {
        ApplicationContext db;
        public TreeViewController(ApplicationContext context)
        {
            db = context;
            db.DB_Clients.Load();
            db.DB_Files.Load();
            db.DB_Objects.Load();
            db.DB_Plugins.Load();
            db.DB_Plugin_consts.Load();
            db.DB_Stages.Load();
            db.DB_Stage_consts.Load();
            db.DB_Templates.Load();
        }

        //получить все узлы дерева
        [HttpGet("GetNodes")]
        public TreeViewNode Get1()
        { 
            TreeViewNodeConstructor TNC = new TreeViewNodeConstructor(db);
            TreeViewNode TVN = null;
            try
            {
                TVN = TNC.GetTreeViewNode();
            }
            catch { }
            return TVN;
        }
        //получить словарь узлов
        [HttpGet("GetTreeDictionary")]
        public object Get2()
        {
            return Constants.TreeViewNodeInfos.Values;
        }
    }
}
