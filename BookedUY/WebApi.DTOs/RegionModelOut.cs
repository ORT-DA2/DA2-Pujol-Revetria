using Domain;

namespace WebApi.DTOs
{
    public class RegionModelOut
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public RegionModelOut(Region r)
        {
            Id = r.Id;
            Name = r.Name;
        }
    }
}