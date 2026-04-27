using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nexora.Models;

namespace Nexora.Controllers {
    public class EmpresasController : Controller {
        private readonly NexoraContext _context;

        public EmpresasController(NexoraContext context) {
            _context = context;
        }

        public async Task<IActionResult> Index() {
            return View(await _context.Empresas.ToListAsync());
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEmpresa,Nombre,RUT,Direccion")] Empresa empresa) {
            if (ModelState.IsValid) {
                _context.Add(empresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empresa);
        }
    }
}
