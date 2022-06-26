using Lanches_Mac1.Areas.Admin.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace Lanches_Mac1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminGraficoController : Controller
    {
        private readonly GraficoVendasService _graficoVendas;

        public AdminGraficoController(GraficoVendasService graficoVendas)
        {
            _graficoVendas = graficoVendas ?? throw
                new ArgumentNullException(nameof(graficoVendas));
        }

        public JsonResult VendasLanches(int dias)
        {
            var LanchesVendasTotais = _graficoVendas.GetVendasLanches(dias);
            return Json(LanchesVendasTotais);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult VendasMensal()
        {
            return View();
        }

        public IActionResult VendasSemanal()
        {
            return View();
        }
    }
}
