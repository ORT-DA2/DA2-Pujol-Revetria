using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class AccommodationImage
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
                    throw new NullInputException("Accommodation Image");
                }
                else
                {
                    _image = value.Trim();
                }
            }
        }
    public int AccommodationId { get; set; }
    public Accommodation Accommodation { get; set; }
}
}
