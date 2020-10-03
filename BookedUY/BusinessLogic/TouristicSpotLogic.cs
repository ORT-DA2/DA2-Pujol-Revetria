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
        private readonly IRepository<TouristicSpot> touristicSpotRepository;

        public TouristicSpotLogic(IRepository<TouristicSpot> touristicSpotRepository)
        {
            this.touristicSpotRepository = touristicSpotRepository;
        }
    }
}
