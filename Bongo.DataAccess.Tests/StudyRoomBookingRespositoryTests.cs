using Bongo.DataAccess.Repository;
using Bongo.Models.Model;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Bongo.DataAccess.Tests
{
    [TestFixture]
    public class StudyRoomBookingRespositoryTests
    {
        private StudyRoomBooking studyRoomBooking_One;
        private StudyRoomBooking studyRoomBooking_Two;
        private DbContextOptions<ApplicationDbContext> options;

        public StudyRoomBookingRespositoryTests()
        {
            studyRoomBooking_One = new StudyRoomBooking()
            {
                FirstName = "FirstName1",
                LastName = "LastName1",
                Date = new DateTime(2023, 1, 1),
                Email = "FirstName1@gmail.com",
                BookingId = 11,
                StudyRoomId = 1
            };

            studyRoomBooking_Two = new StudyRoomBooking()
            {
                FirstName = "FirstName2",
                LastName = "LastName2",
                Date = new DateTime(2023, 2, 2),
                Email = "FirstName2@gmail.com",
                BookingId = 22,
                StudyRoomId = 2
            };

        }

        [SetUp]
        public void Setup()
        {
            // Arrange - We create an in-memory Database
            options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "temp_Bongo").Options;
        }

        [Test]
        [Order(1)] // Order(1) means execute this test first.
        public void BookingPersistedToDb()
        {
            // Act - We add an entry to the database
            using (var context = new ApplicationDbContext(options)) 
            {
                var repository = new StudyRoomBookingRepository(context);
                repository.Book(studyRoomBooking_One);
            }
            // Assert - We made sure everything was added successfully.
            using (var context = new ApplicationDbContext(options))
            {
                var bookingfromDb = context.StudyRoomBookings.FirstOrDefault(u => u.BookingId==11);
                Assert.AreEqual(studyRoomBooking_One.BookingId, bookingfromDb.BookingId);
                Assert.AreEqual(studyRoomBooking_One.FirstName, bookingfromDb.FirstName);
                Assert.AreEqual(studyRoomBooking_One.LastName, bookingfromDb.LastName);
                Assert.AreEqual(studyRoomBooking_One.Email, bookingfromDb.Email);
                Assert.AreEqual(studyRoomBooking_One.Date, bookingfromDb.Date);
            }
        }

        [Test]
        [Order(2)]
        public void AllBookingsPersistedToDb() // GetAll()
        {
            // Arrange - We add All Bookings

            var expected = new List<StudyRoomBooking> { studyRoomBooking_One, studyRoomBooking_Two };

            using (var context = new ApplicationDbContext(options))
            {
                context.Database.EnsureDeleted(); // we must delete the records from the previous
                // test else there will be problems when running Book(studyRoomBooking_One) below.
                var repository = new StudyRoomBookingRepository(context);
                repository.Book(studyRoomBooking_One);
                repository.Book(studyRoomBooking_Two);
            }

            // Act - Get All Bookings
            List<StudyRoomBooking> result;
            
            using (var context = new ApplicationDbContext(options))
            {
                var repository = new StudyRoomBookingRepository(context);
                result = repository.GetAll(null).ToList();
            }

            // Assert - We made sure everything was added successfully.
            // We use CollectionAssert to use BookingCompare
            // Booking Compare compares objects, so it compares the expected list
            // with the two bookings, with the result list using the GetAll() method
            CollectionAssert.AreEqual(expected, result, new BookingCompare());    
        }

        // this is a class
        private class BookingCompare : IComparer 
        {
            public int Compare(object x, object y)
            {
                var booking1 = (StudyRoomBooking)x;
                var booking2 = (StudyRoomBooking)y;

                if (booking1.BookingId != booking2.BookingId)
                {
                    return 1;
                } else
                {
                    return 0;
                }
            }
        }

    }
}
