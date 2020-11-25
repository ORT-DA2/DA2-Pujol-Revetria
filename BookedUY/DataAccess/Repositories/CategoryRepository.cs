using DataAccessInterface;
using Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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

        public Category AddAndSave(Category obj)
        {
            this.categories.Add(obj);
            bookUYContext.SaveChanges();
            return obj;
        }

        public Category Delete(Category obj)
        {
            this.categories.Remove(obj);
            bookUYContext.SaveChanges();
            return obj;
        }

        public IEnumerable<Category> GetAll()
        {
            return this.categories;
        }

        public Category GetById(int id)
        {
            return this.categories.Find(id);
        }

        public Category GetByName(string name)
        {
            return this.categories.Where(c => c.Name == name).FirstOrDefault();
        }
    }
}