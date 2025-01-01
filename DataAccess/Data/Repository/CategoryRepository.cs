using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Repository
{
    public class CategoryRepository :GenericRepository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryRepository(ApplicationDbContext dbContext):base(dbContext) 
        {
            _dbContext = dbContext;
        }
        public void save()
        {
            _dbContext.SaveChanges();
        }

        public void updateCategory(Category category)
        {
           _dbContext.Categories.Update(category);
        }
    }
}
