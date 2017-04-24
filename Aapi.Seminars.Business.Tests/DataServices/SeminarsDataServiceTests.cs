using Aapi.Seminars.Contexts;
using Aapi.Seminars.Models;
using Aapi.Seminars.Models.Seminars;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Aapi.Seminars.DataServices
{
    [TestClass]
    public class SeminarsDataServiceTests
    {
        public TestContext TestContext { get; set; }
        private IAapiSeminarsContext TestAapiSeminarsContext { get; set; }
        private IMapper Mapper { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            var options = new DbContextOptionsBuilder<AapiSeminarsContext>()
                .UseInMemoryDatabase(this.TestContext.TestName)
                .Options;
            this.TestAapiSeminarsContext = new AapiSeminarsContext(options);
            this.TestAapiSeminarsContext.Seminars.Add(new Seminar { Id = 2, Name = "Summer Seminar" });
            this.TestAapiSeminarsContext.Seminars.Add(new Seminar { Id = 3, Name = "Winter Seminar" });
            this.TestAapiSeminarsContext.SaveChanges();

            this.Mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<Seminar, SeminarViewModel>();
                cfg.CreateMap<SeminarAddCommandModel, Seminar>();
                cfg.CreateMap<SeminarUpdateCommandModel, Seminar>();
            }).CreateMapper();
        }

        [TestMethod]
        public void GetAll_ShouldReturnCorrectResult()
        {
            var seminarsDataService = new SeminarsDataService(this.TestAapiSeminarsContext, this.Mapper);

            var seminars = seminarsDataService.GetAll(1, 25);

            Assert.IsNotNull(seminars);
            Assert.AreEqual(2, seminars.TotalItemCount);
            Assert.AreEqual("Summer Seminar", seminars.Results.First().Name);
        }

        [TestMethod]
        public void GetById_ShouldReturnCorrectResult()
        {
            var seminarsDataService = new SeminarsDataService(this.TestAapiSeminarsContext, this.Mapper);

            var seminar = seminarsDataService.GetById(3);

            Assert.IsNotNull(seminar);
            Assert.AreEqual("Winter Seminar", seminar.Name);
        }

        [TestMethod]
        public void Add_ShouldReturnCorrectCount()
        {
            var seminarsDataService = new SeminarsDataService(this.TestAapiSeminarsContext, this.Mapper);

            var seminarAddCommandModel = new SeminarAddCommandModel
            {
                Name = "Fall Seminar"
            };

            seminarsDataService.Add(seminarAddCommandModel);

            Assert.AreEqual(3, this.TestAapiSeminarsContext.Seminars.Count());
        }

        [TestMethod]
        public void Update_ShouldChangeProperty()
        {
            var seminarsDataService = new SeminarsDataService(this.TestAapiSeminarsContext, this.Mapper);

            var seminarUpdateCommandModel = new SeminarUpdateCommandModel
            {
                Id = 2,
                Name = "Fall Seminar"
            };

            seminarsDataService.Update(seminarUpdateCommandModel);

            Assert.AreEqual("Fall Seminar", this.TestAapiSeminarsContext.Seminars.Single(x => x.Id == 2).Name);
        }

        [TestMethod]
        public void Delete_ShouldReturnCorrectCount()
        {
            var seminarsDataService = new SeminarsDataService(this.TestAapiSeminarsContext, this.Mapper);
            
            seminarsDataService.Delete(2);

            Assert.AreEqual(1, this.TestAapiSeminarsContext.Seminars.Count());
        }
    }
}
