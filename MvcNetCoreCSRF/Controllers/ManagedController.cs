using Microsoft.AspNetCore.Mvc;

namespace MvcNetCoreCSRF.Controllers
{
    public class ManagedController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string usuario, string password) 
        {
            if (usuario.ToLower() == "admin" && password.ToLower() == "admin")
            {
                HttpContext.Session.SetString("USUARIO", usuario);
                return RedirectToAction("Productos", "Tienda");
            }
            else
            {
                ViewData["MENSAJE"] = "Usuario/Password incorrecta";
                return View();
            }
        }

        public IActionResult Denied()
        {
            return View();
        }
    }
}
