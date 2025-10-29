using BlazorReservasVuelos.Models;

namespace BlazorReservasVuelos.Services
{
    public interface IAvionService
    {
        Task<List<Avion>> GetAvionesAsync();
        Task SaveAvionAsync(Avion avion);
        Task DeleteAvionAsync(int id);
        Task<Avion?> GetAvionByIdAsync(int id);
    }
}