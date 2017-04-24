using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aapi.Seminars.Extensions
{
    [TestClass]
    public class ServiceCollectionExtensionsTests
    {
        [TestMethod]
        public void AddAapiSeminars_ShouldResolveCorrectNumberOfServices()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAapiSeminars();

            Assert.AreEqual(2, serviceCollection.Count);
        }
    }
}
