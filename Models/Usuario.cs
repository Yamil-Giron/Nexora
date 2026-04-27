using System.ComponentModel.DataAnnotations;

namespace Nexora.Models {
    public class Usuario {
        [Key]   // Clave primaria
        public int IdUsuario { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public string Correo { get; set; } = string.Empty;

        [Required]
        public string Contraseña { get; set; } = string.Empty;

        [Required]
        public string Rol { get; set; } = string.Empty;

        // Relación con contratos
        public ICollection<Contrato> Contratos { get; set; } = new List<Contrato>();
    }
}
