using System.ComponentModel.DataAnnotations;

namespace Nexora.Models {
    public class Empresa {
        [Key]
        public int IdEmpresa { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public string RUT { get; set; } = string.Empty;

        [Required]
        public string Direccion { get; set; } = string.Empty;

        // Relación con contratos
        public ICollection<Contrato> Contratos { get; set; } = new List<Contrato>();
    }
}
