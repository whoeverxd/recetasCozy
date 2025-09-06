using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Data
{
    public class CozyContext : DbContext
    {
        public CozyContext(DbContextOptions<CozyContext> options) : base(options) { }

        public DbSet<Receta> Recetas { get; set; }
    }
}