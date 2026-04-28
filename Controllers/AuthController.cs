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
        public IActionResult Login(string Correo, string Contraseña)
        {
            // Buscar en Usuarios
            var usuario = _context.Usuarios
                .FirstOrDefault(u => u.Correo == Correo && u.Contraseña == Contraseña);

            if (usuario != null)
            {
                HttpContext.Session.SetString("UsuarioNombre", usuario.Nombres);
                HttpContext.Session.SetString("Tipo", "Usuario");
                return RedirectToAction("Index", "Home");
            }

            // Buscar en Empresas
            var empresa = _context.Empresas
                .FirstOrDefault(e => e.Correo == Correo && e.Contraseña == Contraseña);

            if (empresa != null)
            {
                HttpContext.Session.SetString("UsuarioNombre", empresa.NombreUsuario);
                HttpContext.Session.SetString("Tipo", "Empresa");
                return RedirectToAction("Index", "Home");
            }

            // Si no se encontró en ninguna tabla
            ViewBag.Error = "Correo o contraseña incorrectos";
            return View("Index");
        }

        [HttpPost]
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

                HttpContext.Session.SetString("UsuarioNombre", empresa.NombreUsuario);
                HttpContext.Session.SetString("Tipo", "Empresa");
            }
            else
            {
                _context.Usuarios.Add(usuario);

                HttpContext.Session.SetString("UsuarioNombre", usuario.Nombres);
                HttpContext.Session.SetString("Tipo", "Usuario");
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
