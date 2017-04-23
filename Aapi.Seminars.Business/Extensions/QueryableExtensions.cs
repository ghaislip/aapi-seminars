using Aapi.Seminars.Models;
using System.Linq;

namespace Aapi.Seminars.Extensions
{
    public static class QueryableExtensions
    {
        public static PagedResult<T> ToPagedResult<T>(this IQueryable<T> self, int pageNumber, int pageSize) where T : class
        {
            return new PagedResult<T>
            {
                Results = self
                    .Skip(pageNumber * pageSize)
                    .Take(pageSize)
                    .ToList(),
                TotalCount = self.Count()
            };
        }
    }
}
