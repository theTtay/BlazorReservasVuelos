using System.ComponentModel.DataAnnotations;

namespace BlazorReservasVuelos.Models
{
    public class Horario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La hora de salida es obligatoria")]
        [DataType(DataType.Time)]
        public TimeOnly HoraSalida { get; set; } // Usa TimeOnly si es .NET 6 o superior

        [Required(ErrorMessage = "La hora de llegada es obligatoria")]
        [DataType(DataType.Time)]
        public TimeOnly HoraLlegada { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(100)]
        public string Descripcion { get; set; } = string.Empty;
    }
}