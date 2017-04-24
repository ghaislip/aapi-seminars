using Aapi.Seminars.Contexts;
using Aapi.Seminars.DataServices;
using Aapi.Seminars.Models;
using Aapi.Seminars.Models.Seminars;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Aapi.Seminars.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAapiSeminars(this IServiceCollection self)
        {
            var options = new DbContextOptionsBuilder<AapiSeminarsContext>()
                .UseInMemoryDatabase()
                .Options;
            var inMemoryAapiSeminarsContext = new AapiSeminarsContext(options);
            inMemoryAapiSeminarsContext.Seminars.Add(new Seminar { Name = "Summer Seminar" });
            inMemoryAapiSeminarsContext.Seminars.Add(new Seminar { Name = "Winter Seminar" });
            inMemoryAapiSeminarsContext.SaveChanges();
            self.AddSingleton<IAapiSeminarsContext>(inMemoryAapiSeminarsContext);
            self.AddTransient<ISeminarsDataService, SeminarsDataService>();
        }

        public static void AddAutoMapper(this IServiceCollection self)
        {
            self.AddSingleton(x => new MapperConfiguration(cfg => {
                cfg.CreateMap<Seminar, SeminarViewModel>();
                cfg.CreateMap<SeminarAddCommandModel, Seminar>();
                cfg.CreateMap<SeminarUpdateCommandModel, Seminar>();
            }).CreateMapper());
        }
    }
}
