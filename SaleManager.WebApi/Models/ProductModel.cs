using SaleManager.WebApi.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaleManager.WebApi.Models
{
    public class ProductCondModel : BasePagedModel
    {
        public string Barcode { get; set; }
        public string Name { get; set; }
        public decimal FromPrice { get; set; }
        public decimal ToPrice { get; set; }
        public int CategoryId { set; get; }
        public int SupplierId { set; get; }
        public BasePagedModel GeneratePaged()
        {
            BasePagedModel paged = new BasePagedModel();
            paged.CurrentPage = CurrentPage;
            paged.PageCount = PageCount;
            paged.PageSize = PageSize;
            paged.RowCount = RowCount;
            return paged;
        }
    }
    public class ProductModel
    {
        public string Barcode { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
        public int Pin { get; set; }

        public Product Generate()
        {
            Product product = new Product();
            product.Barcode = Barcode;
            product.Name = Name;
            product.Quantity = Quantity;
            product.Price = Price;
            product.SupplierId = SupplierId;
            product.CategoryId = CategoryId;
            product.CreateAt = DateTime.Now;
            product.CreateBy = "Hung";
            product.Pin = (byte)Pin;
            return product;
        }
        public void Generate(ref Product product)
        {
            product.Name = product.Name.Equals(Name)? product.Name: Name;
            product.Quantity = product.Quantity == Quantity ? product.Quantity :  Quantity;
            product.Price = product.Price == Price ? product.Price : Price; 
            product.SupplierId = product.SupplierId == SupplierId ? product.SupplierId : SupplierId;
            product.CategoryId = product.CategoryId == CategoryId ? product.CategoryId : CategoryId;
            product.CreateAt = DateTime.Now;
            product.CreateBy = "Hung";
            product.Pin = (byte)Pin;
        }
    }
}