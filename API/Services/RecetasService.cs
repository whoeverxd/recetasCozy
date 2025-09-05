using Microsoft.EntityFrameworkCore;
using API.Models;
using API.Data;
// using API.Data;  // Importa tu DbContext
// Reemplaza la línea anterior por el espacio de nombres real donde está ApiDbContext

public class RecetasService
{
    private readonly ApiDbContext _context;

    public RecetasService(ApiDbContext context)
    {
        _context = context;
    }

    // Método para obtener todas las recetas
    public List<Receta> GetAllRecetas()
    {
        var todasRecetas = _context.Recetas.ToList();
        return todasRecetas;
    }
}