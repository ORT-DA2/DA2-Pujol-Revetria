using BusinessLogicInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class TouristicSpotLogic : ITouristicSpotLogic
    {
        private readonly ITouristicSpotLogic spotLogic;

        public TouristicSpotLogic(ITouristicSpotLogic spotLogic)
        {
            this.spotLogic = spotLogic;
        }
    }
}
