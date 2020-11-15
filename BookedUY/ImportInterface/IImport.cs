using ImportInterface.Parse;
using System;
using System.Collections.Generic;

namespace ImportInterface
{
    public interface IImport
    {
        string GetName();
        List<TypeParameter> GetParameters();
        AccommodationParse Import(List<ValueParameter> parameters);
    }
}
