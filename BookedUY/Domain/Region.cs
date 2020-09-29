using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Region
    {
        public int Id { get; set; }
        public string Name
        {
            get { return this.Name; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Name cannot be empty");
                }
                else
                {
                    this.Name = value;
                }
            }
        }
        public List<TouristicSpot> Spots { get; set; }
    }
}
