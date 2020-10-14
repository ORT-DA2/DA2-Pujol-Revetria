using Domain;

namespace WebApi.DTOs
{
    public class TouristicSpotModelOut
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public TouristicSpotModelOut(TouristicSpot t)
        {
            Id = t.Id;
            Name = t.Name;
            Description = t.Description;
            Image = t.Image;
        }
    }
}