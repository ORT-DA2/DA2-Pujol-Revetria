using DataAccessInterface;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace BusinessLogic.Tests
{
    [TestClass]
    public class BookingStageLogicTest
    {
        [TestMethod]
        public void AddBookingStageTest()
        {
            int testId = 5;
            Booking booking = new Booking();
            booking.Id = 7;
            BookingStage bookingStage = new BookingStage();
            bookingStage.Id = testId;
            bookingStage.AsociatedBookingId = 7;
            Administrator admin = new Administrator()
            {
                Email = "a@a.com",
                Password = "3",
                Id = 4,
            };
            bookingStage.AdministratorId = 4;
            var mock = new Mock<IBookingStageRepository>(MockBehavior.Strict);
            mock.Setup(p => p.Add(It.IsAny<BookingStage>())).Returns(bookingStage);
            var mock2 = new Mock<IBookingRepository>(MockBehavior.Strict);
            mock2.Setup(u => u.GetById(It.IsAny<int>())).Returns(booking);
            var mock3 = new Mock<IAdministratorRepository>(MockBehavior.Strict);
            mock3.Setup(u => u.GetById(It.IsAny<int>())).Returns(admin);
            var logic = new BookingStageLogic(mock.Object, mock2.Object,mock3.Object);
            var result = logic.AddBookingStage(bookingStage);
            mock.VerifyAll();
            mock2.VerifyAll();
            mock3.VerifyAll();
            Assert.IsTrue(result.Equals(bookingStage));
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void AddBookingStageExceptionTest()
        {
            int testId = 5;
            Booking booking = new Booking();
            booking.Id = 7;
            BookingStage bookingStage = new BookingStage();
            bookingStage.Id = testId;
            bookingStage.AsociatedBookingId = 5;
            Administrator admin = new Administrator()
            {
                Email = "a@a.com",
                Password = "3",
                Id = 4,
            };
            bookingStage.AdministratorId = 4;
            var mock = new Mock<IBookingStageRepository>(MockBehavior.Strict);
            mock.Setup(p => p.Add(It.IsAny<BookingStage>())).Returns(bookingStage);
            var mock2 = new Mock<IBookingRepository>(MockBehavior.Strict);
            mock2.Setup(u => u.GetById(It.IsAny<int>())).Returns<Booking>(null);
            var mock3 = new Mock<IAdministratorRepository>(MockBehavior.Strict);
            mock3.Setup(u => u.GetById(It.IsAny<int>())).Returns(admin);
            var logic = new BookingStageLogic(mock.Object, mock2.Object, mock3.Object);
            var result = logic.AddBookingStage(bookingStage);
            mock.VerifyAll();
            mock2.VerifyAll();
            mock3.VerifyAll();
            Assert.IsTrue(result.Equals(bookingStage));
        }

        [TestMethod]
        public void GetCurrentStatusByBookingTest()
        {
            int testId = 5;
            Booking booking = new Booking();
            booking.Id = 7;
            BookingStage bookingStage = new BookingStage();
            bookingStage.Id = testId;
            bookingStage.AsociatedBookingId = 7;
            List<BookingStage> bookingStages = new List<BookingStage>();
            bookingStages.Add(bookingStage);
            Administrator admin = new Administrator()
            {
                Email = "a@a.com",
                Password = "3",
                Id = 4,
            };
            bookingStage.AdministratorId = 4;
            var mock = new Mock<IBookingStageRepository>(MockBehavior.Strict);
            mock.Setup(p => p.GetByBooking(It.IsAny<int>())).Returns(bookingStages);
            var mock2 = new Mock<IBookingRepository>(MockBehavior.Strict);
            var mock3 = new Mock<IAdministratorRepository>(MockBehavior.Strict);
            mock3.Setup(u => u.GetById(It.IsAny<int>())).Returns(admin);
            var logic = new BookingStageLogic(mock.Object, mock2.Object, mock3.Object);
            var result = logic.GetCurrentStatusByBooking(7);
            mock.VerifyAll();
            mock2.VerifyAll();
            mock3.Verify();
            Assert.IsTrue(result.Equals(bookingStage));
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void AddBookingStageException2Test()
        {
            int testId = 5;
            Booking booking = new Booking();
            booking.Id = 7;
            BookingStage bookingStage = new BookingStage();
            bookingStage.Id = testId;
            bookingStage.AsociatedBookingId = 0;
            Administrator admin = new Administrator()
            {
                Email = "a@a.com",
                Password = "3",
                Id = 4,
            };
            bookingStage.AdministratorId = 4;
            var mock = new Mock<IBookingStageRepository>(MockBehavior.Strict);
            mock.Setup(p => p.Add(It.IsAny<BookingStage>())).Returns(bookingStage);
            var mock2 = new Mock<IBookingRepository>(MockBehavior.Strict);
            mock2.Setup(u => u.GetById(It.IsAny<int>())).Returns<Booking>(null);
            var mock3 = new Mock<IAdministratorRepository>(MockBehavior.Strict);
            mock3.Setup(u => u.GetById(It.IsAny<int>())).Returns(admin);
            var logic = new BookingStageLogic(mock.Object, mock2.Object, mock3.Object);
            var result = logic.AddBookingStage(bookingStage);
            mock.VerifyAll();
            mock2.VerifyAll();
            mock3.VerifyAll();
            Assert.IsTrue(result.Equals(bookingStage));
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void AddBookingStageException3Test()
        {
            int testId = 5;
            Booking booking = new Booking();
            booking.Id = 7;
            BookingStage bookingStage = new BookingStage();
            bookingStage.Id = testId;
            bookingStage.AsociatedBookingId = 5;
            Administrator admin = new Administrator()
            {
                Email = "a@a.com",
                Password = "3",
                Id = 4,
            };
            bookingStage.AdministratorId = 4;
            var mock = new Mock<IBookingStageRepository>(MockBehavior.Strict);
            mock.Setup(p => p.Add(It.IsAny<BookingStage>())).Returns(bookingStage);
            var mock2 = new Mock<IBookingRepository>(MockBehavior.Strict);
            mock2.Setup(u => u.GetById(It.IsAny<int>())).Returns(booking);
            var mock3 = new Mock<IAdministratorRepository>(MockBehavior.Strict);
            mock3.Setup(u => u.GetById(It.IsAny<int>())).Returns<Administrator>(null);
            var logic = new BookingStageLogic(mock.Object, mock2.Object, mock3.Object);
            var result = logic.AddBookingStage(bookingStage);
            mock.VerifyAll();
            mock2.VerifyAll();
            mock3.VerifyAll();
            Assert.IsTrue(result.Equals(bookingStage));
        }
    }
}