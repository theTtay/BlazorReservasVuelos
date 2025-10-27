// Models/Destino.cs
using System.ComponentModel.DataAnnotations;

namespace BlazorReservasVuelos.Models
{
    public class Destino
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del destino es obligatorio.")]
        public string NombreCiudad { get; set; } = string.Empty;

        public bool EsInternacional { get; set; } = true;

        // ¡NUEVOS CAMPOS!
        public bool PuedeSerOrigen { get; set; } = true;
        public bool PuedeSerDestino { get; set; } = true;
    }
}