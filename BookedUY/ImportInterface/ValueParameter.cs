using System;
using System.Collections.Generic;
using System.Text;

namespace ImportInterface
{
    public class ValueParameter
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public override bool Equals(object obj)
        {
            var result = false;
            if (obj is ValueParameter valueParameter)
            {
                result = this.Name == valueParameter.Name && this.Value == valueParameter.Value;
            }
            return result;
        }
    }
}
