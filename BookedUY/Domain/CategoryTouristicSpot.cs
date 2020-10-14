namespace Domain
{
    public class CategoryTouristicSpot
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int TouristicSpotId { get; set; }
        public TouristicSpot TouristicSpot { get; set; }
    }
}