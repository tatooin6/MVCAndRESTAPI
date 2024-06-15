using Microsoft.EntityFrameworkCore;
using WebAPIAutores.Entities;

namespace WebAPIAutores
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        // Create a table with <Author> entity schema and name it Authors
        public DbSet<Author> Authors { get; set; }
    }
}