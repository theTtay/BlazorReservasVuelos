// Data/ApplicationDbContext.cs
using BlazorReservasVuelos.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorReservasVuelos.Data
{
    // Hereda de DbContext
    public class ApplicationDbContext : DbContext
    {
        // Constructor que recibe las opciones de configuración
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Propiedad DbSet que mapea el modelo Vuelo a la tabla "Vuelos" en la DB
        public DbSet<Vuelo> Vuelos { get; set; }
        public DbSet<Destino> Destinos { get; set; }
        public DbSet<Avion> Aviones { get; set; }
        public DbSet<Piloto> Pilotos { get; set; }
        public DbSet<Horario> Horarios { get; set; }

    }
}