using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PackitupStoragePark.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
          
    }
        public DbSet<User> Users {  get; set; } 
        public DbSet<StorageUnit> StorageUnits {  get; set; } 
    }
}