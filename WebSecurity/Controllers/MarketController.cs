using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSecurity.Interface;
using WebSecurity.Service;
using WebSecurity.Model;
using Dapper;
using Microsoft.AspNetCore.Cors;
using WebSecurity.Interface.Extend;
using Microsoft.Extensions.Logging;
using System.IO;

namespace WebSecurity.Controllers
{
    [EnableCors("any")]
    [Route("[controller]")]
    [ApiController]
    public class MarketController : ControllerBase
    {
        //先写一个构造函数
        private readonly IMarket imarket;

        public MarketController(IMarket market)
        {
            imarket = market;
        }


        [HttpGet("{id}")]
        public void GetUser( int id)
        {
               
        }
    }
}
