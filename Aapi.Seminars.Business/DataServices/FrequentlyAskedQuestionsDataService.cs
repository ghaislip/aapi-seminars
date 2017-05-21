using Aapi.Seminars.Models;
using Aapi.Seminars.Models.FrequentlyAskedQuestions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aapi.Seminars.DataServices
{
    public interface IFrequentlyAskedQuestionsDataService
    {
        Task<FrequentlyAskedQuestionsViewModel> GetAll(int pageNumber, int pageSize);
    }
    public class DummyFrequentlyAskedQuestionsDataService : IFrequentlyAskedQuestionsDataService
    {
        public Task<FrequentlyAskedQuestionsViewModel> GetAll(int pageNumber, int pageSize)
        {
            var frequentlyAskedQuestionsViewModel = new FrequentlyAskedQuestionsViewModel
            {
                FrequentlyAskedQuestions = new List<FrequentlyAskedQuestion>
                {
                    new FrequentlyAskedQuestion
                    {
                        Id = 1,
                        Question = "",
                        Answer = "",
                    }
                }
            };
            return Task.FromResult(frequentlyAskedQuestionsViewModel);
        }
    }
}
