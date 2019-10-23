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
using SaleManager.WebApi.Repositories;

namespace SaleManager.WebApi.Controllers
{
    public class ProductsController : ApiController
    {
        private UnitOfWork _unitOfWork;
        public ProductsController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Products
        public async Task<IHttpActionResult> Index()
        {
            var results = await _unitOfWork.ProductRepository.Get();

            if (results == null)
                return NoContentResult.NotFound("Not found");
            else
                return Ok(results);
        }

        // GET api/Products/5
        [HttpPost]
        public async Task<IHttpActionResult> Details(ProductCondModel condition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!string.IsNullOrEmpty(condition.Barcode))
            {
                var result = _unitOfWork.ProductRepository.GetByID(condition.Barcode);
                return Ok(result);
            }
            else
            {
                var query = await _unitOfWork.ProductRepository.Get();
                List<Product> results = new List<Product>();
                foreach(var elm in query)
                {
                    var valid = true;
                    if (!string.IsNullOrEmpty(condition.Name) && !elm.Name.Contains(condition.Name))
                        valid = false;
                    if (condition.FromPrice != 0 && !(elm.Price>=condition.FromPrice))
                        valid = false;
                    if (condition.ToPrice!=0 && !(elm.Price <= condition.ToPrice))
                        valid = false;
                    if (condition.CategoryId!=0 && elm.CategoryId != condition.CategoryId)
                        valid = false;
                    if (condition.SupplierId != 0 && elm.SupplierId != condition.SupplierId)
                        valid = false;
                    if (valid)
                        results.Add(elm);
                }
                return Ok(results);
            }
        }

        [HttpPost]
        public IHttpActionResult Create(ProductModel model)
        {
            if (model == null)
                return BadRequest();
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            Product product = model.Generate();
            BarcodeHelper barcodeHelper = new BarcodeHelper();
            product.Barcode = barcodeHelper.GenerateBarcode();

            _unitOfWork.ProductRepository.Insert(product);
            _unitOfWork.Save();

            return Ok(product);
        }

        [HttpPost]
        public IHttpActionResult Edit(ProductModel model)
        {
            if (model == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = _unitOfWork.ProductRepository.GetByID(model.Barcode);
            if (product == null)
                return NotFound();

            model.Generate(ref product);

            _unitOfWork.ProductRepository.Update(product);
            _unitOfWork.Save();
            return Ok(product);
        }

        [HttpPost]
        public IHttpActionResult Delete(ProductModel model)
        {
            if (string.IsNullOrEmpty(model.Barcode))
                return BadRequest();

            var product = _unitOfWork.ProductRepository.GetByID(model.Barcode);
            _unitOfWork.ProductRepository.Delete(product);
            _unitOfWork.Save();
            return Ok();
        }   
    }
}
