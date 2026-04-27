using Microsoft.AspNetCore.Mvc;
using Nexora.Models;
using Microsoft.EntityFrameworkCore;

namespace Nexora.Controllers {
    public class UsuariosController : Controller {
        private readonly NexoraContext _context;

        public UsuariosController(NexoraContext context) {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index() {
            return View(await _context.Usuarios.ToListAsync());
        }

        // GET: Usuarios/Create
        public IActionResult Create() {
            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuario,Nombre,Correo,Contraseña,Rol")] Usuario usuario) {
            if (ModelState.IsValid) {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }
    }
}
