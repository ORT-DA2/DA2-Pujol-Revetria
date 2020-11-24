using ImportInterface;
using ImportInterface.Parse;
using System;
using System.Collections.Generic;
using System.Xml;

namespace ImporterXML
{
    public class ImporterXML : IImport
    {
        public string GetName()
        {
            return "XML";
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
            var accommodationParse = new AccommodationParse();
            var xmlReader = XmlReader.Create(path);
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(AccommodationParse));
            accommodationParse = (AccommodationParse)serializer.Deserialize(xmlReader);
            xmlReader.Close();
            return accommodationParse;
        }
    }
}

