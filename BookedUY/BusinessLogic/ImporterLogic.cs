using BusinessLogicInterface;
using DataAccessInterface;
using Domain;
using ImportInterface;
using ImportInterface.Parse;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BusinessLogic
{
    public class ImporterLogic : IImporterLogic
    {
        private readonly IAccommodationRepository accommodationRepository;
        private readonly ITouristicSpotRepository touristicSpotRepository;
        private readonly IRepository<Region> regionRepository;
        private readonly IRepository<Category> categoryRepository;
        public ImporterLogic(IAccommodationRepository accommodationRepository, ITouristicSpotRepository touristicSpotRepository, IRepository<Region> regionRepository, IRepository<Category> categoryRepository)
        {
            this.accommodationRepository = accommodationRepository;
            this.touristicSpotRepository = touristicSpotRepository;
            this.regionRepository = regionRepository;
            this.categoryRepository = categoryRepository;
        }
        public List<string> GetNames()
        {
            List<string> names = new List<string>();
            string configurationPath = "C:/Users/seraf/Desktop/Facultad/S6/DA2/DA2-Pujol-Revetria/BookedUY/ImportInterface/bin/Debug/DLLs";

            var directory = new DirectoryInfo(configurationPath);
            FileInfo[] files = directory.GetFiles("*.dll");
            foreach (var file in files)
            {
                Assembly assemblyLoaded = Assembly.LoadFile(file.FullName);
                var loadedImplementation = assemblyLoaded.GetTypes().Where(t => typeof(IImport).IsAssignableFrom(t) && t.IsClass).FirstOrDefault();

                if (loadedImplementation == null)
                {
                    Console.WriteLine("Nadie implementa la interfaz: {0} en el assembly: {1}", nameof(IImport), file.FullName);
                }
                else
                {
                    var implementation = Activator.CreateInstance(loadedImplementation) as IImport;
                    names.Add(implementation.GetName());
                }
            }
            return names;
        }

        public Accommodation Import(ImporterModel import)
        {
            var implementation = ObtainImplementation(import.Name);
            var parse = implementation.Import(import.Parameters);
            if(parse.TouristicSpot == null)
            {
                throw new NullInputException("Touristic Spot");
            }
            if (regionRepository.GetById(parse.TouristicSpot.RegionId) == null )
            {
                throw new NotFoundException("Region");
            }
            foreach (int categoryId in parse.TouristicSpot.Categories)
            {
                if(categoryRepository.GetById(categoryId) == null)
                {
                    throw new NotFoundException("Category");
                }
            }
            if (accommodationRepository.GetByName(parse.Name)!= null)
            {
                throw new AlreadyExistsException("Accommodation name");
            }
            var touristicSpot = touristicSpotRepository.GetByName(parse.TouristicSpot.Name);
            if (touristicSpot == null)
            {
                List<CategoryTouristicSpot> categoryTouristicSpots = new List<CategoryTouristicSpot>();
                foreach (int category in parse.TouristicSpot.Categories)
                {
                    categoryTouristicSpots.Add(new CategoryTouristicSpot()
                    {
                        CategoryId = category
                    });

                }

                touristicSpot = new TouristicSpot()
                {
                    Categories = categoryTouristicSpots,
                    Description = parse.TouristicSpot.Description,
                    Image = parse.TouristicSpot.Image,
                    Name = parse.TouristicSpot.Name,
                    RegionId = parse.TouristicSpot.RegionId
                };
                touristicSpotRepository.Add(touristicSpot);
                touristicSpot = touristicSpotRepository.GetByName(parse.TouristicSpot.Name);
            }


            List<AccommodationImage> accommodationImages = new List<AccommodationImage>();
            foreach (AccommodationImageParse accommodationImage in parse.Images)
            {
                accommodationImages.Add(new AccommodationImage()
                {
                    Image = accommodationImage.Image
                });
            }
            return this.accommodationRepository.Add(new Accommodation()
            {
                Address = parse.Address,
                ContactNumber = parse.ContactNumber,
                Full = parse.Full,
                Information = parse.Information,
                Name = parse.Name,
                PricePerNight = parse.PricePerNight,
                Images = accommodationImages,
                Spot = touristicSpot
            });  
        }

        public List<TypeParameter> GetParameters(string name)
        {
            return ObtainImplementation(name).GetParameters();
        }

        private IImport ObtainImplementation(string name)
        {
            List<string> names = new List<string>();
            string configurationPath = "C:/Users/seraf/Desktop/Facultad/S6/DA2/DA2-Pujol-Revetria/BookedUY/ImportInterface/bin/Debug/DLLs";

            var directory = new DirectoryInfo(configurationPath);
            FileInfo[] files = directory.GetFiles("*.dll");
            foreach (var file in files)
            {
                Assembly assemblyLoaded = Assembly.LoadFile(file.FullName);
                var loadedImplementation = assemblyLoaded.GetTypes().Where(t => typeof(IImport).IsAssignableFrom(t) && t.IsClass).FirstOrDefault();

                if (loadedImplementation == null)
                {
                    throw new NotFoundException("no importer");
                }
                else
                {
                    var implementation = Activator.CreateInstance(loadedImplementation) as IImport;
                    if (implementation.GetName() == name)
                    {
                        return implementation;
                    }
                    else
                    {
                        throw new NotFoundException($"no importer, {name}");
                    }
                }
            }
            throw new NotFoundException("no dll");
        }
    }
}