using System;

namespace API.Models
{
    public class Receta
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Ingredientes { get; set; } = string.Empty;
        public string Instrucciones { get; set; } = string.Empty;
    }
}