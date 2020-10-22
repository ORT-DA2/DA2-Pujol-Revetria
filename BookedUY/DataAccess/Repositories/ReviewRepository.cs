using DataAccessInterface;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class ReviewRepository : IRepository<Review>
    {
        private readonly DbSet<Review> reviews;
        private readonly DbContext bookedUYContext;

        public ReviewRepository(DbContext context)
        {
            this.bookedUYContext = context;
            this.reviews = context.Set<Review>();
        }

        public IEnumerable<Review> GetAll()
        {
            return this.reviews.Include(b => b.Booking);
        }

        public Review Add(Review review)
        {
            this.reviews.Add(review);
            this.bookedUYContext.SaveChanges();
            return review;
        }

        public Review GetById(int id)
        {
            return this.reviews.Include(r => r.Booking).Where(r => r.Id == id).SingleOrDefault();
        }

        public Review Delete(Review review)
        {
            this.reviews.Remove(review);
            this.bookedUYContext.SaveChanges();
            return review;
        }
    }
}
