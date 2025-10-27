using BlazorReservasVuelos.Models;

namespace BlazorReservasVuelos.Services
{
    public interface IVueloService
    {
        //CRUD: Buscar
        Task<List<Vuelo>> BuscarVuelos(string? origen, string? destino, string? pasajero);
        // CRUD: Leer lista (Listar clientes)
        Task<List<Vuelo>> ObtenerVuelos();
        // CRUD: Leer por ID (Buscar)
        Task<Vuelo> ObtenerVueloPorId(int id);
        // CRUD: Crear/Actualizar (Crear/Actualizar)
        Task GuardarVuelo(Vuelo vuelo);
        // CRUD: Eliminar (Borrar)
        Task EliminarVuelo(int id);
    }
}