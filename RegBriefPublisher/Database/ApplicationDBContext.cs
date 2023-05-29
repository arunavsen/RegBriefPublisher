using Microsoft.EntityFrameworkCore;
using RegBriefPublisher.Models;

namespace RegBriefPublisher.Database
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<Brief> Briefs { get; set; }
        public DbSet<BriefCountryMap> BriefCountryMaps { get; set; }
        //public DbSet<Country> Countries { get; set; }
        public DbSet<WTABrief> WTABriefs { get; set; }
        public DbSet<TPABrief> TPABriefs { get; set; }
        public DbSet<TAXBrief> TAXBriefs { get; set; }
    }
}
