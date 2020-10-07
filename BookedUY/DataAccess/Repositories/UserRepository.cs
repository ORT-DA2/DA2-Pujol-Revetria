using DataAccess.Context;
using DataAccessInterface;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbSet<User> administrators;
        private readonly DbContext bookedUYContext;

        public UserRepository(DbContext context)
        {
            this.bookedUYContext = context;
            this.administrators = context.Set<User>();
        }

        public IEnumerable<User> GetAll()
        {
            return this.administrators;
        }

        public void Delete(User user)
        {
            this.administrators.Remove(user);
            bookedUYContext.SaveChanges();
        }

        public User Add(User obj)
        {
            this.administrators.Add(obj);
            bookedUYContext.SaveChanges();
            return obj;
        }

        public User GetById(int id)
        {
            return administrators.Find(id);
        }

        public User GetByEmail(string email)
        {
            return administrators.Where(a => a.Email == email).FirstOrDefault();
        }

    }
}
