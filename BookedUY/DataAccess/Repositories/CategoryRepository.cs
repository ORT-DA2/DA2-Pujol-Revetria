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

        public void Add(Category obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(Category obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAll()
        {
            return this.categories;
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
