using System.ComponentModel.DataAnnotations;

namespace Nexora.Models {
    public class Factura {
        [Key]   // Clave primaria
        public int IdFactura { get; set; }

        public DateTime FechaEmision { get; set; }
        public decimal Monto { get; set; }

        [Required]   // Estado debe ser obligatorio
        public string Estado { get; set; } = string.Empty;  // inicializado

        // Clave foránea
        public int IdContrato { get; set; }
        public Contrato Contrato { get; set; } = null!;   // EF la inicializa
    }
}
