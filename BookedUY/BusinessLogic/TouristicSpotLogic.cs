using BusinessLogicInterface;
using DataAccessInterface;
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
    }
}
