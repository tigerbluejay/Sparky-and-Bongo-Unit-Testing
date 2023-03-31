using Bongo.Core.Services;
using Bongo.DataAccess.Repository.IRepository;
using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bongo.Models.Model;
using System.Security.Cryptography.X509Certificates;
using Bongo.Models.Model.VM;

namespace Bongo.Core.Tests
{
    [TestFixture]
    public class StudyRoomBookingServiceTests
    {
        private Mock<IStudyRoomBookingRepository> _studyRoomBookingRepoMock;
        private Mock<IStudyRoomRepository> _studyRoomRepoMock;
        private StudyRoomBookingService _bookingService;

        private StudyRoomBooking _request;
        private List<StudyRoom> _availableStudyRoom;


        [SetUp]
        public void Setup()
        {
            // these next two properties _request and _available study room
            // are for checking available rooms
            _request = new StudyRoomBooking
            {
                FirstName = "FirstName1",
                LastName = "LastName1",
                Email = "FirstName1@gmail.com",
                Date = new DateTime(2022, 1, 1)
            };

            _availableStudyRoom = new List<StudyRoom>()
            {
                new StudyRoom { Id= 10, RoomName = "Michigan", RoomNumber = "A202"}
            };

            _studyRoomBookingRepoMock = new Mock<IStudyRoomBookingRepository>();
            _studyRoomRepoMock = new Mock<IStudyRoomRepository>();
            // next line is for checking available rooms
            _studyRoomRepoMock.Setup(x => x.GetAll()).Returns(_availableStudyRoom);
            // here after creating an instance of booking service we pass the two mocked
            // dependency injected objects.
            _bookingService = new StudyRoomBookingService(
                _studyRoomBookingRepoMock.Object,
                _studyRoomRepoMock.Object
                );

        }

        [Test]
        public void GetAllisCalled()
        {
            //Act
            _bookingService.GetAllBooking();
            //Assert
            _studyRoomBookingRepoMock.Verify(x => x.GetAll(null), Times.Once);
        }

        [Test]
        public void ThrowsBookingException()
        {
            //Act
            var result = Assert.Throws<ArgumentNullException>(
                () => _bookingService.BookStudyRoom(null));
            //Assert
            Assert.AreEqual("Value cannot be null. (Parameter 'request')", result.Message);
            // or assert that the parameter name in the exception is request
            Assert.AreEqual("request", result.ParamName);
        }

        [Test]
        public void RequestValuesareValid()
        {
            StudyRoomBookingResult result = _bookingService.BookStudyRoom(_request);

            Assert.NotNull(result);
            Assert.AreEqual(_request.FirstName, result.FirstName);
            Assert.AreEqual(_request.LastName, result.LastName);
            Assert.AreEqual(_request.Email, result.Email);
            Assert.AreEqual(_request.Date, result.Date);

        }

        [Test]
        public void ReturnsSuccessResultCode()
        {
            var result = _bookingService.BookStudyRoom(_request);

            // the expected in an enum
            Assert.AreEqual(StudyRoomBookingCode.Success, result.Code);
        }

        [TestCase(true, ExpectedResult = StudyRoomBookingCode.Success)]
        [TestCase(false, ExpectedResult = StudyRoomBookingCode.NoRoomAvailable)]
        public StudyRoomBookingCode ReturnstheRightCode(bool roomAvailability)
        {
            if (!roomAvailability)
            {
                _availableStudyRoom.Clear();
            }
            return _bookingService.BookStudyRoom(_request).Code;
        }


        [Test]
        public void GetAvailableRoom()
        {
            // Additional Arrange
            // We are setting up the studyRoomBookingRepository object to,
            // when the book method is called, save the booking to our variable
            // savedStudyRoomBooking.
            StudyRoomBooking savedStudyRoomBooking = null;
            _studyRoomBookingRepoMock.Setup(x => x.Book(It.IsAny<StudyRoomBooking>()))
                .Callback<StudyRoomBooking>(booking =>
                {
                    savedStudyRoomBooking = booking;
                });

            // Act
            // here we have an instance of bookingService which by constructor must receive
            // two mocked objects, which we have mocked in setup
            _bookingService.BookStudyRoom(_request);

            // Assert
            _studyRoomBookingRepoMock.Verify(x => x.Book(It.IsAny<StudyRoomBooking>()), Times.Once);
            Assert.NotNull(savedStudyRoomBooking);
            Assert.AreEqual(_request.FirstName, savedStudyRoomBooking.FirstName);
            Assert.AreEqual(_request.LastName, savedStudyRoomBooking.LastName);
            Assert.AreEqual(_request.Email, savedStudyRoomBooking.Email);
            Assert.AreEqual(_request.Date, savedStudyRoomBooking.Date);
            Assert.AreEqual(_availableStudyRoom.First().Id, savedStudyRoomBooking.StudyRoomId);

        }

        [TestCase(0, false)]
        [TestCase(55, true)]
        public void GetBookingIdFromAvailableRoom(int expectedBookingId, bool roomAvailability)
        {
            if (!roomAvailability)
            {
                _availableStudyRoom.Clear();
 
            }
            // if the room is not available, the Book method will not be invoked at all
            // as soon as the Book method is called it should set the booking Id to be 55 as the result
            _studyRoomBookingRepoMock.Setup(x => x.Book(It.IsAny<StudyRoomBooking>()))
                .Callback<StudyRoomBooking>(booking =>
                {
                    booking.BookingId = 55;
                });

            var result = _bookingService.BookStudyRoom(_request);

            Assert.AreEqual(expectedBookingId, result.BookingId);
        }

        [Test]
        public void BookMethodNotCalledWhenNoRoomsAvailable()
        {
            _availableStudyRoom.Clear();

            var result = _bookingService.BookStudyRoom(_request);

            _studyRoomBookingRepoMock.Verify(x => x.Book(It.IsAny<StudyRoomBooking>()), Times.Never);
        }
    }
}