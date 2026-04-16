using Microsoft.AspNetCore.Mvc;
using OcjenjivanjeTrgovina.Services;

namespace OcjenjivanjeTrgovina.Controllers
{
    public class ProizvodiController : Controller
    {
        private readonly ProizvodiMockRepository _proizvodiRepository;
        private readonly TrgovanjeService _trgovanjeService;

        public ProizvodiController(ProizvodiMockRepository proizvodiRepository, TrgovanjeService trgovanjeService)
        {
            _proizvodiRepository = proizvodiRepository;
            _trgovanjeService = trgovanjeService;
        }

        // GET: Proizvodi
        public async Task<IActionResult> Index()
        {
            var proizvodi = await _proizvodiRepository.GetAll();
            ViewData["Title"] = "Proizvodi";
            return View(proizvodi);
        }

        // GET: Proizvodi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var proizvod = await _proizvodiRepository.GetById(id.Value);
            if (proizvod == null)
                return NotFound();

            ViewData["Title"] = $"{proizvod.Naziv} - Detalji";
            return View(proizvod);
        }
    }
}
