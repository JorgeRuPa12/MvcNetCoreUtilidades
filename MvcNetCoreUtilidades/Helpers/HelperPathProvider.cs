using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace MvcNetCoreUtilidades.Helpers
{
    public enum Folders { Images, Facturas, Uploads, Temporal }
    public class HelperPathProvider
    {
        private IWebHostEnvironment hostEnvironment;
        private IServer server;
        private IHttpContextAccessor accessor;

        public HelperPathProvider(IWebHostEnvironment hostEnvironment, IServer server, IHttpContextAccessor accessor)
        {
            this.hostEnvironment = hostEnvironment;
            this.server = server;
            this.accessor = accessor;
        }

        public string MapPath(string filename, Folders folder)
        {
            string carpeta = "";
            if (folder == Folders.Images )
            {
                carpeta = "images";
            }
            else if(folder == Folders.Facturas)
            {
                carpeta = "facturas";
            }
            else if(folder == Folders.Uploads)
            {
                carpeta = "uploads";
            }
            else if(folder == Folders.Temporal)
            {
                carpeta = "temp";
            }
            string rootPath = this.hostEnvironment.WebRootPath;
            string path = Path.Combine(rootPath, carpeta, filename);

            return path;
        }
        public string MapUrlPath(string fileName, Folders folder)
        {
            
            string carpeta = "";
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
            var adresses = this.server.Features.Get<IServerAddressesFeature>().Addresses;
            string serverUrl = adresses.FirstOrDefault();
            string path = Path.Combine(serverUrl, carpeta, fileName);

            return path;
        }

        //public string MapUrlPathContextAccessor(string fileName, Folders folder)
        //{
            
        //    string carpeta = "";
        //    if (folder == Folders.Images)
        //    {
        //        carpeta = "images";
        //    }
        //    else if (folder == Folders.Facturas)
        //    {
        //        carpeta = "facturas";
        //    }
        //    else if (folder == Folders.Uploads)
        //    {
        //        carpeta = "uploads";
        //    }
        //    else if (folder == Folders.Temporal)
        //    {
        //        carpeta = "temp";
        //    }
        //    var adresses = accessor.HttpContext.Request;
        //    string host = 
        //    string path = Path.Combine(host, carpeta, fileName);

        //    return path;
        //}
    }
}
