using Aapi.Seminars.DataServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Aapi.Seminars.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddTransient<ISeminarsDataService, SeminarsDataService>();
        }
        
        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }
    }
}
