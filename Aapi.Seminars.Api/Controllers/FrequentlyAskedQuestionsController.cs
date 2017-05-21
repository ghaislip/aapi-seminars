using Microsoft.Extensions.Logging;

namespace Aapi.Seminars.Controllers
{
    public class FrequentlyAskedQuestionsController : AapiSeminarsControllerBase
    {
        public FrequentlyAskedQuestionsController(ILogger<FrequentlyAskedQuestionsController> logger)
            : base(logger)
        {
        }
    }
}
