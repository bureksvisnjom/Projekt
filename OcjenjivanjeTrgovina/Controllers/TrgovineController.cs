using Microsoft.AspNetCore.Mvc;
using OcjenjivanjeTrgovina.Models;
using OcjenjivanjeTrgovina.Services;

namespace OcjenjivanjeTrgovina.Controllers
{
    public class TrgovineController : Controller
    {
        private readonly TrgovanjeService _trgovanjeService;

        public TrgovineController(TrgovanjeService trgovanjeService)
        {
            _trgovanjeService = trgovanjeService;
        }

        // GET: Trgovine
        public async Task<IActionResult> Index()
        {
            var trgovine = await _trgovanjeService.DohvatiSveTrgovine();
            return View(trgovine);
        }

        // GET: Trgovine/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var trgovina = await _trgovanjeService.DohvatiTrgovinu(id.Value);
            if (trgovina == null)
                return NotFound();

            return View(trgovina);
        }

        // GET: Trgovine/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trgovine/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Naziv,Adresa,Grad,DatumOtvaranja,Telefon,Email")] Trgovina trgovina)
        {
            if (ModelState.IsValid)
            {
                await _trgovanjeService.KreirajTrgovinu(trgovina);
                return RedirectToAction(nameof(Index));
            }
            return View(trgovina);
        }
    }
}
