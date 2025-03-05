using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration;
using MvcNetCoreUtilidades.Helpers;

namespace MvcNetCoreUtilidades.Controllers
{
    public class UploadFilesController : Controller
    {
        private HelperPathProvider helper;
        public UploadFilesController(HelperPathProvider helper)
        {
            this.helper = helper;

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
        public async  Task<IActionResult> SubirFichero(IFormFile fichero, string folder)
        {;
            string fileName = fichero.FileName;
            string path = "";
            if(folder == "images")
            {
                path = this.helper.MapPath(fileName, Folders.Images);
                ViewData["PATH"] = this.helper.MapUrlPath(fileName, Folders.Images);
            }
            else if(folder == "facturas")
            {
                path = this.helper.MapPath(fileName, Folders.Facturas);
                ViewData["PATH"] = this.helper.MapUrlPath(fileName, Folders.Facturas);
            }
            else if(folder == "uploads")
            {
                path = this.helper.MapPath(fileName, Folders.Uploads);
                ViewData["PATH"] = this.helper.MapUrlPath(fileName, Folders.Uploads);
            }
            else if(folder == "temp")
            {
                path = this.helper.MapPath(fileName, Folders.Temporal);
                ViewData["PATH"] = this.helper.MapUrlPath(fileName, Folders.Temporal);
            }

            using (Stream stream = new FileStream(path, FileMode.Create))

            {

                await fichero.CopyToAsync(stream);

            }

            ViewData["MENSAJE"] = "FICHERO SUBIDO A " + path;

            return View();
        }
    }
}
