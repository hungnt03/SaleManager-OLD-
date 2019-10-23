using SaleManager.WebApi.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaleManager.WebApi.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private SaleManagerEntities context = new SaleManagerEntities();
        private ProductRepository productRepository;
        private GenericRepository<Category> categoryRepository;
        private bool disposed = false;
        public ProductRepository ProductRepository
        {
            get
            {
                if (this.productRepository == null)
                    this.productRepository = new ProductRepository(context);
                return this.productRepository;
            }
        }
        public GenericRepository<Category> CategoryRepository
        {
            get
            {
                if (this.categoryRepository == null)
                    this.categoryRepository = new GenericRepository<Category>(context);
                return categoryRepository;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}