using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Mvc;

namespace MvcNetCoreCSRF.Helpers
{

    public enum Folders { Images, Facturas, Uploads, Temporal}

    public class HelperPathProvider
    {
        private IServer server;
        private IWebHostEnvironment hostEnvironment;

        public HelperPathProvider(IWebHostEnvironment hostEnvironment, IServer server)
        {
            this.hostEnvironment = hostEnvironment;
            this.server = server;
        }

        public string MapPath(string fileName, Folders folder)
        {
            string carpeta = "";
            if (folder == Folders.Images)
            {
                carpeta = "images";

            }else if(folder == Folders.Facturas) 
            { 
                carpeta = "facturas"; 

            }else if (folder == Folders.Uploads)
            {
                carpeta = "uploads";

            }
            else if (folder == Folders.Temporal)
            {
                carpeta = "temp";

            }

            string rootPath = this.hostEnvironment.WebRootPath;
            string path = Path.Combine(rootPath, carpeta, fileName);
            return path;
        }

        public string MapUrlPath(string fileName, Folders folder)
        {
            string carpeta = "";

            // Asignar el nombre de la carpeta según el tipo de folder
            if (folder == Folders.Images)
            {
                carpeta = "images";
            }
            else if (folder == Folders.Facturas)
            {
                carpeta = "facturas";
            }
            else if (folder == Folders.Uploads)
            {
                carpeta = "uploads";
            }
            else if (folder == Folders.Temporal)
            {
                carpeta = "temp";
            }

            var addresses = this.server.Features.Get<IServerAddressesFeature>().Addresses;

            string serverURL = addresses.FirstOrDefault();
            string urlPath = serverURL + "/" + carpeta + "/" + fileName;    
            return urlPath;
        }

    }
}
