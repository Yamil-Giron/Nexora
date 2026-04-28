using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nexora.Models;

namespace Nexora.Controllers {
    public class ServidoresController : Controller {
        private readonly NexoraContext _context;

        public ServidoresController(NexoraContext context) {
            _context = context;
        }

        public async Task<IActionResult> Index() {
            return View(await _context.Servidores.ToListAsync());
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdServidor,Nombre,IP,Estado")] Servidor servidor) {
            if (ModelState.IsValid) {
                _context.Add(servidor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(servidor);
        }
    }
}
