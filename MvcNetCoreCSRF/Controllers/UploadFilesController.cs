using Microsoft.AspNetCore.Mvc;
using MvcNetCoreCSRF.Helpers;

namespace MvcNetCoreCSRF.Controllers
{
    public class UploadFilesController : Controller
    {
        //private IWebHostEnvironment hostEnvironment;
        private HelperPathProvider helperPath;

        public UploadFilesController(HelperPathProvider helperPath)
        {
            this.helperPath = helperPath;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SubirFichero()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SubirFichero(IFormFile fichero)
        {
            //string tempFolder = Path.GetTempPath();
            string fileName = fichero.FileName;
            string path = this.helperPath.MapPath(fileName, Folders.Images);

             
            string urlPath = this.helperPath.MapUrlPath(fileName, Folders.Images);

            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                await fichero.CopyToAsync(stream);
            }

            ViewData["MENSAJE"] = "Fichero subido a " + path;
            ViewData["URL"] = urlPath;
            return View();
        }
    }
}
