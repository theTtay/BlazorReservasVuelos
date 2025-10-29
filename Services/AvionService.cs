using BlazorReservasVuelos.Data;
using BlazorReservasVuelos.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorReservasVuelos.Services
{
    public class AvionService : IAvionService
    {
        private readonly ApplicationDbContext _context;

        public AvionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Avion>> GetAvionesAsync()
        {
            return await _context.Aviones.ToListAsync();
        }

        public async Task<Avion?> GetAvionByIdAsync(int id)
        {
            return await _context.Aviones.FindAsync(id);
        }

        public async Task SaveAvionAsync(Avion avion)
        {
            if (avion.Id == 0)
            {
                _context.Aviones.Add(avion);
            }
            else
            {
                _context.Aviones.Update(avion);
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAvionAsync(int id)
        {
            var avion = await _context.Aviones.FindAsync(id);
            if (avion != null)
            {
                _context.Aviones.Remove(avion);
                await _context.SaveChangesAsync();
            }
        }
    }
}