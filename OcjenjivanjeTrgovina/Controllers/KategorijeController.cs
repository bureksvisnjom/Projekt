using Microsoft.AspNetCore.Mvc;
using OcjenjivanjeTrgovina.Services;

namespace OcjenjivanjeTrgovina.Controllers
{
    public class KategorijeController : Controller
    {
        private readonly KategorijaMockRepository _kategorijaRepository;

        public KategorijeController(KategorijaMockRepository kategorijaRepository)
        {
            _kategorijaRepository = kategorijaRepository;
        }

        // GET: Kategorije
        public async Task<IActionResult> Index()
        {
            var kategorije = await _kategorijaRepository.GetAll();
            ViewData["Title"] = "Kategorije";
            return View(kategorije);
        }

        // GET: Kategorije/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var kategorija = await _kategorijaRepository.GetById(id.Value);
            if (kategorija == null)
                return NotFound();

            ViewData["Title"] = $"{kategorija.Naziv} - Detalji";
            return View(kategorija);
        }
    }
}
