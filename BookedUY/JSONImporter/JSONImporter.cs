using ImportInterface;
using ImportInterface.Parse;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace JSONImporter
{
    public class JSONImporter : IImport
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
            //Codigo para parsear
            return new AccommodationParse();
        }
    }
}
