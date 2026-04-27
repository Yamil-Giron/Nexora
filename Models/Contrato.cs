using System.ComponentModel.DataAnnotations;

namespace Nexora.Models {
    public class Contrato {
        [Key]   // Clave primaria
        public int IdContrato { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        // Claves foráneas
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; } = null!;   // EF la inicializa

        public int IdEmpresa { get; set; }
        public Empresa Empresa { get; set; } = null!;

        public int IdPlan { get; set; }
        public Plan Plan { get; set; } = null!;

        public int IdServidor { get; set; }
        public Servidor Servidor { get; set; } = null!;

        public ICollection<Factura> Facturas { get; set; } = new List<Factura>();
    }
}
