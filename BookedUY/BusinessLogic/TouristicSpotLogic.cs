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
            if (this.touristicSpotRepository.GetByName(spot.Name)==null)
            {
                var newSpot = this.touristicSpotRepository.Add(spot);
                return newSpot;
            }
            throw new AlreadyExistsException();
        }
    }
}
