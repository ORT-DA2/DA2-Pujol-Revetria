using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class TouristicSpotImage
    {
        public int Id { get; set; }
        private string _image;
        public string Image
        {
            get
            {
                return _image;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new NullInputException();
                }
                else
                {
                    _image = value.Trim();
                }
            }
        }
        public int TouristicSpotId { get; set; }
        public TouristicSpot TouristicSpot { get; set; }
    }
}
