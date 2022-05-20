using Bim_Service.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

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

        [HttpGet("GetTableData/{selectedId:int}")]
        public object Get(int selectedId)
        {
            TableData_Client td = null;
            try
            {
                TableDataConstructor tdc =
                    new TableDataConstructor(db, selectedId);
                td = tdc.GetAllTableData();
            }
            catch { }
            return td;
        }

        [HttpPut("PutTableData")]
        public bool Put(TableData_Client td)
        {
            TableDataModifier tdm = new TableDataModifier(db, td);
            bool bResult = false;
            try
            {
                bResult = tdm.Modify();
            }
            catch { }

            return bResult;
        }
    }
}
