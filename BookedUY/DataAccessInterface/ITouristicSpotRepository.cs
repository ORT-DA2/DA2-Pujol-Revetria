using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessInterface
{
    public interface ITouristicSpotRepository
    {
        IEnumerable<TouristicSpot> GetAll();
        void Add(TouristicSpot spot);
    }
}
