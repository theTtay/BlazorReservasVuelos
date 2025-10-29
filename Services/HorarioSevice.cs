// Services/HorarioService.cs
using BlazorReservasVuelos.Data;
using BlazorReservasVuelos.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorReservasVuelos.Services
{
    public class HorarioService : IHorarioService
    {
        private readonly ApplicationDbContext _context;

        public HorarioService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Horario>> GetHorariosAsync()
        {
            return await _context.Horarios.ToListAsync();
        }

        public async Task<Horario?> GetHorarioByIdAsync(int id)
        {
            return await _context.Horarios.FindAsync(id);
        }

        public async Task SaveHorarioAsync(Horario horario)
        {
            if (horario.Id == 0)
            {
                _context.Horarios.Add(horario);
            }
            else
            {
                _context.Horarios.Update(horario);
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteHorarioAsync(int id)
        {
            var horario = await _context.Horarios.FindAsync(id);
            if (horario != null)
            {
                _context.Horarios.Remove(horario);
                await _context.SaveChangesAsync();
            }
        }
    }
}