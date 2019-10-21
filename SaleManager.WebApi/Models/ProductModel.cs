using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaleManager.WebApi.Models
{
    public class ProductModel
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Barcode { get; set; }
        public int Pin { get; set; }
    }
    public class ProductCondModel
    {
        public string Barcode { get; set; }
        public string Name { get; set; }
        public decimal FromPrice { get; set; }
        public decimal ToPrice { get; set; }
    }
    public class ProductInsertModel
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
        public int Pin { get; set; }
    }

    public class ProductUpdateModel
    {
        public string Barcode { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
    }
}