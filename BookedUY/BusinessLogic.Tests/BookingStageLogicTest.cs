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
            Booking booking = new Booking
            {
                Id = 7
            };
            BookingStage bookingStage = new BookingStage
            {
                Id = 5,
                AsociatedBookingId = 7
            };
            Administrator administrator = new Administrator()
            {
                Email = "a@a.com",
                Password = "3",
                Id = 4,
            };
            bookingStage.AdministratorId = 4;
            var mockBookingStage = new Mock<IBookingStageRepository>(MockBehavior.Strict);
            mockBookingStage.Setup(p => p.AddAndSave(It.IsAny<BookingStage>())).Returns(bookingStage);
            var mockBooking = new Mock<IBookingRepository>(MockBehavior.Strict);
            mockBooking.Setup(u => u.GetById(It.IsAny<int>())).Returns(booking);
            var mockAdministrator = new Mock<IAdministratorRepository>(MockBehavior.Strict);
            mockAdministrator.Setup(u => u.GetById(It.IsAny<int>())).Returns(administrator);
            var logic = new BookingStageLogic(mockBookingStage.Object, mockBooking.Object,mockAdministrator.Object);

            var result = logic.AddBookingStage(bookingStage);

            mockBookingStage.VerifyAll();
            mockBooking.VerifyAll();
            mockAdministrator.VerifyAll();
            Assert.IsTrue(result.Equals(bookingStage));
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void AddBookingStageExceptionTest()
        {
            Booking booking = new Booking
            {
                Id = 7
            };
            BookingStage bookingStage = new BookingStage
            {
                Id = 5,
                AsociatedBookingId = 5
            };
            Administrator administrator = new Administrator()
            {
                Email = "a@a.com",
                Password = "3",
                Id = 4,
            };
            bookingStage.AdministratorId = 4;
            var mockBookingStage = new Mock<IBookingStageRepository>(MockBehavior.Strict);
            mockBookingStage.Setup(p => p.AddAndSave(It.IsAny<BookingStage>())).Returns(bookingStage);
            var mockBooking = new Mock<IBookingRepository>(MockBehavior.Strict);
            mockBooking.Setup(u => u.GetById(It.IsAny<int>())).Returns<Booking>(null);
            var mockAdministrator = new Mock<IAdministratorRepository>(MockBehavior.Strict);
            mockAdministrator.Setup(u => u.GetById(It.IsAny<int>())).Returns(administrator);
            var logic = new BookingStageLogic(mockBookingStage.Object, mockBooking.Object, mockAdministrator.Object);

            var result = logic.AddBookingStage(bookingStage);

            mockBookingStage.VerifyAll();
            mockBooking.VerifyAll();
            mockAdministrator.VerifyAll();
            Assert.IsTrue(result.Equals(bookingStage));
        }

        [TestMethod]
        public void GetCurrentStatusByBookingTest()
        {
            Booking booking = new Booking
            {
                Id = 7
            };
            BookingStage bookingStage = new BookingStage
            {
                Id = 5,
                AsociatedBookingId = 7
            };
            List<BookingStage> bookingStages = new List<BookingStage>
            {
                bookingStage
            };
            Administrator administrator = new Administrator()
            {
                Email = "a@a.com",
                Password = "3",
                Id = 4,
            };
            bookingStage.AdministratorId = 4;
            var mockBookingStage = new Mock<IBookingStageRepository>(MockBehavior.Strict);
            mockBookingStage.Setup(p => p.GetByBooking(It.IsAny<int>())).Returns(bookingStages);
            var mockBooking = new Mock<IBookingRepository>(MockBehavior.Strict);
            var mockAdministrator = new Mock<IAdministratorRepository>(MockBehavior.Strict);
            mockAdministrator.Setup(u => u.GetById(It.IsAny<int>())).Returns(administrator);
            var logic = new BookingStageLogic(mockBookingStage.Object, mockBooking.Object, mockAdministrator.Object);

            var result = logic.GetCurrentStatusByBooking(7);

            mockBookingStage.VerifyAll();
            mockBooking.VerifyAll();
            mockAdministrator.Verify();
            Assert.IsTrue(result.Equals(bookingStage));
        }

        [TestMethod]
        [ExpectedException(typeof(NullInputException))]
        public void AddBookingStageException2Test()
        {
            Booking booking = new Booking
            {
                Id = 7
            };
            BookingStage bookingStage = new BookingStage
            {
                Id = 5,
                AsociatedBookingId = 0
            };
            Administrator administrator = new Administrator()
            {
                Email = "a@a.com",
                Password = "3",
                Id = 4,
            };
            bookingStage.AdministratorId = 4;
            var mockBookingStage = new Mock<IBookingStageRepository>(MockBehavior.Strict);
            mockBookingStage.Setup(p => p.AddAndSave(It.IsAny<BookingStage>())).Returns(bookingStage);
            var mockBooking = new Mock<IBookingRepository>(MockBehavior.Strict);
            mockBooking.Setup(u => u.GetById(It.IsAny<int>())).Returns<Booking>(null);
            var mockAdministrator = new Mock<IAdministratorRepository>(MockBehavior.Strict);
            mockAdministrator.Setup(u => u.GetById(It.IsAny<int>())).Returns(administrator);
            var logic = new BookingStageLogic(mockBookingStage.Object, mockBooking.Object, mockAdministrator.Object);

            var result = logic.AddBookingStage(bookingStage);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void AddBookingStageException3Test()
        {
            Booking booking = new Booking
            {
                Id = 7
            };
            BookingStage bookingStage = new BookingStage
            {
                Id = 5,
                AsociatedBookingId = 5
            };
            Administrator administrator = new Administrator()
            {
                Email = "a@a.com",
                Password = "3",
                Id = 4,
            };
            bookingStage.AdministratorId = 4;
            var mockBookingStage = new Mock<IBookingStageRepository>(MockBehavior.Strict);
            mockBookingStage.Setup(p => p.AddAndSave(It.IsAny<BookingStage>())).Returns(bookingStage);
            var mockBooking = new Mock<IBookingRepository>(MockBehavior.Strict);
            mockBooking.Setup(u => u.GetById(It.IsAny<int>())).Returns(booking);
            var mockAdministrator = new Mock<IAdministratorRepository>(MockBehavior.Strict);
            mockAdministrator.Setup(u => u.GetById(It.IsAny<int>())).Returns<Administrator>(null);
            var logic = new BookingStageLogic(mockBookingStage.Object, mockBooking.Object, mockAdministrator.Object);

            var result = logic.AddBookingStage(bookingStage);
        }
    }
}