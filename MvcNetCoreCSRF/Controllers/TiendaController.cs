using Microsoft.AspNetCore.Mvc;

namespace MvcNetCoreCSRF.Controllers
{
    public class TiendaController : Controller
    {
        public IActionResult Productos()
        {
            if (HttpContext.Session.GetString("USUARIO") == null)
            {
                return RedirectToAction("Denied", "Managed");
            }
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Productos(string direccion, string[] producto)
        {
            if (HttpContext.Session.GetString("USUARIO") == null)
            {
                return RedirectToAction("Denied", "Managed");
            }
            else
            {
                TempData["PRODUCTOS"] = producto;
                TempData["DIRECCION"] = direccion;
                return RedirectToAction("PedidoFinal");

            }

        }

        public IActionResult PedidoFinal()
        {
            string[] productos = TempData["PRODUCTOS"] as string[];
            ViewData["DIRECCION"] = TempData["DIRECCION"];
            return View(productos);
        }
    }
}
