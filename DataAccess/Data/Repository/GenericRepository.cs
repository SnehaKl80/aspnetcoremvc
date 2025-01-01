using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess.Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        internal DbSet<T> DbSet;  

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            this.DbSet = _dbContext.Set<T>();
            _dbContext.Products.Include(u => u.Category);
        }
        public void Add(T entity)
        {
          _dbContext.Add(entity);
        }

        public IEnumerable<T> GetAll(string? includeProperties = null)
        {
            IQueryable<T> query = DbSet;
            if(!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                  .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.ToList();
        }

        public T GetById(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false)
        {
            IQueryable<T> query = DbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
            //IQueryable<T> query;
            //if (tracked)
            //{
            //    query = dbSet;

            //}
            //else
            //{
            //    query = dbSet.AsNoTracking();
            //}

            query = query.Where(filter);
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault();


        }

        public void Remove(T entity)
        {
           DbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            DbSet.RemoveRange(entities);
        }
    }
}
