using ImportInterface;
using ImportInterface.Parse;
using System;
using System.Collections.Generic;

namespace JSONImporter
{
    public class ImporterJSON : IImport
    {
        public string GetName()
        {
            return "JSON";
        }

        public List<TypeParameter> GetParameters()
        {
            return new List<TypeParameter>()
            {
                new TypeParameter()
                {
                    Name = "Path",
                    Type = "string"
                }
            };
        }

        public AccommodationParse Import(List<ValueParameter> parameters)
        {
            throw new NotImplementedException();
        }
    }
}
