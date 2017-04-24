using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Aapi.Seminars.Controllers
{
    public abstract class AapiSeminarsControllerBase : ControllerBase
    {
        protected const int DefaultPageNumber = 1;
        protected const int DefaultPageSize = 25;

        public AapiSeminarsControllerBase(ILogger logger)
        {
            this.Logger = logger;
        }

        protected ILogger Logger { get; }
    }
}
