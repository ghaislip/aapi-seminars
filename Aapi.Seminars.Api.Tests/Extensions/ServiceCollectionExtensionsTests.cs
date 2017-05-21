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

            Assert.AreEqual(3, serviceCollection.Count);
        }

        [TestMethod]
        public void AddAapiSeminars_ShouldResolveAllControllers()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAapiSeminarControllers();
            serviceCollection.AddLogging();
            serviceCollection.AddAutoMapper();
            serviceCollection.AddAapiSeminars();
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var aapiSeminarsControllerTypes = Constants.AapiSeminarsApiAssembly.GetAllControllerTypes();
            foreach (var controllerType in aapiSeminarsControllerTypes)
            {
                var controller = serviceProvider.GetService(controllerType);
                Assert.IsNotNull(controller);
            }
        }
    }
}
