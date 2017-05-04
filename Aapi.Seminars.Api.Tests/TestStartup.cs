using Aapi.Seminars.Api;
using Aapi.Seminars.Extensions;
using Aapi.Seminars.Middleware;
using Aapi.Seminars.Options;
using Microsoft.AspNetCore.Builder;

namespace Aapi.Seminars
{
    public class TestStartup : Startup
    {
        public const string TestOAuthToken = "1123412341234";

        public override void Configure(IApplicationBuilder app, AapiSeminarsOptions aapiSeminarsOptions)
        {
            app.UseIntegrationTestAuthentication(new IntegrationTestAuthenticationOptions
            {
                OAuthToken = TestOAuthToken
            });
            base.Configure(app, aapiSeminarsOptions);
        }
    }
}
