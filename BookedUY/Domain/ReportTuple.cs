using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class ReportTuple
    {
        public int Id { get; set; }
        public int Count { get; set; }

        public override bool Equals(object obj)
        {
            var result = false;
            if (obj is ReportTuple reportTuple)
            {
                result = this.Id == reportTuple.Id;
            }
            return result;
        }

        public override int GetHashCode()
        {
            int hashCode = 1603950996;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + Count.GetHashCode();
            return hashCode;
        }
    }
}
