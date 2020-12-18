using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Data.SqlClient;
using System.Text;
using WebSecurity.Interface;


using WebSecurity.Interface.Extend;
using Microsoft.Extensions.Options;

namespace WebSecurity.Service
{
    public class Market:BaseService,IMarket
    {
        public Market(IOptionsMonitor<DBConnectionOption> options) : base(options)
        {

        }
    }
}
