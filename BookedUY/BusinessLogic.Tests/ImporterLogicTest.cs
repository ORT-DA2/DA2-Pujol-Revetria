using DataAccessInterface;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using ImportInterface;
using BusinessLogicInterface;

namespace BusinessLogic.Tests
{
    [TestClass]
    public class ImporterLogicTest
    {
        [TestMethod]
        public void GetNamesTest()
        {
            List<string> expected = new List<string>()
            {
                "Test"
            };

            var mockAccommodation = new Mock<IAccommodationRepository>(MockBehavior.Strict);
            var mockTouristicSpot = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            var mockRegion = new Mock<IRepository<Region>>(MockBehavior.Strict);
            var mockCategory = new Mock<IRepository<Category>>(MockBehavior.Strict);
            var logic = new ImporterLogic(mockAccommodation.Object, mockTouristicSpot.Object, mockRegion.Object, mockCategory.Object);

            Assert.IsTrue(expected.SequenceEqual(logic.GetNames()));
        }

        [TestMethod]
        public void GetParametersTest()
        {
            List<TypeParameter> expected = new List<TypeParameter>()
            {
                new TypeParameter()
                {
                    Name = "Path",
                    Type = "string"
                }
            };

            var mockAccommodation = new Mock<IAccommodationRepository>(MockBehavior.Strict);
            var mockTouristicSpot = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            var mockRegion = new Mock<IRepository<Region>>(MockBehavior.Strict);
            var mockCategory = new Mock<IRepository<Category>>(MockBehavior.Strict);
            var logic = new ImporterLogic(mockAccommodation.Object, mockTouristicSpot.Object, mockRegion.Object, mockCategory.Object);
            var result = logic.GetParameters("Test");
            Assert.IsTrue(expected.SequenceEqual(result));
        }

        [TestMethod]
        public void ImportTestWithNewTouristicSpot()
        {
            ImporterModel importerModel = new ImporterModel()
            {
                Name = "Test",
                Parameters = new List<ValueParameter>()
                {
                    new ValueParameter()
                    {
                        Name = "Path",
                        Value = "Path test"
                    }
                }
            };

            Region region = new Region()
            {
                Id = 1,
                Name = "Region name"
            };

            Category category = new Category()
            {
                Id = 1,
                Name = "Category name"
            };

            TouristicSpot touristicSpot = new TouristicSpot()
            {
                Name = "TouristicSpot name",
                Description = "TouristicSpot description",
                Image = "TouristicSpot image",
                RegionId = 1,
                Categories = new List<CategoryTouristicSpot>() {
                    new CategoryTouristicSpot()
                    {
                        CategoryId = 1
                    }
                }
            };

            Accommodation accommodation = new Accommodation()
            {
                Name = "Accommodation name",
                Address = "Accommodation address",
                ContactNumber = "Accommodation contactNumber",
                Full = false,
                Images = new List<AccommodationImage>()
                {
                    new AccommodationImage()
                    {
                        Image="AccommodationImage image"
                    }
                },
                Information = "Accommodation information",
                PricePerNight = 1
            };

            var mockAccommodation = new Mock<IAccommodationRepository>(MockBehavior.Strict);
            mockAccommodation.Setup(p => p.GetByName(It.IsAny<string>())).Returns<Accommodation>(null);
            mockAccommodation.Setup(p => p.Add(It.IsAny<Accommodation>())).Returns(accommodation);
            var mockTouristicSpot = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            mockTouristicSpot.SetupSequence(p => p.GetByName(It.IsAny<string>())).Returns((TouristicSpot)null).Returns(touristicSpot);
            mockTouristicSpot.Setup(p => p.Add(It.IsAny<TouristicSpot>())).Returns(touristicSpot);
            var mockRegion = new Mock<IRepository<Region>>(MockBehavior.Strict);
            mockRegion.Setup(p => p.GetById(It.IsAny<int>())).Returns(region);
            var mockCategory = new Mock<IRepository<Category>>(MockBehavior.Strict);
            mockCategory.Setup(p => p.GetById(It.IsAny<int>())).Returns(category);
            var logic = new ImporterLogic(mockAccommodation.Object, mockTouristicSpot.Object, mockRegion.Object, mockCategory.Object);
            var result = logic.Import(importerModel);

            mockAccommodation.VerifyAll();
            mockCategory.VerifyAll();
            mockTouristicSpot.VerifyAll();
            mockRegion.VerifyAll();

            Assert.AreEqual(accommodation, result);
        }

