﻿using SaleManager.WebApi.DataContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace SaleManager.WebApi.Repositories
{
    public class ProductRepository : IGenericRepository<Product>
    {
        internal SaleManagerEntities context;
        internal DbSet<Product> dbSet;
        public ProductRepository(SaleManagerEntities context)
        {
            this.context = context;
            this.dbSet = context.Set<Product>();
        }
        public virtual async Task<IEnumerable<Product>> Get(
            Expression<Func<Product, bool>> filter = null,
            Func<IQueryable<Product>, IOrderedQueryable<Product>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<Product> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public virtual Product GetByID(object barcode)
        {
            return dbSet.Where(c=>c.Barcode.Equals(barcode.ToString())).Select(s=>s).FirstOrDefault();
        }

        public virtual void Insert(Product entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            Product entityToDelete = dbSet.Where(c => c.Barcode.Equals(id.ToString())).Select(s=>s).FirstOrDefault();
            Delete(entityToDelete);
        }

        public virtual void Delete(Product entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(Product entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public async Task<IEnumerable<Product>> GetWithRawSql(string query, params object[] parameters)
        {
            return await dbSet.SqlQuery(query, parameters).ToListAsync();
        }
    }
}