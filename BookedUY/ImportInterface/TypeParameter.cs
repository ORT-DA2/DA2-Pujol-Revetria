using System;
using System.Collections.Generic;
using System.Text;

namespace ImportInterface
{
    public class TypeParameter
    {
       public string Name { get; set; }
       public string Type { get; set; }
        public override bool Equals(object obj)
        {
            var result = false;
            if (obj is TypeParameter typeParameter)
            {
                result = this.Name == typeParameter.Name && this.Type == typeParameter.Type;
            }
            return result;
        }
    }
}
