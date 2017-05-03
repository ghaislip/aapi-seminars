using Aapi.Seminars.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Aapi.Seminars.Contexts
{
    public interface IAapiSeminarsContext
    {
        DbSet<FrequentlyAskedQuestion> FrequentlyAskedQuestions { get; set; }
        DbSet<Seminar> Seminars { get; set; }
        DbSet<Session> Sessions { get; set; }
        DbSet<Speaker> Speakers { get; set; }
        DbSet<Sponsor> Sponsors { get; set; }
        DbSet<User> Users { get; set; }
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

        public DbSet<FrequentlyAskedQuestion> FrequentlyAskedQuestions { get; set; }
        public DbSet<Seminar> Seminars { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
