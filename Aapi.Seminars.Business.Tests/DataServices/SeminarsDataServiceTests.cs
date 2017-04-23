using Aapi.Seminars.Contexts;
using Aapi.Seminars.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aapi.Seminars.DataServices
{
    [TestClass]
    public class SeminarsDataServiceTests
    {
        [TestMethod]
        public void GetAll_ShouldReturnCorrectResult()
        {
            var options = new DbContextOptionsBuilder<AapiSeminarsContext>()
                .UseInMemoryDatabase()
                .Options;
            var aapiSeminarsContext = new AapiSeminarsContext(options);
            aapiSeminarsContext.Seminars.Add(new Seminar { Id = 1 });
            aapiSeminarsContext.SaveChanges();
            var seminarsDataService = new SeminarsDataService(aapiSeminarsContext);

            var seminars = seminarsDataService.GetAll();

            Assert.IsNotNull(seminars);
            Assert.AreEqual(1, seminars.TotalCount);
        }
    }
}
