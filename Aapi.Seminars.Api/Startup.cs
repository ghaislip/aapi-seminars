using Aapi.Seminars.Extensions;
using Aapi.Seminars.Options;
using Aapi.Seminars.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Aapi.Seminars.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.AddMvc();
            services.AddAapiSeminarControllers();
            services.AddLogging();
            services.AddAutoMapper();
            services.AddAapiSeminars();
            services.AddIdentity<IAapiSeminarsUser, IAapiSeminarsRole>();
        }
        
        public virtual void Configure(IApplicationBuilder app, AapiSeminarsOptions aapiSeminarsOptions)
        {
            app.UseIdentity();
            app.UseLinkedInAuthentication(new LinkedInOptions
            {
                ClientId = aapiSeminarsOptions.LinkedInClientId,
                ClientSecret = aapiSeminarsOptions.LinkedInClientSecret
            });
            app.UseMvc();
        }
    }
}
