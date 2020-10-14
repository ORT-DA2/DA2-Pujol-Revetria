using Domain;
using System.Collections.Generic;

namespace DataAccessInterface
{
    public interface ITouristicSpotRepository : IRepository<TouristicSpot>
    {
        IEnumerable<TouristicSpot> GetByRegion(int region);

        IEnumerable<TouristicSpot> GetByCategory(List<int> categoriesId);

        IEnumerable<TouristicSpot> GetByCategoryAndRegion(List<int> category, int region);

        TouristicSpot GetByName(string name);
    }
}