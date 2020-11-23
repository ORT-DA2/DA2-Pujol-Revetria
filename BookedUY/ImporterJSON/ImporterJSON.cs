using ImportInterface;
using ImportInterface.Parse;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

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
            string path = parameters[0].Value;
            AccommodationParse accommodationParse = JsonConvert.DeserializeObject<AccommodationParse>(File.ReadAllText(@path));
            return accommodationParse;


            /* StreamReader sr = new StreamReader(path);
            string jsonString = sr.ReadToEnd();
            JavaScriptSerializer ser = new JavaScriptSerializer();
            AccommodationParse accommodation = ser.Deserialize<AccommodationParse>(jsonString);
            return accommodation;*/

        }
    }
}
