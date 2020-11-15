using Domain;
using ImportInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicInterface
{
    public interface IImporterLogic
    {
        List<string> GetNames();
        List<TypeParameter> GetParameters(string name);
        Accommodation Import(ImporterModel import);
    }
}
