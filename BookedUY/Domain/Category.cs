using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Category
    {
        public int Id { get; set; }
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new NullInputException();
                }
                else
                {
                    _name = value;
                }
            }
        }
        public List<CategoryTouristicSpot> Spots { get; set; }

        public override bool Equals(object obj)
        {
            var result = false;
            if (obj is Category category)
            {
                result = this.Id == category.Id && this.Name == category.Name;
            }
            return result;
        }
    }
}
