using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class ReportTupleReturn
    {
        public string AccommodationName { get; set; }
        public int Count { get; set; }
        public override bool Equals(object obj)
        {
            var result = false;
            if (obj is ReportTupleReturn reportTupleReturn)
            {
                result = this.AccommodationName == reportTupleReturn.AccommodationName;
            }
            return result;
        }

        public override int GetHashCode()
        {
            int hashCode = 1540164420;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(AccommodationName);
            hashCode = hashCode * -1521134295 + Count.GetHashCode();
            return hashCode;
        }
    }
}
