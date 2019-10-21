using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaleManager.WebApi.Models
{
    public class CategoryApiModel
    {
        public string Name { set; get; }
        public string Category { set; get; }
    }
    public class CategoryInsertModel
    {
        public string Name { set; get; }
        public string Category { set; get; }
        public DateTime CreateAt { set; get; }
        public string CreateBy { set; get; }
    }
}