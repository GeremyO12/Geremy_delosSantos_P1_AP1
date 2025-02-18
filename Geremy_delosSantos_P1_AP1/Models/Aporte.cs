using System.ComponentModel.DataAnnotations;

namespace Geremy_delosSantos_P1_AP1.Models;

public class Aporte
{
    [Key]
    public int AporteId { get; set; }

    [Required(ErrorMessage = "Fecha es Requerida")]
    public DateTime Fecha { get; set; }
    public string? Persona { get; set; }    

    [Required(ErrorMessage = "Concepto es Requerido")]
    [StringLength(maximumLength: 500, ErrorMessage = "Concepto muy largo")]
    public string? Observacion { get; set; }

    [Required(ErrorMessage = "Monto es Requerido")]
    [Range(minimum: 0.01, maximum: double.MaxValue, ErrorMessage = "El Monto debe ser mayor a 0.05")]
    public double Monto { get; set; }
}
