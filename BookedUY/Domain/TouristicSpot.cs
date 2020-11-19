using System.Collections.Generic;

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
                    throw new NullInputException("Spot Name");
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
                    throw new NullInputException("Spot Description");
                }
                else
                {
                    _description = value.Trim();
                }
            }
        }

        public List<CategoryTouristicSpot> Categories { get; set; }
        public List<Accommodation> Accommodations { get; set; }
        public string Image { get; set; }

        public bool SpotsEqual()
        {
            return true;
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

        public override int GetHashCode()
        {
            int hashCode = 1398642568;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<Region>.Default.GetHashCode(Region);
            hashCode = hashCode * -1521134295 + RegionId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_description);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<CategoryTouristicSpot>>.Default.GetHashCode(Categories);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<Accommodation>>.Default.GetHashCode(Accommodations);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Image);
            return hashCode;
        }
    }
}