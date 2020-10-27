using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessInterface
{
    public interface IReviewRepository : IRepository<Review>
    {
        IEnumerable<Review> GetByAccommodation(int id);
    }
}
