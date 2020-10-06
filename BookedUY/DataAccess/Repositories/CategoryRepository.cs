﻿using DataAccessInterface;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            this.categories.Add(obj);
            bookUYContext.SaveChanges();
        }

        public void Delete(Category obj)
        {
            this.categories.Remove(obj);
            bookUYContext.SaveChanges();
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
