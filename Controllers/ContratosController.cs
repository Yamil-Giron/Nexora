using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nexora.Models;

namespace Nexora.Controllers {
    public class ContratosController : Controller {
        private readonly NexoraContext _context;

        public ContratosController(NexoraContext context) {
            _context = context;
        }

        // GET: Contratos
        public async Task<IActionResult> Index() {
            var contratos = _context.Contratos
                .Include(c => c.Usuario)
                .Include(c => c.Empresa)
                .Include(c => c.Plan)
                .Include(c => c.Servidor);
            return View(await contratos.ToListAsync());
        }

        // GET: Contratos/Create
        public IActionResult Create() {
            ViewBag.Usuarios = new SelectList(_context.Usuarios, "IdUsuario", "Nombre");
            ViewBag.Empresas = new SelectList(_context.Empresas, "IdEmpresa", "Nombre");
            ViewBag.Planes = new SelectList(_context.Planes, "IdPlan", "Nombre");
            ViewBag.Servidores = new SelectList(_context.Servidores, "IdServidor", "Nombre");
            return View();
        }

        // POST: Contratos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdContrato,FechaInicio,FechaFin,IdUsuario,IdEmpresa,IdPlan,IdServidor")] Contrato contrato) {
            if (ModelState.IsValid) {
                _context.Add(contrato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contrato);
        }
    }
}
