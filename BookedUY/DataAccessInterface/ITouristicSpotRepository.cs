using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessInterface
{
    public interface ITouristicSpotRepository
    {
        IEnumerable<TouristicSpot> GetAll();
        IEnumerable<TouristicSpot> GetFromRegion(int i);
        IEnumerable<TouristicSpot> GetFromCategory(List<int> list);
        IEnumerable<TouristicSpot> GetFromCategoryAndRegion(List<int> list, int i);
        TouristicSpot GetByID(int id);
        void Add(TouristicSpot spot);
    }
}
