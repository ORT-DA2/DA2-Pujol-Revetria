using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessInterface
{
    public interface IAccommodationRepository
    {
        IEnumerable<Accommodation> GetAll();
        void Add(Accommodation accommodation);
        void Delete(Accommodation accommodation);
    }
}
