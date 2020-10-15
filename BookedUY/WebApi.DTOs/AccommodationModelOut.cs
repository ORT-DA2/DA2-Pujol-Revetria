using Domain;
using System.Collections.Generic;

namespace WebApi.DTOs
{
    public class AccommodationModelOut
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string Information { get; set; }
        public double Price { get; set; }
        public List<string> Images { get; set; }

        public AccommodationModelOut(Accommodation a)
        {
            Id = a.Id;
            Name = a.Name;
            Address = a.Address;
            ContactNumber = a.ContactNumber;
            Information = a.Information;
            Price = a.PricePerNight;
            Images = ImagesToStrings(a.Images);
        }

        private List<string> ImagesToStrings(List<AccommodationImage> images)
        {
            List<string> imagesString = new List<string>();
            foreach (var item in images)
            {
                imagesString.Add(item.Image);
            }
            return imagesString;
        }
    }
}