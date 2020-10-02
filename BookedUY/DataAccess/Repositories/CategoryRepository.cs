using DataAccessInterface;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly DbSet<Category> categories;
        private readonly DbContext bookUYContext;

        public CategoryRepository(DbContext bookUYContext)
        {
            this.bookUYContext = bookUYContext;
            this.categories = bookUYContext.Set<Category>();
        }

        public IEnumerable<Category> GetAll()
        {
            return this.categories;
        }
    }
}
