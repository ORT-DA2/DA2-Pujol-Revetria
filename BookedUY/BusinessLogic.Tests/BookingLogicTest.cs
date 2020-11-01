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
            var mock = new Mock<IBookingRepository>(MockBehavior.Strict);
            mock.Setup(p => p.GetAll()).Returns(bookings);
            var mock2 = new Mock<ITouristRepository>(MockBehavior.Strict);
            var mock3 = new Mock<IAccommodationRepository>(MockBehavior.Strict);
            var mock4 = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            var logic = new BookingLogic(mock.Object, mock3.Object, mock2.Object, mock4.Object);
            var result = logic.GetAll();
            mock.VerifyAll();
            Assert.IsTrue(result.SequenceEqual(bookings));
        }

        [TestMethod]
        public void AddBookingsTest()
        {
            int testId = 9;
            List<Guest> guests = new List<Guest>();
            Guest guest = new Guest()
            {
                Amount = 2,
                Multiplier = 0.5
            };
            guests.Add(guest);
            Booking booking = new Booking()
            {
                Id = testId,
                Guests = guests,
                AccommodationId = 3
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
            var mock = new Mock<IBookingRepository>(MockBehavior.Strict);
            mock.Setup(p => p.Add(It.IsAny<Booking>())).Returns(booking);
            var mock2 = new Mock<ITouristRepository>(MockBehavior.Strict);
            mock2.Setup(p => p.GetByEmail(It.IsAny<string>())).Returns(tourist);
            var mock3 = new Mock<IAccommodationRepository>(MockBehavior.Strict);
            mock3.Setup(p => p.GetById(It.IsAny<int>())).Returns(accommodation);
            var mock4 = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            var logic = new BookingLogic(mock.Object, mock3.Object, mock2.Object, mock4.Object);
            var result = logic.AddBooking(booking);
            mock.VerifyAll();
            Assert.IsTrue(result.Equals(booking));
        }



        [ExpectedException(typeof(NullInputException))]
        [TestMethod]
        public void AddBookingsNullInputTest()
        {
            int testId = 9;
            Booking booking = new Booking()
            {
                Id = testId,
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
            var mock = new Mock<IBookingRepository>(MockBehavior.Strict);
            mock.Setup(p => p.Add(It.IsAny<Booking>())).Returns(booking);
            var mock2 = new Mock<ITouristRepository>(MockBehavior.Strict);
            mock2.Setup(p => p.GetByEmail(It.IsAny<string>())).Returns(tourist);
            var mock3 = new Mock<IAccommodationRepository>(MockBehavior.Strict);
            mock3.Setup(p => p.GetById(It.IsAny<int>())).Returns(accommodation);
            var mock4 = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            var logic = new BookingLogic(mock.Object, mock3.Object, mock2.Object, mock4.Object);
            var result = logic.AddBooking(booking);
            mock.VerifyAll();
            Assert.IsTrue(result.Equals(booking));
        }

        [ExpectedException(typeof(NullInputException))]
        [TestMethod]
        public void AddBookingsNullInputTest2()
        {
            int testId = 9;
            Booking booking = new Booking()
            {
                Id = testId,
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
            var mock = new Mock<IBookingRepository>(MockBehavior.Strict);
            mock.Setup(p => p.Add(It.IsAny<Booking>())).Returns(booking);
            var mock2 = new Mock<ITouristRepository>(MockBehavior.Strict);
            mock2.Setup(p => p.GetByEmail(It.IsAny<string>())).Returns(tourist);
            var mock3 = new Mock<IAccommodationRepository>(MockBehavior.Strict);
            mock3.Setup(p => p.GetById(It.IsAny<int>())).Returns(accommodation);
            var mock4 = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            var logic = new BookingLogic(mock.Object, mock3.Object, mock2.Object, mock4.Object);
            var result = logic.AddBooking(booking);
            mock.VerifyAll();
            Assert.IsTrue(result.Equals(booking));
        }

        [ExpectedException(typeof(NullInputException))]
        [TestMethod]
        public void AddBookingsNullInputTest3()
        {
            int testId = 9;
            Guest guest = new Guest()
            {
                Id = 7
            };
            List<Guest> list = new List<Guest>();
            list.Add(guest);
            Booking booking = new Booking()
            {
                Id = testId,
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
            var mock = new Mock<IBookingRepository>(MockBehavior.Strict);
            mock.Setup(p => p.Add(It.IsAny<Booking>())).Returns(booking);
            var mock2 = new Mock<ITouristRepository>(MockBehavior.Strict);
            mock2.Setup(p => p.GetByEmail(It.IsAny<string>())).Returns(tourist);
            var mock3 = new Mock<IAccommodationRepository>(MockBehavior.Strict);
            mock3.Setup(p => p.GetById(It.IsAny<int>())).Returns(accommodation);
            var mock4 = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            var logic = new BookingLogic(mock.Object, mock3.Object, mock2.Object, mock4.Object);
            var result = logic.AddBooking(booking);
            mock.VerifyAll();
            Assert.IsTrue(result.Equals(booking));
        }

        [ExpectedException(typeof(NotFoundException))]
        [TestMethod]
        public void AddBookingsNullInputTest4()
        {
            int testId = 9;
            Guest guest = new Guest()
            {
                Id = 7
            };
            List<Guest> list = new List<Guest>();
            list.Add(guest);
            Booking booking = new Booking()
            {
                Id = testId,
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
            var mock = new Mock<IBookingRepository>(MockBehavior.Strict);
            mock.Setup(p => p.Add(It.IsAny<Booking>())).Returns(booking);
            var mock2 = new Mock<ITouristRepository>(MockBehavior.Strict);
            mock2.Setup(p => p.GetByEmail(It.IsAny<string>())).Returns(tourist);
            var mock3 = new Mock<IAccommodationRepository>(MockBehavior.Strict);
            mock3.Setup(p => p.GetById(It.IsAny<int>())).Returns<Accommodation>(null);
            var mock4 = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            var logic = new BookingLogic(mock.Object, mock3.Object, mock2.Object, mock4.Object);
            var result = logic.AddBooking(booking);
            mock.VerifyAll();
            Assert.IsTrue(result.Equals(booking));
        }

        [TestMethod]
        public void GetReportTest()
        {
            string touristicSpotName = "a";
            DateTime start = new DateTime(2020, 01, 20);
            DateTime end = new DateTime(2020, 02, 20);
            ReportTuple reportTuple = new ReportTuple()
            {
                Id=1,
                Count=1
            };
            ReportTupleReturn reportTuplerReturn = new ReportTupleReturn { AccommodationName = "a", Count = 1 };
            TouristicSpot touristicSpot = new TouristicSpot()
            {
                Id=4,
                Name = "a"
            };
            Accommodation acco = new Accommodation()
            {
                Id = 1,
                Name = "a"
            };
            IList<ReportTuple> list = new List<ReportTuple>();
            list.Add(reportTuple);
            List<ReportTupleReturn> listReturn = new List<ReportTupleReturn>();
            listReturn.Add(reportTuplerReturn);
            var mock = new Mock<IBookingRepository>(MockBehavior.Strict);
            var mock2 = new Mock<IAccommodationRepository>(MockBehavior.Strict);
            var mock3 = new Mock<ITouristRepository>(MockBehavior.Strict);
            var mock4 = new Mock<ITouristicSpotRepository>(MockBehavior.Strict);
            mock.Setup(p => p.GetReport(It.IsAny<int>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(list);
            mock4.Setup(p => p.GetByName(It.IsAny<string>())).Returns(touristicSpot);
            mock2.Setup(p => p.GetById(It.IsAny<int>())).Returns(acco);
            var controller = new BookingLogic(mock.Object, mock2.Object, mock3.Object, mock4.Object);
            var result = controller.GetReport(touristicSpotName, start, end);
            mock.VerifyAll();
            Assert.AreEqual(result[0].AccommodationName, listReturn[0].AccommodationName);
        }
    }
}