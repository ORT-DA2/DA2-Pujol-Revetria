using Domain;
using System.Collections.Generic;
using System.Linq;

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
        public IEnumerable<ReviewModelOut> Reviews { get; set; }
        public double Score { get; set; }

        public AccommodationModelOut(Accommodation a, (double, IEnumerable<Review>) reviews)
        {
            Id = a.Id;
            Name = a.Name;
            Address = a.Address;
            ContactNumber = a.ContactNumber;
            Information = a.Information;
            Price = a.PricePerNight;
            Images = ImagesToStrings(a.Images);
            Score = reviews.Item1;
            Reviews = from r in reviews.Item2 select new ReviewModelOut(r);
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

        //public List<AccommodationModelOut> ToOutList(IEnumerable<AccommodationModelOut> list)
        //{
        //    List<AccommodationModelOut> outList = new List<AccommodationModelOut>();
        //    foreach (var item in list)
        //    {

        //    }
        //}
    }
}