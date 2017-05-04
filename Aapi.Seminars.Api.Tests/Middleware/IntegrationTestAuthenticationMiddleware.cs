using Aapi.Seminars.Security;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Aapi.Seminars.Middleware
{
    public class IntegrationTestAuthenticationMiddleware
    {
        public IntegrationTestAuthenticationMiddleware(RequestDelegate next, IntegrationTestAuthenticationOptions options)
        {
            this.Next = next;
            this.Options = options;
        }

        private RequestDelegate Next { get; }
        private IntegrationTestAuthenticationOptions Options { get; }

        public Task Invoke(HttpContext context)
        {
            if (!context.User.Identity.IsAuthenticated && context.Request.Headers["Authorization"] == $"Bearer {this.Options.OAuthToken}")
            {
                var testIdentity = new TestIdentity();
                context.User = new ClaimsPrincipal(testIdentity);
            }
            return this.Next(context);
        }
    }

    public class IntegrationTestAuthenticationOptions
    {
        public string OAuthToken { get; set; }
    }
}
