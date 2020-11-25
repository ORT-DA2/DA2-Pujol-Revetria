using ImportInterface;
using System.Collections.Generic;

namespace BusinessLogicInterface
{
    public class ImporterModel
    {
        public string Name { get; set; }
        public List<ValueParameter> Parameters { get; set; }
    }
}
