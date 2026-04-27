using System.ComponentModel.DataAnnotations;

namespace Nexora.Models {
    public class Servidor {
        [Key]   // Clave primaria
        public int IdServidor { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public string IP { get; set; } = string.Empty;

        [Required]
        public string Estado { get; set; } = string.Empty;

        // Relación con contratos
        public ICollection<Contrato> Contratos { get; set; } = new List<Contrato>();
    }
}
