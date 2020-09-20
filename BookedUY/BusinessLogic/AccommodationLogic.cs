using BusinessLogicInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class AccommodationLogic : IAccommodationLogic
    {
        private readonly IAccommodationLogic accommodationLogic;

        public AccommodationLogic(IAccommodationLogic accommodationLogic)
        {
            this.accommodationLogic = accommodationLogic;
        }
    }
}
