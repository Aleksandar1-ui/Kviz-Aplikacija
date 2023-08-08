using Microsoft.EntityFrameworkCore;

namespace QuizAPI.Models
{
    public class QuizDbContext : DbContext
    {
        public QuizDbContext(DbContextOptions<QuizDbContext> options) : base(options)
        {

        }
        public DbSet<Prashanja> Prashanja { get; set; }
        public DbSet<Ucesnik> Ucesnici { get; set; }
    }
}
