using Microsoft.AspNetCore.Mvc;
using OcjenjivanjeTrgovina.Services;

namespace OcjenjivanjeTrgovina.Controllers
{
    public class OcjeneController : Controller
    {
        private readonly OcjeneMockRepository _ocjeneRepository;

        public OcjeneController(OcjeneMockRepository ocjeneRepository)
        {
            _ocjeneRepository = ocjeneRepository;
        }

        // GET: Ocjene
        public async Task<IActionResult> Index()
        {
            var ocjene = await _ocjeneRepository.GetAll();
            ViewData["Title"] = "Ocjene";
            return View(ocjene);
        }

        // GET: Ocjene/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var ocjena = await _ocjeneRepository.GetById(id.Value);
            if (ocjena == null)
                return NotFound();

            ViewData["Title"] = "Ocjena - Detalji";
            return View(ocjena);
        }
    }
}
