using System.Collections.Generic;

namespace Aapi.Seminars.Models
{
    public class PagedResult<T> where T : class
    {
        public IList<T> Results { get; set; }
        public int TotalCount { get; set; }
    }
}
