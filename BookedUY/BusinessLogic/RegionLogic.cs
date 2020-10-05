using BusinessLogicInterface;
using DataAccessInterface;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

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
            try
            {
                return this.regionRepository.GetAll();
            }
            catch (Exception) 
            {
                Console.WriteLine("Error GetAll");
                return null;
            };
        }

        public Region GetRegion(int id)
        {

            var ret =  this.regionRepository.GetById(id);
            if (ret == null)
            {
                throw
            }
            else
            {

            }
        }
    }
}
