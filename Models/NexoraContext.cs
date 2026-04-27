using Microsoft.EntityFrameworkCore;

namespace Nexora.Models {
    public class NexoraContext : DbContext {
        public NexoraContext(DbContextOptions<NexoraContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Plan> Planes { get; set; }
        public DbSet<Servidor> Servidores { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<Factura> Facturas { get; set; }
    }
}
