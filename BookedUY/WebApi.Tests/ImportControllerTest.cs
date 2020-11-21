using BusinessLogicInterface;
using Domain;
using ImportInterface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Controllers;
using WebApi.DTOs;

namespace WebApi.Tests
{
    [TestClass]
    public class ImportControllerTest
    {
        [TestMethod]
        public void GetTest()
        {
            List<string> names = new List<string>()
            {
                "Test"
            };
            var mockImporter = new Mock<IImporterLogic>(MockBehavior.Strict);
            mockImporter.Setup(p => p.GetNames()).Returns(names);
            var controller = new ImportController(mockImporter.Object);

            controller.Get();

            mockImporter.VerifyAll();
        }

        [TestMethod]
        public void GetParametersTest()
        {
            List<string> names = new List<string>()
            {
                "Test"
            };

            List<TypeParameter> listParameters = new List<TypeParameter>()
            {
                new TypeParameter()
                {
                    Name = "Path",
                    Type = "string"
                }
            };

            var mockImporter = new Mock<IImporterLogic>(MockBehavior.Strict);
            mockImporter.Setup(p => p.GetParameters(It.IsAny<string>())).Returns(listParameters);
            var controller = new ImportController(mockImporter.Object);

            controller.GetParameters("Test");

            mockImporter.VerifyAll();
        }

        [TestMethod]
        public void ImportTest()
        {
            List<string> names = new List<string>()
            {
                "Test"
            };
            List<TypeParameter> listParameters = new List<TypeParameter>()
            {
                new TypeParameter()
                {
                    Name = "Path",
                    Type = "string"
                }
            };
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
            AccommodationModelOut accommodationModelOut = new AccommodationModelOut(accommodation, (0, new List<Review>()));
            var mockImporter = new Mock<IImporterLogic>(MockBehavior.Strict);
            mockImporter.Setup(p => p.Import(It.IsAny<ImporterModel>())).Returns(accommodationModelOut);
            var controller = new ImportController(mockImporter.Object);

            controller.Post(importerModel);

            mockImporter.VerifyAll();
        }
    }
}
