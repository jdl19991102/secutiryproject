using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using WebSecurity.Interface;
using WebSecurity.Interface.Extend;

namespace WebSecurity.Service
{
   public  class ArticleService:BaseService,IArticleService
    {
        public ArticleService(IOptionsMonitor<DBConnectionOption> options) : base(options)
        {

        }
    }
}
