using DataAccessInterface;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Tests
{
    [TestClass]
    public class BookingLogicTest
    {
        [TestMethod]
        public void GetAllBookingsTest()
        {
            List<Booking> bookings = new List<Booking>();
            var mockBooking = new Mock<IBookingRepository>(MockBehavior.Strict);
            mockBooking.Setup(p => p.GetAll()).Returns(bookings);
            var mockTourist = new Mock<ITouristRepository>(MockBehavior.Strict);
            var mockAccommodation = new Mock<IAccommodationRepository>(MockBehavior.Strict);
            var mockTouristicSpot = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            var logic = new BookingLogic(mockBooking.Object, mockAccommodation.Object, mockTourist.Object, mockTouristicSpot.Object);

            var result = logic.GetAll();

            mockBooking.VerifyAll();
            Assert.IsTrue(result.SequenceEqual(bookings));
        }

        [TestMethod]
        public void AddBookingsTest() 
        { 
            List<Guest> guests = new List<Guest>();
            Guest guest = new Guest()
            {
                Amount = 2,
                Multiplier = 0.5
            };
            guests.Add(guest);
            Booking booking = new Booking()
            {
                Id = 9,
                Guests = guests,
                AccommodationId = 3,
                BookingHistory= new List<BookingStage>()                
            };
            Tourist tourist = new Tourist()
            {
                Email = "a@a.com",
                Id = 4
            };
            booking.HeadGuest = tourist;
            Accommodation accommodation = new Accommodation()
            {
                Id = 7,
                Name = "a"
            };
            BookingStage bookingStage = new BookingStage()
            {
                AdministratorId = 1,
                Status = Status.Received
            };
            booking.BookingHistory.Add(bookingStage);
            var mockBooking = new Mock<IBookingRepository>(MockBehavior.Strict);
            mockBooking.Setup(p => p.Add(It.IsAny<Booking>())).Returns(booking);
            var mockTourist = new Mock<ITouristRepository>(MockBehavior.Strict);
            mockTourist.Setup(p => p.GetByEmail(It.IsAny<string>())).Returns(tourist);
            var mockAccommodation = new Mock<IAccommodationRepository>(MockBehavior.Strict);
            mockAccommodation.Setup(p => p.GetById(It.IsAny<int>())).Returns(accommodation);
            var mockTouristicSpot = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            var logic = new BookingLogic(mockBooking.Object, mockAccommodation.Object, mockTourist.Object, mockTouristicSpot.Object);

            var result = logic.AddBooking(booking);

            mockBooking.VerifyAll();
            Assert.IsTrue(result.Equals(booking));
        }



        [ExpectedException(typeof(NullInputException))]
        [TestMethod]
        public void AddBookingsNullInputTest()
        {
            Booking booking = new Booking()
            {
                Id = 9,
                Guests = null,
                AccommodationId = 3
            };
            Tourist tourist = new Tourist()
            {
                Email = "a@a.com",
                Id = 4
            };
            Accommodation accommodation = new Accommodation()
            {
                Id = 7,
                Name = "a"
            };
            var mockBooking = new Mock<IBookingRepository>(MockBehavior.Strict);
            mockBooking.Setup(p => p.Add(It.IsAny<Booking>())).Returns(booking);
            var mockTourist = new Mock<ITouristRepository>(MockBehavior.Strict);
            mockTourist.Setup(p => p.GetByEmail(It.IsAny<string>())).Returns(tourist);
            var mockAccommodation = new Mock<IAccommodationRepository>(MockBehavior.Strict);
            mockAccommodation.Setup(p => p.GetById(It.IsAny<int>())).Returns(accommodation);
            var mockTouristicSpot = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            var logic = new BookingLogic(mockBooking.Object, mockAccommodation.Object, mockTourist.Object, mockTouristicSpot.Object);

            var result = logic.AddBooking(booking);
        }

        [ExpectedException(typeof(NullInputException))]
        [TestMethod]
        public void AddBookingsNullInputTest2()
        {
            Booking booking = new Booking()
            {
                Id = 9,
                Guests = null,
                AccommodationId = 0
            };
            Tourist tourist = new Tourist()
            {
                Email = "a@a.com",
                Id = 4
            };
            Accommodation accommodation = new Accommodation()
            {
                Id = 7,
                Name = "a"
            };
            var mockBooking = new Mock<IBookingRepository>(MockBehavior.Strict);
            mockBooking.Setup(p => p.Add(It.IsAny<Booking>())).Returns(booking);
            var mockTourist = new Mock<ITouristRepository>(MockBehavior.Strict);
            mockTourist.Setup(p => p.GetByEmail(It.IsAny<string>())).Returns(tourist);
            var mockAccommodation = new Mock<IAccommodationRepository>(MockBehavior.Strict);
            mockAccommodation.Setup(p => p.GetById(It.IsAny<int>())).Returns(accommodation);
            var mockTouristicSpot = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            var logic = new BookingLogic(mockBooking.Object, mockAccommodation.Object, mockTourist.Object, mockTouristicSpot.Object);

            var result = logic.AddBooking(booking);
        }

        [ExpectedException(typeof(NullInputException))]
        [TestMethod]
        public void AddBookingsNullInputTest3()
        {
            Guest guest = new Guest()
            {
                Id = 7
            };
            List<Guest> list = new List<Guest>();
            list.Add(guest);
            Booking booking = new Booking()
            {
                Id = 9,
                Guests = list,
                AccommodationId = 0
            };
            Tourist tourist = new Tourist()
            {
                Email = "a@a.com",
                Id = 4
            };
            Accommodation accommodation = new Accommodation()
            {
                Id = 7,
                Name = "a"
            };
            var mockBooking = new Mock<IBookingRepository>(MockBehavior.Strict);
            mockBooking.Setup(p => p.Add(It.IsAny<Booking>())).Returns(booking);
            var mockTourist = new Mock<ITouristRepository>(MockBehavior.Strict);
            mockTourist.Setup(p => p.GetByEmail(It.IsAny<string>())).Returns(tourist);
            var mockAccommodation = new Mock<IAccommodationRepository>(MockBehavior.Strict);
            mockAccommodation.Setup(p => p.GetById(It.IsAny<int>())).Returns(accommodation);
            var mockTouristicSpot = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            var logic = new BookingLogic(mockBooking.Object, mockAccommodation.Object, mockTourist.Object, mockTouristicSpot.Object);

            var result = logic.AddBooking(booking);
        }

        [ExpectedException(typeof(NotFoundException))]
        [TestMethod]
        public void AddBookingsNullInputTest4()
        {
            Guest guest = new Guest()
            {
                Id = 7
            };
            List<Guest> list = new List<Guest>();
            list.Add(guest);
            Booking booking = new Booking()
            {
                Id = 9,
                Guests = list,
                AccommodationId = 4
            };
            Tourist tourist = new Tourist()
            {
                Email = "a@a.com",
                Id = 4
            };
            Accommodation accommodation = new Accommodation()
            {
                Id = 7,
                Name = "a"
            };
            var mockBooking = new Mock<IBookingRepository>(MockBehavior.Strict);
            mockBooking.Setup(p => p.Add(It.IsAny<Booking>())).Returns(booking);
            var mockTourist = new Mock<ITouristRepository>(MockBehavior.Strict);
            mockTourist.Setup(p => p.GetByEmail(It.IsAny<string>())).Returns(tourist);
            var mockAccommodation = new Mock<IAccommodationRepository>(MockBehavior.Strict);
            mockAccommodation.Setup(p => p.GetById(It.IsAny<int>())).Returns<Accommodation>(null);
            var mockTouristicSpot = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            var logic = new BookingLogic(mockBooking.Object, mockAccommodation.Object, mockTourist.Object, mockTouristicSpot.Object);

            var result = logic.AddBooking(booking);
        }

        [TestMethod]
        public void GetReportTest()
        {
            ReportTuple reportTuple = new ReportTuple()
            {
                Id=1,
                Count=1
            };
            ReportTupleReturn reportTuplerReturn = new ReportTupleReturn 
            { 
                AccommodationName = "a", Count = 1 
            };
            TouristicSpot touristicSpot = new TouristicSpot()
            {
                Id=4,
                Name = "a"
            };
            Accommodation accommodation = new Accommodation()
            {
                Id = 1,
                Name = "a"
            };
            IList<ReportTuple> listReport = new List<ReportTuple>
            {
                reportTuple
            };
            List<ReportTupleReturn> listReturn = new List<ReportTupleReturn>();
            listReturn.Add(reportTuplerReturn);
            var mockBooking = new Mock<IBookingRepository>(MockBehavior.Strict);
            var mockTourist = new Mock<IAccommodationRepository>(MockBehavior.Strict);
            var mockAccommodation = new Mock<ITouristRepository>(MockBehavior.Strict);
            var mockTouristicSpot = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            mockBooking.Setup(p => p.GetReport(It.IsAny<int>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(listReport);
            mockTouristicSpot.Setup(p => p.GetByName(It.IsAny<string>())).Returns(touristicSpot);
            mockTourist.Setup(p => p.GetById(It.IsAny<int>())).Returns(accommodation);
            var controller = new BookingLogic(mockBooking.Object, mockTourist.Object, mockAccommodation.Object, mockTouristicSpot.Object);

            var result = controller.GetReport("a", new DateTime(2020, 01, 20), new DateTime(2020, 02, 20));

            mockBooking.VerifyAll();
            Assert.AreEqual(result[0].AccommodationName, listReturn[0].AccommodationName);
        }
    }
}