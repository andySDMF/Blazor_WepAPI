using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }

        public required DbSet<Event> Events { get; set; }
        public required DbSet<PhotoCategory> PhotoCategories { get; set; }
        public required DbSet<Photo> Photos { get; set; }

    }
}
