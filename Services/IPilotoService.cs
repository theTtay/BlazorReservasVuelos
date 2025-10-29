using BlazorReservasVuelos.Models;

namespace BlazorReservasVuelos.Services
{
    public interface IPilotoService
    {
        Task<List<Piloto>> GetPilotosAsync();
        Task SavePilotoAsync(Piloto piloto);
        Task DeletePilotoAsync(int id);
        Task<Piloto?> GetPilotoByIdAsync(int id);
    }
}