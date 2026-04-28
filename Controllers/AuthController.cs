using Microsoft.AspNetCore.Mvc;
using Nexora.Models;

namespace Nexora.Controllers
{
    public class AuthController : Controller
    {
        private readonly NexoraContext _context;

        public AuthController(NexoraContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(); // Vista con pestañas Login/Registro
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string Correo, string Contraseña)
        {
            // Buscar en Usuarios
            var usuario = _context.Usuarios
                .FirstOrDefault(u => u.Correo == Correo && u.Contraseña == Contraseña);

            if (usuario != null)
            {
                HttpContext.Session.SetString("UsuarioId", usuario.IdUsuario.ToString());
                HttpContext.Session.SetString("UsuarioNombre", usuario.Nombres);
                HttpContext.Session.SetString("Tipo", "Usuario");
                HttpContext.Session.SetString("Correo", usuario.Correo);

                return RedirectToAction("Index", "Home");
            }

            // Buscar en Empresas
            var empresa = _context.Empresas
                .FirstOrDefault(e => e.Correo == Correo && e.Contraseña == Contraseña);

            if (empresa != null)
            {
                HttpContext.Session.SetString("EmpresaId", empresa.IdEmpresa.ToString());
                HttpContext.Session.SetString("UsuarioNombre", empresa.NombreUsuario);
                HttpContext.Session.SetString("Tipo", "Empresa");
                HttpContext.Session.SetString("Correo", empresa.Correo);

                return RedirectToAction("Index", "Home");
            }

            // Si no se encontró en ninguna tabla
            ViewBag.Error = "Correo o contraseña incorrectos";
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Usuario usuario, bool EsEmpresa)
        {
            if (EsEmpresa)
            {
                var empresa = new Empresa
                {
                    RazonSocial = usuario.Nombres + " " + usuario.Apellidos,
                    Rut = usuario.Rut,
                    NombreUsuario = usuario.Nombres,
                    Correo = usuario.Correo,
                    Direccion = usuario.Direccion,
                    Contraseña = usuario.Contraseña,
                    Telefono = usuario.Telefono
                };
                _context.Empresas.Add(empresa);
                _context.SaveChanges();

                HttpContext.Session.SetString("EmpresaId", empresa.IdEmpresa.ToString());
                HttpContext.Session.SetString("UsuarioNombre", empresa.NombreUsuario);
                HttpContext.Session.SetString("Tipo", "Empresa");
                HttpContext.Session.SetString("Correo", empresa.Correo);
            }
            else
            {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();

                HttpContext.Session.SetString("UsuarioId", usuario.IdUsuario.ToString());
                HttpContext.Session.SetString("UsuarioNombre", usuario.Nombres);
                HttpContext.Session.SetString("Tipo", "Usuario");
                HttpContext.Session.SetString("Correo", usuario.Correo);
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
