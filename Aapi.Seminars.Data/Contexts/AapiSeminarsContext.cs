using Aapi.Seminars.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Aapi.Seminars.Contexts
{
    public interface IAapiSeminarsContext
    {
        DbSet<Seminar> Seminars { get; set; }

        DbSet<T> Set<T>() where T : class;

        Task<int> SaveChangesAsync(CancellationToken token = default(CancellationToken));
    }

    public class AapiSeminarsContext : DbContext, IAapiSeminarsContext
    {
        public const string AapiSeminarsSchema = "AapiSeminars";

        public AapiSeminarsContext(DbContextOptions<AapiSeminarsContext> options)
            :base(options)
        {
        }

        public DbSet<Seminar> Seminars { get; set; }
    }
}
