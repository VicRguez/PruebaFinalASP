using ASPPrueba.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPPrueba.Data
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }


        public DbSet<Owner> owners { get; set; }
        public DbSet<Vehicle> vehicles { get; set; }

        public DbSet<Claim> claims { get; set; }
    }
}
