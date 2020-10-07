﻿using System;
using System.Collections.Generic;
using System.Text;


namespace Domain
{
    public class TouristicSpot
    {
        public int Id { get; set; }
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new NullInputException();
                }
                else
                {
                    _name = value.Trim();
                }
            }
        }
        public Region Region { get; set; }
        public int RegionId { get; set; }
        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new NullInputException();
                }
                else
                {
                    _description = value.Trim();
                }
            }
        }
        public List<CategoryTouristicSpot> Categories { get; set; }
        public List<Accommodation> Accommodations { get; set; }

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
        public override bool Equals(object obj)
        {
            var result = false;
            if (obj is TouristicSpot touristicSpot)
            {
                result = this.Id == touristicSpot.Id && this.Name == touristicSpot.Name;
            }
            return result;
        }
    }
}

