using Microsoft.EntityFrameworkCore;
using Practical_26.Model;

namespace Practical_26.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = @"Data Source=sf-cpu-338\SQLEXPRESS;Initial Catalog=Practical26;Integrated Security=True;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true;";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        public virtual DbSet<Employee> Employees { get; set; } = null!;
    }
}
