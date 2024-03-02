using Microsoft.EntityFrameworkCore;

namespace Dot_Net_Core_application_16022024.Models
{

    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        { 
        }
        public DbSet<RR_table> RR_tables { get; set; }
    }
}
