using SaleManager.WebApi.DataContext;
using SaleManager.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Data.Entity;
using SaleManager.WebApi.Infrastructures;
using SaleManager.WebApi.Services;

namespace SaleManager.WebApi.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly IProductService _productService;
        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Products
        public async Task<IHttpActionResult> GetAll()
        {
            var results = await _productService.GetProducts();

            if (results == null)
                return NoContentResult.NotFound("Not found");
            else
                return Ok(results);
        }

        // GET api/Products/5
        [HttpPost]
        public async Task<IHttpActionResult> Product(ProductCondModel condition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!string.IsNullOrEmpty(condition.Barcode))
            {
                var result = await _productService.GetProduct(condition.Barcode);
                return Ok(result);
            }
            else
            {
                var results = await _productService.GetProduct(condition);
                return Ok(results);
            }
        }

        [HttpPost]
        public IHttpActionResult Insert(ProductInsertModel product)
        {
            if (product == null)
                return BadRequest();
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var currentBarcde = _productService.CreateProduct(product);
            return CreatedAtRoute("Product", new { id = currentBarcde }, new ProductModel() { 
                Barcode= currentBarcde,
                Name = product.Name,
                Quantity = product.Quantity,
                Price = product.Price,
            });
        }

        [HttpPost]
        public IHttpActionResult Update(ProductUpdateModel product)
        {
            if (product == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var currentBarcde = _productService.UpdateProduct(product);
            return Ok(new ProductModel()
            {
                Barcode = currentBarcde,
                Name = product.Name,
                Quantity = product.Quantity,
                Price = product.Price,
            });
        }

        [HttpPost]
        public IHttpActionResult Delete(string barcodeId)
        {
            if (string.IsNullOrEmpty(barcodeId))
                return BadRequest();

            _productService.DeleteProduct(barcodeId);
            return Ok();
        }
    }
}
