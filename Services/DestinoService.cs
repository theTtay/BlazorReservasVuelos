using BlazorReservasVuelos.Data;
using BlazorReservasVuelos.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorReservasVuelos.Services
{
    public class DestinoService : IDestinoService
    {
        private readonly ApplicationDbContext _context;

        public DestinoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Destino>> ObtenerDestinos()
        {
            return await _context.Destinos.OrderBy(d => d.NombreCiudad).ToListAsync();
        }

        public async Task GuardarDestino(Destino destino)
        {
            if (destino.Id == 0)
            {
                _context.Destinos.Add(destino);
            }
            else
            {
                _context.Destinos.Update(destino);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Destino> ObtenerDestinoPorId(int id)
        {
            return await _context.Destinos.FirstOrDefaultAsync(d => d.Id == id) ?? new Destino();
        }

        public async Task EliminarDestino(int id)
        {
            var destino = await _context.Destinos.FindAsync(id);
            if (destino != null)
            {
                _context.Destinos.Remove(destino);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Destino>> ObtenerOrigenesDisponibles()
        {
            // Filtra los destinos que tienen la propiedad PuedeSerOrigen como true
            return await _context.Destinos
                .Where(d => d.PuedeSerOrigen)
                .OrderBy(d => d.NombreCiudad)
                .ToListAsync();
        }

        public async Task<List<Destino>> ObtenerDestinosDisponibles()
        {
            // Filtra los destinos que tienen la propiedad PuedeSerDestino como true
            return await _context.Destinos
                .Where(d => d.PuedeSerDestino)
                .OrderBy(d => d.NombreCiudad)
                .ToListAsync();
        }
    }
}