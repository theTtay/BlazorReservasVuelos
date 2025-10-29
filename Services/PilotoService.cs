// Services/PilotoService.cs
using BlazorReservasVuelos.Data;
using BlazorReservasVuelos.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorReservasVuelos.Services
{
    public class PilotoService : IPilotoService
    {
        private readonly ApplicationDbContext _context;

        public PilotoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Piloto>> GetPilotosAsync()
        {
            return await _context.Pilotos.ToListAsync();
        }

        public async Task<Piloto?> GetPilotoByIdAsync(int id)
        {
            return await _context.Pilotos.FindAsync(id);
        }

        public async Task SavePilotoAsync(Piloto piloto)
        {
            if (piloto.Id == 0)
            {
                _context.Pilotos.Add(piloto);
            }
            else
            {
                _context.Pilotos.Update(piloto);
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeletePilotoAsync(int id)
        {
            var piloto = await _context.Pilotos.FindAsync(id);
            if (piloto != null)
            {
                _context.Pilotos.Remove(piloto);
                await _context.SaveChangesAsync();
            }
        }
    }
}