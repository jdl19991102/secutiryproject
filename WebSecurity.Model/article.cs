using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebSecurity.Model
{
    [Table("Article")]
    public class article
    {
        //public int id { get; set; }
        public string title { get; set; }
        public string contents { get; set; }
        public string firstImage { get; set; }
        public string source { get; set; }
        public DateTime date { get; set; }
        public string newsType { get; set; }
        public string newsTypeCN { get; set; }
    }
}
