﻿using Domain;
using System;
using System.Collections.Generic;
using System.Text;


namespace WebApi.DTOs
{
    public class TouristicSpotModelIn
    {
        public string Name { get; set; }
        public int RegionId { get; set; }
        public string Description { get; set; }
        public List<int> Categories { get; set; }
        public string Image { get; set; }
        public TouristicSpot FromModelInToTouristicSpot()
        {
            List<CategoryTouristicSpot> listCategories = new List<CategoryTouristicSpot>();
            foreach (int item in this.Categories)
            {
                CategoryTouristicSpot c = new CategoryTouristicSpot();
                c.CategoryId = item;
                listCategories.Add(c);
            }
            TouristicSpotImage image = new TouristicSpotImage();
            image.Image = this.Image;
            TouristicSpot touristicSpot = new TouristicSpot()
            {
                Name = this.Name,
                Description = this.Description,
                RegionId = this.RegionId,
                Categories = listCategories,
                Image = image
            };
            return touristicSpot;
        }
    }
}
