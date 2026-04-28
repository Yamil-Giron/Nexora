using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nexora.Models;

namespace Nexora.Controllers {
    public class FacturasController : Controller {
        private readonly NexoraContext _context;

        public FacturasController(NexoraContext context) {
            _context = context;
        }

        // GET: Facturas
        public async Task<IActionResult> Index() {
            var facturas = _context.Facturas
                .Include(f => f.Contrato)
                .ThenInclude(c => c.Usuario); // opcional: mostrar usuario del contrato
            return View(await facturas.ToListAsync());
        }

        // GET: Facturas/Create
        public IActionResult Create() {
            ViewBag.Contratos = new SelectList(_context.Contratos, "IdContrato", "IdContrato");
            return View();
        }

        // POST: Facturas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFactura,FechaEmision,Monto,Estado,IdContrato")] Factura factura) {
            if (ModelState.IsValid) {
                _context.Add(factura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(factura);
        }
    }
}
