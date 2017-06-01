using System.Linq;
using System.Threading.Tasks;
using Aapi.Seminars.Contexts;
using Aapi.Seminars.Models;
using Aapi.Seminars.Models.FrequentlyAskedQuestions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Aapi.Seminars.DataServices
{
    public interface IFrequentlyAskedQuestionsDataService
    {
        Task<FrequentlyAskedQuestionsViewModel> GetAll(int pageNumber, int pageSize);
    }

    public class FrequentlyAskedQuestionsDataService : DataServiceBase<FrequentlyAskedQuestion>, IFrequentlyAskedQuestionsDataService
    {
        public FrequentlyAskedQuestionsDataService(IAapiSeminarsContext aapiSeminarsContext, IMapper mapper)
            : base(aapiSeminarsContext, mapper)
        {
        }

        public async Task<FrequentlyAskedQuestionsViewModel> GetAll(int pageNumber, int pageSize)
        {
            return new FrequentlyAskedQuestionsViewModel
            {
                Results = await this.DbSet
                    .OrderBy(x => x.Id)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync(),
                TotalItemCount = await this.DbSet
                    .CountAsync()
            };
        }
    }
}