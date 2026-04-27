using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nexora.Models;

namespace Nexora.Controllers {
    public class PlanesController : Controller {
        private readonly NexoraContext _context;

        public PlanesController(NexoraContext context) {
            _context = context;
        }

        public async Task<IActionResult> Index() {
            return View(await _context.Planes.ToListAsync());
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPlan,Nombre,Descripcion")] Plan plan) {
            if (ModelState.IsValid) {
                _context.Add(plan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(plan);
        }
    }
}
