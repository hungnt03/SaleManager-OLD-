using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaleManager.WebApi.Models
{
    public class BasePagedModel
    {
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int RowCount { get; set; }

        
    }
}