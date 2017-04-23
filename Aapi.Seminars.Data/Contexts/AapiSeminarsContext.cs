using Aapi.Seminars.Models;
using Microsoft.EntityFrameworkCore;

namespace Aapi.Seminars.Contexts
{
    public interface IAapiSeminarsContext
    {
        DbSet<Seminar> Seminars { get; set; }

        DbSet<T> Set<T>() where T : class;
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
