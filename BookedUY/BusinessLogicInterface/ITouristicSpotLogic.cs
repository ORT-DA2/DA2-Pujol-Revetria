using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicInterface
{
    public interface ITouristicSpotLogic
    {
        TouristicSpot AddTouristicSpot(TouristicSpot spot);
        IEnumerable<TouristicSpot> GetSpotsByRegionAndCategory(List<int> category, int region);
    }
}
