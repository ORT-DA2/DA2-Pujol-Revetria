using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessInterface
{
    public interface ITouristicSpotRepository : IRepository<TouristicSpot>
    {
        IEnumerable<TouristicSpot> GetByCategory(List<int> categoriesId);

        IEnumerable<TouristicSpot> GetByCategoryAndRegion(List<int> category, int region);
        TouristicSpot GetByName(string name);
    }
}
