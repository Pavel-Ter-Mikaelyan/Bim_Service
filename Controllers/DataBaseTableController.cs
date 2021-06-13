using Bim_Service.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Bim_Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TablePanelInfoController : ControllerBase
    {
        private ApplicationContext db;
        public TablePanelInfoController(ApplicationContext context)
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

        [HttpGet("GetTableData/{selectedId}")]
        public object Get(int selectedId)
        {
            TableData TD = null;
            try
            {
                TableDataConstructor TDC =
                    new TableDataConstructor(db, selectedId);
                TD = TDC.GetAllTableData();
            }
            catch { }
            return TD;
        }

        [HttpPut("{id}")]
        public void Put(int id)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
