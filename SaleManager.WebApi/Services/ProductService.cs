using SaleManager.WebApi.DataContext;
using SaleManager.WebApi.Infrastructures;
using SaleManager.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SaleManager.WebApi.Services
{
    public interface IProductService
    {
        //Task<List<ProductModel>> GetProducts();
        //Task<ProductModel> GetProduct(string barcodeId);
        //Task<List<ProductModel>> GetProduct(ProductCondModel condition);
        //string CreateProduct(ProductInsertModel model);
        //string UpdateProduct(ProductUpdateModel model);
        //void DeleteProduct(string barcodeId);
    }
    public class ProductService : IProductService
    {
        private readonly SaleManagerEntities _context;

        public ProductService(SaleManagerEntities context)
        {
            _context = context;
        }

        public async Task<List<ProductModel>> GetProducts()
        {
            var  query = await _context.Product.Select(s => new ProductModel()
            {
                Name = s.Name,
                Quantity = s.Quantity ?? 0,
                Price = s.Price ?? 0,
                Barcode = s.Barcode
            }).ToListAsync();

            return query;
        }
        public async Task<ProductModel> GetProduct(string barcodeId)
        {
            var query = await _context.Product.Where(c => c.Barcode.Equals(barcodeId)).Select(s => new ProductModel()
            {
                Name = s.Name,
                Quantity = s.Quantity ?? 0,
                Price = s.Price ?? 0,
                Barcode = s.Barcode
            }).FirstOrDefaultAsync();
            return query;
        }

        public async Task<List<ProductModel>> GetProduct(ProductCondModel condition)
        {
            var query = await _context.Product
                .Where(c => !string.IsNullOrEmpty(condition.Name) && c.Name.Contains(condition.Name))
                .Where(c => condition.FromPrice != 0 && condition.FromPrice >= c.Price)
                .Where(c => condition.ToPrice != 0 && condition.ToPrice <= c.Price)
                .Select(s => new ProductModel()
            {
                Name = s.Name,
                Quantity = s.Quantity ?? 0,
                Price = s.Price ?? 0,
                Barcode = s.Barcode
            }).ToListAsync();

            return query;
        }

        //public string CreateProduct(ProductInsertModel model)
        //{
        //    Product product = new Product()
        //    {
        //        Name = model.Name,
        //        Quantity = model.Quantity,
        //        Price = model.Price
        //    };
        //    product.SupplierId = model.SupplierId;
        //    product.CategoryId = model.CategoryId;
        //    product.CreateAt = DateTime.Now;
        //    product.CreateBy = "";

        //    BarcodeHelper barcodeHelper = new BarcodeHelper();
        //    product.Barcode = barcodeHelper.GenerateBarcode();

        //    _context.Product.Add(product);
        //    _context.SaveChanges();

        //    return product.Barcode;
        //}

        //public string UpdateProduct(ProductUpdateModel model)
        //{
        //    var product = _context.Product.Where(c=>c.Barcode.Equals(model.Barcode)).FirstOrDefault();
        //    product.Name = model.Name;
        //    product.Quantity = model.Quantity;
        //    product.Price = model.Price;
        //    product.CategoryId = model.CategoryId;
        //    product.SupplierId = model.SupplierId;
        //    _context.SaveChanges();
        //    return product.Barcode;
        //}

        public void DeleteProduct(string barcodeId)
        {
            var product = _context.Product.Where(c => c.Barcode.Equals(barcodeId)).FirstOrDefault();
            _context.Product.Remove(product);
            _context.SaveChanges();
        }
    }
}