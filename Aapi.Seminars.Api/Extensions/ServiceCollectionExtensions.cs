using Aapi.Seminars.Contexts;
using Aapi.Seminars.DataServices;
using Aapi.Seminars.Models;
using Aapi.Seminars.Models.Seminars;
using Aapi.Seminars.Options;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Aapi.Seminars.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAapiSeminars(this IServiceCollection self)
        {
            // Options
            // TODO: Refactor this to use a JSON file
            var inMemoryConfigurationDictionary = GetInMemoryConfigurationDictionary();
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemoryConfigurationDictionary)
                .Build();
            self.AddSingleton(new AapiSeminarsOptions
            {
                LinkedInClientId = configuration.GetValue<string>("LinkedIn:ClientId"),
                LinkedInClientSecret = configuration.GetValue<string>("LinkedIn:ClientSecret")
            });

            // Contexts
            // TODO: Refactor this to use the real context
            var inMemoryAapiSeminarsContext = GetInMemorySeminarsContext();
            self.AddSingleton<IAapiSeminarsContext>(inMemoryAapiSeminarsContext);

            // Data Services
            self.AddTransient<ISeminarsDataService, SeminarsDataService>();
            self.AddTransient<IFrequentlyAskedQuestionsDataService, DummyFrequentlyAskedQuestionsDataService>();
        }

        public static void AddAutoMapper(this IServiceCollection self)
        {
            self.AddSingleton(x => new MapperConfiguration(cfg => {
                cfg.CreateMap<Seminar, SeminarViewModel>();
                cfg.CreateMap<SeminarAddCommandModel, Seminar>();
                cfg.CreateMap<SeminarUpdateCommandModel, Seminar>();
            }).CreateMapper());
        }

        public static void AddAapiSeminarControllers(this IServiceCollection self)
        {
            var aapiSeminarsControllerTypes = Constants.AapiSeminarsApiAssembly.GetAllControllerTypes();
            foreach (var controllerType in aapiSeminarsControllerTypes)
            {
                self.AddTransient(controllerType);
            }
        }

        private static AapiSeminarsContext GetInMemorySeminarsContext()
        {
            var options = new DbContextOptionsBuilder<AapiSeminarsContext>()
                .UseInMemoryDatabase()
                .Options;
            var inMemoryAapiSeminarsContext = new AapiSeminarsContext(options);
            inMemoryAapiSeminarsContext.Seminars.Add(new Seminar { Name = "Summer Seminar" });
            inMemoryAapiSeminarsContext.Seminars.Add(new Seminar { Name = "Winter Seminar" });
            inMemoryAapiSeminarsContext.SaveChanges();
            return inMemoryAapiSeminarsContext;
        }

        private static IDictionary<string, string> GetInMemoryConfigurationDictionary()
        {
            return new Dictionary<string, string>
            {
                { "LinkedIn:ClientId", "786khil1ssxt46" },
                { "LinkedIn:ClientSecret", "b6z1w0wFtoniNPIc" }
            };
        }
    }
}
