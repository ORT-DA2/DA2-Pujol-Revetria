using BusinessLogicInterface;
using DataAccessInterface;
using Domain;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class TouristicSpotLogic : ITouristicSpotLogic
    {
        private readonly ITouristicSpotRepository touristicSpotRepository;

        public TouristicSpotLogic(ITouristicSpotRepository touristicSpotRepository)
        {
            this.touristicSpotRepository = touristicSpotRepository;
        }

        private void CheckRegion(int id)
        {
            if (id == 0)
            {
                throw new NullInputException("Spot Region");
            }
        }

        private void CheckCategories(List<CategoryTouristicSpot> categories)
        {
            if (categories == null)
            {
                throw new NullInputException("Spot Categories");
            }
        }

        private void CheckName(string name)
        {
            if (this.touristicSpotRepository.GetByName(name) != null)
            {
                throw new AlreadyExistsException("Spot");
            }
        }

        public TouristicSpot AddTouristicSpot(TouristicSpot spot)
        {
            CheckRegion(spot.RegionId);
            CheckCategories(spot.Categories);
            CheckName(spot.Name);
            return this.touristicSpotRepository.Add(spot);
        }

        public IEnumerable<TouristicSpot> GetSpotsByRegionAndCategory(List<int> category, int region)
        {
            var touristicsSpots = new List<TouristicSpot>();
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