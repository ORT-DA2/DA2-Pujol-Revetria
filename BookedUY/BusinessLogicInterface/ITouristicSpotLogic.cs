using Domain;
using System.Collections.Generic;

namespace BusinessLogicInterface
{
    public interface ITouristicSpotLogic
    {
        TouristicSpot AddTouristicSpot(TouristicSpot spot);

        IEnumerable<TouristicSpot> GetSpotsByRegionAndCategory(List<int> category, int region);
    }
}