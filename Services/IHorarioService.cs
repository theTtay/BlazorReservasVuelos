using BlazorReservasVuelos.Models;

namespace BlazorReservasVuelos.Services
{
    public interface IHorarioService
    {
        Task<List<Horario>> GetHorariosAsync();
        Task SaveHorarioAsync(Horario horario);
        Task DeleteHorarioAsync(int id);
        Task<Horario?> GetHorarioByIdAsync(int id);
    }
}