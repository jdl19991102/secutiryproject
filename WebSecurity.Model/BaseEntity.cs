using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebSecurity.Model
{
   public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
