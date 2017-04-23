using Aapi.Seminars.Contexts;
using Aapi.Seminars.Extensions;
using Aapi.Seminars.Models;
using System.Linq;

namespace Aapi.Seminars.DataServices
{
    public interface ISeminarsDataService
    {
        PagedResult<Seminar> GetAll(int pageNumber, int pageSize);
    }

    public class SeminarsDataService : DataServiceBase<Seminar>, ISeminarsDataService
    {
        public SeminarsDataService(IAapiSeminarsContext aapiSeminarsContext)
            : base(aapiSeminarsContext)
        {
        }

        public PagedResult<Seminar> GetAll(int pageNumber = DefaultPageNumber, int pageSize = DefaultPageSize)
        {
            return this.DbSet
                .OrderBy(x =>x.Id)
                .ToPagedResult(pageNumber, pageSize);
        }
    }
}
