using Bim_Service.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

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

        //получить данные таблицы
        [HttpGet("GetTableData/{systemName}/true/{parentSystemName}/{parentId:int}")]
        public object Get(
            string systemName,
            string parentSystemName,
            int parentId
            )
        {
            TableDataConstructor TDC =
                new TableDataConstructor(db,                                         
                                         systemName,
                                         parentSystemName,
                                         parentId);
            TableData TD = TDC.GetAllTableData();
            return TD;
        }
        [HttpGet("GetTableData/{systemName}/false/{id:int}")]
        public object Get(string systemName, int id)
        {
            TableDataConstructor TDC =
                new TableDataConstructor(db,
                                         systemName,
                                         id);
            TableData TD = TDC.GetAllTableData();
            return TD;
        }

        [HttpPost("{id}")]
        public void Post(int id)
        {
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
