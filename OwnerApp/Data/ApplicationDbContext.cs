using Microsoft.EntityFrameworkCore;
using OwnerApp.Models;

namespace OwnerApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Contact> Contacts { get; set; }
    }
}
