using Aapi.Seminars.Contexts;
using System.Linq;

namespace Aapi.Seminars.DataServices
{
    public abstract class DataServiceBase
    {
        public DataServiceBase(IAapiSeminarsContext aapiSeminarsContext)
        {
            this.AapiSeminarsContext = aapiSeminarsContext;
        }

        protected IAapiSeminarsContext AapiSeminarsContext { get; }
    }

    public abstract class DataServiceBase<T> : DataServiceBase where T : class
    {
        protected const int DefaultPageNumber = 1;
        protected const int DefaultPageSize = 25;

        public DataServiceBase(IAapiSeminarsContext aapiSeminarsContext)
            : base(aapiSeminarsContext)
        {
        }

        protected IQueryable<T> DbSet => this.AapiSeminarsContext.Set<T>();
    }
}
