using Aapi.Seminars.Middleware;
using Microsoft.AspNetCore.Builder;

namespace Aapi.Seminars.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseIntegrationTestAuthentication(this IApplicationBuilder self, IntegrationTestAuthenticationOptions options)
        {
            self.UseMiddleware<IntegrationTestAuthenticationMiddleware>(options);
            return self;
        }
    }
}
