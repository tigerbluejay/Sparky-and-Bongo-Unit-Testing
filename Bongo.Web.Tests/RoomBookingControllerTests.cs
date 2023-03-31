using Bongo.Core.Services.IServices;
using Bongo.Models.Model;
using Bongo.Models.Model.VM;
using Bongo.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bongo.Web.Tests
{
    [TestFixture]
    public class RoomBookingControllerTests
    {
        private Mock<IStudyRoomBookingService> _studyRoomBookingService;
        private RoomBookingController _bookingController;

        [SetUp]
        public void Setup()
        {
            _studyRoomBookingService = new Mock<IStudyRoomBookingService>();
            _bookingController = new RoomBookingController(_studyRoomBookingService.Object);
        }

        [Test]
        public void GetAllMethodWasCalled()
        {
            _bookingController.Index();
            _studyRoomBookingService.Verify(x => x.GetAllBooking(), Times.Once());

        }
        [Test]
        public void ReturnViewWhenModelStateisInvalid()
        {
            _bookingController.ModelState.AddModelError("dummy key", "dummy error message");

            var result = _bookingController.Book(new StudyRoomBooking());
            
            ViewResult viewResult = result as ViewResult; // convert the IActionResult result to a view.
            Assert.AreEqual("Book", viewResult.ViewName);
        }

        [Test]
        public void ReturnNoRoomCode()
        {
            _studyRoomBookingService.Setup(x => x.BookStudyRoom(It.IsAny<StudyRoomBooking>()))
                .Returns(new StudyRoomBookingResult()
                {
                    Code = StudyRoomBookingCode.NoRoomAvailable

                });

            var result = _bookingController.Book(new StudyRoomBooking());

            Assert.IsInstanceOf<ViewResult>(result); // IActionResult includes ViewResult Types
            ViewResult viewResult = result as ViewResult; // Still we make the conversion
            Assert.AreEqual("No Study Room available for selected date",
                viewResult.ViewData["Error"]);

        }

        [Test]
        public void ReturnSuccessCode()
        {
            // Arrange
            _studyRoomBookingService.Setup(x => x.BookStudyRoom(It.IsAny<StudyRoomBooking>()))
                .Returns((StudyRoomBooking booking) => new StudyRoomBookingResult()
                {
                    Code = StudyRoomBookingCode.Success,
                    FirstName = booking.FirstName,
                    LastName = booking.LastName,
                    Email = booking.Email,
                    Date = booking.Date

                });
            // Act
            var result = _bookingController.Book(new StudyRoomBooking()
            {
                FirstName = "FirstName1",
                LastName = "LastName1",
                Email = "FirstName1@gmail.com",
                Date = DateTime.Now,
                StudyRoomId = 1
            });

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            RedirectToActionResult actionResult = result as RedirectToActionResult;
            Assert.AreEqual("FirstName1", actionResult.RouteValues["FirstName"]);
            Assert.AreEqual(StudyRoomBookingCode.Success, actionResult.RouteValues["Code"]);
            


        }
    }
}
