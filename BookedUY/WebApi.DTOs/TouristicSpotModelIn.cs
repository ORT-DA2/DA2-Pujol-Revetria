using Domain;
using System.Collections.Generic;

namespace WebApi.DTOs
{
    public class TouristicSpotModelIn
    {
        public string Name { get; set; }
        public int RegionId { get; set; }
        public string Description { get; set; }
        public int[] Categories { get; set; }
        public string Image { get; set; }

        public TouristicSpot FromModelInToTouristicSpot()
        {
            List<CategoryTouristicSpot> listCategories = new List<CategoryTouristicSpot>();
            if (Categories == null || Categories.Length < 1)
            {
                listCategories = null;
            }
            else
            {
                foreach (int item in this.Categories)
                {
                    CategoryTouristicSpot c = new CategoryTouristicSpot();
                    c.CategoryId = item;
                    listCategories.Add(c);
                }
            }
            TouristicSpot touristicSpot = new TouristicSpot()
            {
                Name = this.Name,
                Description = this.Description,
                RegionId = this.RegionId,
                Categories = listCategories,
                Image = this.Image
            };
            return touristicSpot;
        }
    }
}