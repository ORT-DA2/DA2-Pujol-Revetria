using BusinessLogicInterface;
using DataAccessInterface;
using Domain;
using ImportInterface;
using ImportInterface.Parse;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using WebApi.DTOs;

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
            string directoryDll = Directory.GetCurrentDirectory();
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(directoryDll)
            .AddJsonFile("appsettings.json")
            .Build();
            var connectionString = configuration.GetSection(@"Path").GetChildren().FirstOrDefault().Value;
            string configurationPath = connectionString;

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

        private void CheckTouristicSpot(TouristicSpotParse touristicSpotParse)
        {
            if (touristicSpotParse == null)
            {
                throw new NullInputException("Touristic Spot");
            }
        }

        private void CheckRegion(int id)
        {
            if (regionRepository.GetById(id) == null )
            {
                throw new NotFoundException("Region");
            }
        }

        private void CheckCategories(List<int> categories)
        {
            foreach (int categoryId in categories)
            {
                if (categoryRepository.GetById(categoryId) == null)
                {
                    throw new NotFoundException("Category");
                }
            }
        }

        private void CheckAccommodation(string name)
        {
            if (accommodationRepository.GetByName(name) != null)
            {
                throw new AlreadyExistsException("Accommodation name");
            }
        }

        public AccommodationModelOut Import(ImporterModel import)
        {
            var implementation = ObtainImplementation(import.Name);
            var parse = implementation.Import(import.Parameters);
            CheckTouristicSpot(parse.TouristicSpot);
            CheckRegion(parse.TouristicSpot.RegionId);
            CheckCategories(parse.TouristicSpot.Categories);
            CheckAccommodation(parse.Name);
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
            Accommodation accommodation = this.accommodationRepository.Add(new Accommodation()
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
            return new AccommodationModelOut(accommodation, (0, new List<Review>()));  
        }

        public List<TypeParameter> GetParameters(string name)
        {
            return ObtainImplementation(name).GetParameters();
        }

        private IImport ObtainImplementation(string name)
        {
            List<string> names = new List<string>();
            string directoryDll = Directory.GetCurrentDirectory();
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(directoryDll)
            .AddJsonFile("appsettings.json")
            .Build();
            var connectionString = configuration.GetSection(@"Path").GetChildren().FirstOrDefault().Value;
            string configurationPath = connectionString;//No Hardcoded, relative path

            var directory = new DirectoryInfo(configurationPath);
            FileInfo[] files = directory.GetFiles("*.dll");
            foreach (var file in files)
            {
                Assembly assemblyLoaded = Assembly.LoadFile(file.FullName);
                var loadedImplementation = assemblyLoaded.GetTypes().Where(t => typeof(IImport).IsAssignableFrom(t) && t.IsClass).FirstOrDefault();

                if (loadedImplementation == null)
                {
                    throw new NotFoundException("Importer");
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
                        throw new NotFoundException($"Importer with name {name}");
                    }
                }
            }
            throw new NotFoundException("dll");
        }
    }
}