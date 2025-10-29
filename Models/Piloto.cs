using System.ComponentModel.DataAnnotations;

namespace BlazorReservasVuelos.Models
{
    public class Piloto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La licencia es obligatoria")]
        [StringLength(50)]
        public string NumeroLicencia { get; set; } = string.Empty;

        [Required(ErrorMessage = "Las horas de vuelo son obligatorias")]
        [Range(0, 100000, ErrorMessage = "Debe ser un valor positivo.")]
        public int HorasVuelo { get; set; }
    }
}