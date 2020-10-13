using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Region
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
                    throw new NullInputException("Region Name");
                }
                else
                {
                    _name = value;
                }
            }
        }
        public List<TouristicSpot> Spots { get; set; }

        public override bool Equals(object obj)
        {
            var result = false;
            if (obj is Region region)
            {
                result = this.Id == region.Id && this.Name == region.Name;
            }
            return result;
        }
    }
}
