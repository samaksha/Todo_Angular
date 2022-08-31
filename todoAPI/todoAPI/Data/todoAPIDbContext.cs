using Microsoft.EntityFrameworkCore;
using todoAPI.Models;

namespace todoAPI.Data
{
    public class todoAPIDbContext: DbContext
    {
        public todoAPIDbContext(DbContextOptions options) : base(options)
        { }
        public DbSet<Contact> Contacts { get; set; }
    }
}
