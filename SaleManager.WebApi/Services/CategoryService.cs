using SaleManager.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SaleManager.WebApi.Services
{
    public interface ICategoryService
    {
        Task<List<CategoryApiModel>> GetCategories();
        Task<CategoryApiModel> GetCategory(string categoryId);
        string CreateCategory(CategoryInsertModel model);
        string UpdateCategory(CategoryInsertModel model);
        void DeleteCategory(int categoryId);
    }
    public class CategoryService : ICategoryService
    {
        private readonly SaleManagerEntities _context;
        public string CreateCategory(CategoryInsertModel model)
        {
            throw new NotImplementedException();
        }

        public void DeleteCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<List<CategoryApiModel>> GetCategories()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryApiModel> GetCategory(string categoryId)
        {
            throw new NotImplementedException();
        }

        public string UpdateCategory(CategoryInsertModel model)
        {
            throw new NotImplementedException();
        }
    }
}