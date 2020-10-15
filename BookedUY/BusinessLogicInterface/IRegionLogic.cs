using Domain;
using System.Collections.Generic;

namespace BusinessLogicInterface
{
    public interface IRegionLogic
    {
        IEnumerable<Region> GetRegions();
    }
}