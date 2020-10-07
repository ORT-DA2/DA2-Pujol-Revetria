using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class AccommodationImage
    {
        public int Id { get; set; }
        private byte[] _image;
        public byte[] Image
        {
            get
            {
                return _image;
            }
            set
            {
                if (value == null)
                {
                    throw new InvalidImageException();
                }
                if (value.Length <= 0)
                {
                    throw new InvalidImageException();
                }
                this._image = value;
            }
        }
        public int AccommodationId { get; set; }
        public Accommodation Accommodation { get; set; }
    }
}
