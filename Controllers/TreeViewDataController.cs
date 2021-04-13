using Bim_Service.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bim_Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TreeViewDataController : ControllerBase
    {
        private ApplicationContext db;
        public TreeViewDataController(ApplicationContext context)
        {
            db = context;
        }               

        [HttpGet]
        public IEnumerable<string> Get()
        {
            

            return new List<string>();
        }
    }
}