        [TestMethod]
        public void ImportTestWithAlreadyExisistsTouristicSpot()
        {
            ImporterModel importerModel = new ImporterModel()
            {
                Name = "Test",
                Parameters = new List<ValueParameter>()
                {
                    new ValueParameter()
                    {
                        Name = "Path",
                        Value = "Path test"
                    }
                }
            };

            Region region = new Region()
            {
                Id = 1,
                Name = "Region name"
            };

            Category category = new Category()
            {
                Id = 1,
                Name = "Category name"
            };

            TouristicSpot touristicSpot = new TouristicSpot()
            {
                Name = "TouristicSpot name",
                Description = "TouristicSpot description",
                Image = "TouristicSpot image",
                RegionId = 1,
                Categories = new List<CategoryTouristicSpot>() {
                    new CategoryTouristicSpot()
                    {
                        CategoryId = 1
                    }
                }
            };

            Accommodation accommodation = new Accommodation()
            {
                Name = "Accommodation name",
                Address = "Accommodation address",
                ContactNumber = "Accommodation contactNumber",
                Full = false,
                Images = new List<AccommodationImage>()
                {
                    new AccommodationImage()
                    {
                        Image="AccommodationImage image"
                    }
                },
                Information = "Accommodation information",
                PricePerNight = 1
            };

            var mockAccommodation = new Mock<IAccommodationRepository>(MockBehavior.Strict);
            mockAccommodation.Setup(p => p.GetByName(It.IsAny<string>())).Returns<Accommodation>(null);
            mockAccommodation.Setup(p => p.Add(It.IsAny<Accommodation>())).Returns(accommodation);
            var mockTouristicSpot = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            mockTouristicSpot.Setup(p => p.GetByName(It.IsAny<string>())).Returns(touristicSpot);
            var mockRegion = new Mock<IRepository<Region>>(MockBehavior.Strict);
            mockRegion.Setup(p => p.GetById(It.IsAny<int>())).Returns(region);
            var mockCategory = new Mock<IRepository<Category>>(MockBehavior.Strict);
            mockCategory.Setup(p => p.GetById(It.IsAny<int>())).Returns(category);
            var logic = new ImporterLogic(mockAccommodation.Object, mockTouristicSpot.Object, mockRegion.Object, mockCategory.Object);
            var result = logic.Import(importerModel);

            mockAccommodation.VerifyAll();
            mockCategory.VerifyAll();
            mockTouristicSpot.VerifyAll();
            mockRegion.VerifyAll();

            Assert.AreEqual(accommodation, result);
        }

        [ExpectedException(typeof(NotFoundException))]
        [TestMethod]
        public void ImportTestWithNonExistentRegion()
        {
            ImporterModel importerModel = new ImporterModel()
            {
                Name = "Test",
                Parameters = new List<ValueParameter>()
                {
                    new ValueParameter()
                    {
                        Name = "Path",
                        Value = "Path test"
                    }
                }
            };

            var mockAccommodation = new Mock<IAccommodationRepository>(MockBehavior.Strict);
            var mockTouristicSpot = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            var mockRegion = new Mock<IRepository<Region>>(MockBehavior.Strict);
            mockRegion.Setup(p => p.GetById(It.IsAny<int>())).Returns<Region>(null);
            var mockCategory = new Mock<IRepository<Category>>(MockBehavior.Strict);
            var logic = new ImporterLogic(mockAccommodation.Object, mockTouristicSpot.Object, mockRegion.Object, mockCategory.Object);
            var result = logic.Import(importerModel);

            mockRegion.VerifyAll();
        }

        [ExpectedException(typeof(NotFoundException))]
        [TestMethod]
        public void ImportTestWithNonExistentCategory()
        {
            ImporterModel importerModel = new ImporterModel()
            {
                Name = "Test",
                Parameters = new List<ValueParameter>()
                {
                    new ValueParameter()
                    {
                        Name = "Path",
                        Value = "Path test"
                    }
                }
            };

            Region region = new Region()
            {
                Id = 1,
                Name = "Region name"
            };

            var mockAccommodation = new Mock<IAccommodationRepository>(MockBehavior.Strict);
            var mockTouristicSpot = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            var mockRegion = new Mock<IRepository<Region>>(MockBehavior.Strict);
            mockRegion.Setup(p => p.GetById(It.IsAny<int>())).Returns(region);
            var mockCategory = new Mock<IRepository<Category>>(MockBehavior.Strict);
            mockCategory.Setup(p => p.GetById(It.IsAny<int>())).Returns<Category>(null);
            var logic = new ImporterLogic(mockAccommodation.Object, mockTouristicSpot.Object, mockRegion.Object, mockCategory.Object);
            var result = logic.Import(importerModel);

            mockRegion.VerifyAll();
            mockCategory.VerifyAll();
        }

        [ExpectedException(typeof(AlreadyExistsException))]
        [TestMethod]
        public void ImportTestWithAlreadyExistsAccommodation()
        {
            ImporterModel importerModel = new ImporterModel()
            {
                Name = "Test",
                Parameters = new List<ValueParameter>()
                {
                    new ValueParameter()
                    {
                        Name = "Path",
                        Value = "Path test"
                    }
                }
            };

            Region region = new Region()
            {
                Id = 1,
                Name = "Region name"
            };

            Category category = new Category()
            {
                Id = 1,
                Name = "Category name"
            };

            Accommodation accommodation = new Accommodation()
            {
                Name = "Accommodation name",
                Address = "Accommodation address",
                ContactNumber = "Accommodation contactNumber",
                Full = false,
                Images = new List<AccommodationImage>()
                {
                    new AccommodationImage()
                    {
                        Image="AccommodationImage image"
                    }
                },
                Information = "Accommodation information",
                PricePerNight = 1
            };

            var mockAccommodation = new Mock<IAccommodationRepository>(MockBehavior.Strict);
            mockAccommodation.Setup(p => p.GetByName(It.IsAny<string>())).Returns(accommodation);
            var mockTouristicSpot = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            var mockRegion = new Mock<IRepository<Region>>(MockBehavior.Strict);
            mockRegion.Setup(p => p.GetById(It.IsAny<int>())).Returns(region);
            var mockCategory = new Mock<IRepository<Category>>(MockBehavior.Strict);
            mockCategory.Setup(p => p.GetById(It.IsAny<int>())).Returns(category);
            var logic = new ImporterLogic(mockAccommodation.Object, mockTouristicSpot.Object, mockRegion.Object, mockCategory.Object);
            var result = logic.Import(importerModel);

            mockAccommodation.VerifyAll();
            mockRegion.VerifyAll();
            mockCategory.VerifyAll();
        }
    }
}
