using Aapi.Seminars.Extensions;
using Aapi.Seminars.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aapi.Seminars.Contexts
{
    [TestClass]
    public class AapiSeminarsContextTests
    {
        [TestMethod]
        [TestCategory(TestCategoryHelper.Integration)]
        public void AapiSeminarContext_ShouldSuccessfullyQueryAnObjectOnEachModel()
        {
            // TODO: Refactor this to use the real context
            var options = new DbContextOptionsBuilder<AapiSeminarsContext>()
                .UseInMemoryDatabase()
                .Options;
            var aapiSeminarsContext = new AapiSeminarsContext(options);
            aapiSeminarsContext.QueryAnObjectOnEachModel();
        }
    }
}
