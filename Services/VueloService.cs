// Services/VueloService.cs
using BlazorReservasVuelos.Data;
using BlazorReservasVuelos.Models;
using Microsoft.EntityFrameworkCore; // Necesario para .ToListAsync(), .FirstOrDefaultAsync(), etc.

namespace BlazorReservasVuelos.Services
{
    public class VueloService : IVueloService
    {
        private readonly ApplicationDbContext _context;

        // Inyección del DbContext a través del constructor
        public VueloService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Vuelo>> ObtenerVuelos()
        {
            // Operación READ (Lectura)
            return await _context.Vuelos.OrderByDescending(v => v.FechaVuelo).ToListAsync();
        }

        public async Task<Vuelo> ObtenerVueloPorId(int id)
        {
            // Operación READ (Búsqueda por ID)
            // Similara a Task<Clientes> Buscar(int id)
            return await _context.Vuelos.FirstOrDefaultAsync(v => v.Id == id) ?? new Vuelo();
        }

        public async Task GuardarVuelo(Vuelo vuelo)
        {
            if (vuelo.Id == 0)
            {
                // Operación CREATE (Crear) - Similar a Task Crear(Clientes clientes)
                _context.Vuelos.Add(vuelo);
            }
            else
            {
                // Operación UPDATE (Actualizar) - Similar a Task Actualizar(Clientes clientes)
                _context.Vuelos.Update(vuelo);
            }

            // Guardar los cambios en la base de datos
            await _context.SaveChangesAsync();
        }

        public async Task EliminarVuelo(int id)
        {
            // Operación DELETE (Eliminar) - Similar a Task Borrar(Clientes clientes)
            var vuelo = await _context.Vuelos.FindAsync(id);
            if (vuelo != null)
            {
                _context.Vuelos.Remove(vuelo);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Vuelo>> BuscarVuelos(string? origen, string? destino, string? pasajero)
        {
            // Crea una query a la base de datos
            var query = _context.Vuelos.AsQueryable();

            if (!string.IsNullOrEmpty(origen))
            {
                query = query.Where(v => v.Origen.Contains(origen));
            }

            if (!string.IsNullOrEmpty(destino))
            {
                query = query.Where(v => v.Destino.Contains(destino));
            }

            if (!string.IsNullOrEmpty(pasajero))
            {
                query = query.Where(v => v.Pasajero.Contains(pasajero));
            }

            // Ejecuta la query y devuelve la lista
            return await query.OrderByDescending(v => v.FechaVuelo).ToListAsync();
        }
    }
}