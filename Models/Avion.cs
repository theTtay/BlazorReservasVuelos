using System.ComponentModel.DataAnnotations;

namespace BlazorReservasVuelos.Models
{
    public class Avion
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El modelo es obligatorio")]
        [StringLength(100, ErrorMessage = "El modelo no puede exceder los 100 caracteres")]
        public string Modelo { get; set; } = string.Empty;

        [Required(ErrorMessage = "La capacidad es obligatoria")]
        [Range(1, 500, ErrorMessage = "La capacidad debe estar entre 1 y 500")]
        public int Capacidad { get; set; }

        [Required(ErrorMessage = "El número de serie es obligatorio")]
        [StringLength(50, ErrorMessage = "El número de serie no puede exceder los 50 caracteres")]
        public string NumeroSerie { get; set; } = string.Empty;
    }
}