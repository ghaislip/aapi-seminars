using Aapi.Seminars.DataServices;
using Aapi.Seminars.Models.FrequentlyAskedQuestions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Aapi.Seminars.Controllers
{
    public class FrequentlyAskedQuestionsController : AapiSeminarsControllerBase
    {
        public FrequentlyAskedQuestionsController(ILogger<FrequentlyAskedQuestionsController> logger, IFrequentlyAskedQuestionsDataService frequentlyAskedQuestionsDataService)
            : base(logger)
        {
            this.FrequentlyAskedQuestionsDataService = frequentlyAskedQuestionsDataService;
        }

        private IFrequentlyAskedQuestionsDataService FrequentlyAskedQuestionsDataService { get; }

        [HttpGet("api/frequentlyAskedQuestions")]
        public async Task<FrequentlyAskedQuestionsViewModel> GetAll(int pageNumber = DefaultPageNumber, int pageSize = DefaultPageSize)
        {
            return await this.FrequentlyAskedQuestionsDataService.GetAll(pageNumber, pageSize);
        }
    }
}
