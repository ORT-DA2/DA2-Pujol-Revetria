using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.DTOs
{
    public class CategoryModelOut
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public CategoryModelOut(Category category)
        {
            Id = category.Id;
            Name = category.Name;
        }
    }
}
