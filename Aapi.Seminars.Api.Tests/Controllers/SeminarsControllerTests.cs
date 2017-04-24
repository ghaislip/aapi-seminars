using Aapi.Seminars.Controllers;
using Aapi.Seminars.DataServices;
using Aapi.Seminars.Models.Seminars;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Aapi.Seminars.Api.Tests.Controllers
{
    [TestClass]
    public class SeminarsControllerTests
    {
        [TestMethod]
        public void GetAll_ShouldReturnCorrectValue()
        {
            var seminarsViewModel = new SeminarsViewModel();
            var seminarsDataServiceMock = new Mock<ISeminarsDataService>();
            seminarsDataServiceMock.Setup(x => x.GetAll(1, 25)).Returns(seminarsViewModel);
            var seminarsController = new SeminarsController(null, seminarsDataServiceMock.Object);

            var result = seminarsController.GetAll();

            seminarsDataServiceMock.Verify(x => x.GetAll(1, 25));
            Assert.AreEqual(seminarsViewModel, result);
        }

        [TestMethod]
        public void GetById_ShouldReturnCorrectValue()
        {
            var seminarViewModel = new SeminarViewModel();
            var seminarsDataServiceMock = new Mock<ISeminarsDataService>();
            seminarsDataServiceMock.Setup(x => x.GetById(42)).Returns(seminarViewModel);
            var seminarsController = new SeminarsController(null, seminarsDataServiceMock.Object);

            var result = seminarsController.GetById(42);

            seminarsDataServiceMock.Verify(x => x.GetById(42));
            Assert.AreEqual(seminarViewModel, result);
        }

        [TestMethod]
        public void Add_ShouldCallAddMethodOfSeminarsDataServiceWithCorrectParameters()
        {
            var seminarAddCommandModel = new SeminarAddCommandModel();
            var seminarsDataServiceMock = new Mock<ISeminarsDataService>();
            var seminarsController = new SeminarsController(null, seminarsDataServiceMock.Object);

            seminarsController.Add(seminarAddCommandModel);

            seminarsDataServiceMock.Verify(x => x.Add(seminarAddCommandModel));
        }

        [TestMethod]
        public void Update_ShouldCallUpdateMethodOfSeminarsDataServiceWithCorrectParameters()
        {
            var seminarUpdateCommandModel = new SeminarUpdateCommandModel();
            var seminarsDataServiceMock = new Mock<ISeminarsDataService>();
            var seminarsController = new SeminarsController(null, seminarsDataServiceMock.Object);

            seminarsController.Update(seminarUpdateCommandModel);

            seminarsDataServiceMock.Verify(x => x.Update(seminarUpdateCommandModel));
        }

        [TestMethod]
        public void Delete_ShouldCallDeleteMethodOfSeminarsDataServiceWithCorrectParameters()
        {
            var seminarsDataServiceMock = new Mock<ISeminarsDataService>();
            var seminarsController = new SeminarsController(null, seminarsDataServiceMock.Object);

            seminarsController.Delete(42);

            seminarsDataServiceMock.Verify(x => x.Delete(42));
        }
    }
}
