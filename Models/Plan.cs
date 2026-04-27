using System.ComponentModel.DataAnnotations;

namespace Nexora.Models {
    public class Plan {
        [Key]   // Clave primaria
        public int IdPlan { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public string Descripcion { get; set; } = string.Empty;

        // Relación con contratos
        public ICollection<Contrato> Contratos { get; set; } = new List<Contrato>();
    }
}
