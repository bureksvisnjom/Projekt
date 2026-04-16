using Microsoft.AspNetCore.Mvc;
using OcjenjivanjeTrgovina.Services;

namespace OcjenjivanjeTrgovina.Controllers
{
    public class KupnjeController : Controller
    {
        private readonly KupnjeMockRepository _kupnjeRepository;
        private readonly KorisnikMockRepository _korisnikRepository;

        public KupnjeController(KupnjeMockRepository kupnjeRepository, KorisnikMockRepository korisnikRepository)
        {
            _kupnjeRepository = kupnjeRepository;
            _korisnikRepository = korisnikRepository;
        }

        // GET: Kupnje
        public async Task<IActionResult> Index()
        {
            var kupnje = await _kupnjeRepository.GetAll();
            ViewData["Title"] = "Kupnje";
            return View(kupnje);
        }

        // GET: Kupnje/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var kupnja = await _kupnjeRepository.GetById(id.Value);
            if (kupnja == null)
                return NotFound();

            ViewData["Title"] = $"Kupnja - Detalji";
            return View(kupnja);
        }
    }
}
