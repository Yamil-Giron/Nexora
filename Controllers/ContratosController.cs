using Microsoft.AspNetCore.Mvc;
using Nexora.Models;

namespace Nexora.Controllers
{
    public class ContratosController : Controller
    {
        private readonly NexoraContext _context;

        public ContratosController(NexoraContext context)
        {
            _context = context;
        }

        [HttpGet]
public IActionResult Create(int planId)
{
    var plan = _context.Planes.FirstOrDefault(p => p.IdPlan == planId);

    var tipo = HttpContext.Session.GetString("Tipo");
    var nombre = HttpContext.Session.GetString("UsuarioNombre");
    var correo = HttpContext.Session.GetString("Correo");

    ViewBag.Plan = plan;
    ViewBag.Nombre = nombre;
    ViewBag.Tipo = tipo;
    ViewBag.Correo = correo;
    ViewBag.Fecha = DateTime.Now.ToString("dd/MM/yyyy");

    return View();
}

[HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Create(Contrato contrato)
{
    contrato.FechaInicio = DateTime.Now;
    contrato.Estado = "Pendiente";
    contrato.Correo = HttpContext.Session.GetString("Correo") ?? "";

    var tipo = HttpContext.Session.GetString("Tipo");

    if (tipo == "Usuario")
    {
        var usuarioIdStr = HttpContext.Session.GetString("UsuarioId");
        if (int.TryParse(usuarioIdStr, out int usuarioId))
        {
            contrato.IdUsuario = usuarioId;
        }
    }
    else if (tipo == "Empresa")
    {
        var empresaIdStr = HttpContext.Session.GetString("EmpresaId");
        if (int.TryParse(empresaIdStr, out int empresaId))
        {
            contrato.IdEmpresa = empresaId;
        }
    }

    _context.Contratos.Add(contrato);
    _context.SaveChanges();

    return RedirectToAction("Index");
}


        }
    }
