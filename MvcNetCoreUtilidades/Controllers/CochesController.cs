using Microsoft.AspNetCore.Mvc;
using MvcNetCoreUtilidades.Models;

namespace MvcNetCoreUtilidades.Controllers
{
    public class CochesController: Controller
    {
        private List<Coche> Cars;
        public CochesController()
        {
            this.Cars = new List<Coche>
            {
                new Coche {IdCoches = 1, Marca = "Ford", Modelo = "Focus", Imagen = "https://www.ford.es/content/dam/guxeu/rhd/central/cars/2021-focus/launch/gallery/exterior/ford-focus-mca-c519-eu-STL_03_C519_Focus_Ext_Rear_3_4_Static-9x8-1200x1066_gt.jpg.renditions.original.png"},
                new Coche {IdCoches = 2, Marca = "Karin", Modelo = "Kuruma", Imagen = "https://img.gta5-mods.com/q95/images/karin-kuruma-race-spec/a668e5-foto3.png"},
                new Coche {IdCoches = 3, Marca = "Ford", Modelo = "Raptor", Imagen = "https://www.ford.es/content/dam/guxeu/rhd/central/cars/2022-ranger-raptor/pre-launch/gallery/exterior/ford-ranger-eu-P703R_005-16x9-2160x1215.jpg.renditions.original.png"},
            };
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult _CochesPartial()
        {
            return PartialView("_CochesPartial", this.Cars);
        }

        public IActionResult Details(int idcoche)
        {
            Coche car = this.Cars.FirstOrDefault(z => z.IdCoches == idcoche);
            return View(car);
        }
    }
}
