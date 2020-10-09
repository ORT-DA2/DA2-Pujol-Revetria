using BusinessLogicInterface;
using DataAccessInterface;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class TouristicSpotLogic : ITouristicSpotLogic
    {
        private readonly ITouristicSpotRepository touristicSpotRepository;

        public TouristicSpotLogic(ITouristicSpotRepository touristicSpotRepository)
        {
            this.touristicSpotRepository = touristicSpotRepository;
        }

        public TouristicSpot AddTouristicSpot(TouristicSpot spot)
        {
            if (this.touristicSpotRepository.GetByName(spot.Name) != null)
            {
                throw new AlreadyExistsException();
            }
            return this.touristicSpotRepository.Add(spot);
        }

        public IEnumerable<TouristicSpot> GetSpotsByRegionAndCategory(List<int> category, int region)
        {
            if ((category == null || category.Count == 0) && region == -1)
            {
                return this.touristicSpotRepository.GetAll();
            }
            if (category == null || category.Count == 0)
            {
                return this.touristicSpotRepository.GetByRegion(region);
            }
            if (region == -1)
            {
                return this.touristicSpotRepository.GetByCategory(category);
            }
            return touristicSpotRepository.GetByCategoryAndRegion(category, region);
        }
    }
}
