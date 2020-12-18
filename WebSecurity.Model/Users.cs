using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSecurity.Model
{
    [Table("Users")]
    public class Users
    {
        //继承baseEntity后的 id
        public int Id { get; set; }
        public string UserNo { get; set; }
   
        public string UserName { get; set; }

        public int UserLevel { get; set; }
        public string Password { get; set; }
    }
}
