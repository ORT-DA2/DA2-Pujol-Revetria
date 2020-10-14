using BusinessLogicInterface;
using DataAccessInterface;
using Domain;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class RegionLogic : IRegionLogic
    {
        private readonly IRepository<Region> regionRepository;

        public RegionLogic(IRepository<Region> regionRepository)
        {
            this.regionRepository = regionRepository;
        }

        public IEnumerable<Region> GetRegions()
        {
            return this.regionRepository.GetAll();
        }

        //public Region GetRegion(int id)
        //{
        //    var ret =  this.regionRepository.GetById(id);
        //    if (ret == null)
        //    {
        //    }
        //    else
        //    {
        //    }
        //}
    }
}