using Aapi.Seminars.Contexts;
using AutoMapper;
using System.Linq;

namespace Aapi.Seminars.DataServices
{
    public abstract class DataServiceBase
    {
        public DataServiceBase(IAapiSeminarsContext aapiSeminarsContext, IMapper mapper)
        {
            this.AapiSeminarsContext = aapiSeminarsContext;
            this.Mapper = mapper;
        }

        protected IAapiSeminarsContext AapiSeminarsContext { get; }

        protected IMapper Mapper { get; }
    }

    public abstract class DataServiceBase<T> : DataServiceBase where T : class
    {
        public DataServiceBase(IAapiSeminarsContext aapiSeminarsContext, IMapper mapper)
            : base(aapiSeminarsContext, mapper)
        {
        }

        protected IQueryable<T> DbSet => this.AapiSeminarsContext.Set<T>();
    }
}
