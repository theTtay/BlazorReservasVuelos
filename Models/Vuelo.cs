// Models/Vuelo.cs
namespace BlazorReservasVuelos.Models
{
    public class Vuelo
    {
        public int Id { get; set; }
        public string Pasajero { get; set; }
        // Campos para los desplegables
        public string Origen { get; set; }
        public string Destino { get; set; }
        public DateTime FechaVuelo { get; set; } = DateTime.Now;
        public string Horario { get; set; }
        public int Asientos { get; set; }
    }
}