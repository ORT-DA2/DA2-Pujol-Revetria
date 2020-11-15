using ImportInterface;
using ImportInterface.Parse;
using System;
using System.Collections.Generic;

namespace ImplementationTest
{
    public class ImplementationTest : IImport
    {
        public string GetName()
        {
            return "Test";
        }

        public List<TypeParameter> GetParameters()
        {
            return new List<TypeParameter>()
            {
                new TypeParameter()
                {
                    Name = "Path",
                    Type = "string"
                }
            };
        }

        public AccommodationParse Import(List<ValueParameter> parameters)
        {
            return new AccommodationParse()
            {
                Name = "Test",
                Address = "TestAddress",
                ContactNumber = "TestContactNumber",
                Description = "TestDescription",
                Full = false,
                Information = "TestInformation",
                PricePerNight = 1,
                Images = new List<AccommodationImageParse>(){
                    new AccommodationImageParse()
                    {
                        Image = "TestImage"
                    }
                },
                TouristicSpot = new TouristicSpotParse()
                {
                    Categories = new List<int>()
                    {
                        1,
                        2
                    },
                    Image = "TestImageTouristicSpot",
                    Description = "TestDescriptionTouristicSpot",
                    Name = "TestNameTouristicSpot",
                    RegionId = 1
                }
            };
        }
    }
}
