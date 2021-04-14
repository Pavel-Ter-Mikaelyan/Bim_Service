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
    [Route("api/[controller]")]
    public class TreeViewController : ControllerBase
    {
        private ApplicationContext db;
        public TreeViewController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet("AllData")]
        public string Get()
        {


            return Request.Query.FirstOrDefault(p => p.Key == "id").Value;
        }
    }
}
