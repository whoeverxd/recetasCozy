// Archivo: /Data/ApiDbContext.cs
using Microsoft.EntityFrameworkCore;

namespace API.Data   // <-- aquí va el namespace correcto
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        public DbSet<Receta> Recetas { get; set; }
    }
}
