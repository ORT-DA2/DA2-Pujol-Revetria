using Domain;
using ImportInterface;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.DTOs;

namespace BusinessLogicInterface
{
    public interface IImporterLogic
    {
        List<string> GetNames();
        List<TypeParameter> GetParameters(string name);
        AccommodationModelOut Import(ImporterModel import);
    }
}
