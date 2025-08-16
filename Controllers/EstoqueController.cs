using Microsoft.AspNetCore.Mvc;

namespace FastPDV.Controllers
{
    public class EstoqueController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Gerenciamento de Estoque";
            return View();
        }
    }
}