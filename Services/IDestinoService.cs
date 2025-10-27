using BlazorReservasVuelos.Models;

namespace BlazorReservasVuelos.Services
{
    public interface IDestinoService
    {
        Task<List<Destino>> ObtenerDestinos();
        Task GuardarDestino(Destino destino);
        Task<Destino> ObtenerDestinoPorId(int id);
        Task EliminarDestino(int id);
        Task<List<Destino>> ObtenerOrigenesDisponibles();
        Task<List<Destino>> ObtenerDestinosDisponibles();
    }
}