using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nexora.Models
{
    public class Contrato
    {
        [Key]
        public int IdContrato { get; set; }

        [Required]
        public DateTime FechaInicio { get; set; }

        public int? IdUsuario { get; set; }
        public Usuario? Usuario { get; set; }

        public int? IdEmpresa { get; set; }
        public Empresa? Empresa { get; set; }

        [Required]
        public int? IdPlan { get; set; }
        public Plan? Plan { get; set; }

        [Required]
        public int? IdServidor { get; set; }
        public Servidor? Servidor { get; set; }


        [Required]
        public string Correo { get; set; } = string.Empty;

        public string Estado { get; set; } = "Pendiente";

        public ICollection<Factura> Facturas { get; set; } = new List<Factura>();

        public DateTime? FechaFin { get; set; }

    }
}
