using Microsoft.AspNetCore.Mvc;
using OcjenjivanjeTrgovina.Services;

namespace OcjenjivanjeTrgovina.Controllers
{
    public class KorisnikController : Controller
    {
        private readonly KorisnikMockRepository _korisnikRepository;

        public KorisnikController(KorisnikMockRepository korisnikRepository)
        {
            _korisnikRepository = korisnikRepository;
        }

        // GET: Korisnik
        public async Task<IActionResult> Index()
        {
            var korisnici = await _korisnikRepository.GetAll();
            ViewData["Title"] = "Korisnici";
            return View(korisnici);
        }

        // GET: Korisnik/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var korisnik = await _korisnikRepository.GetById(id.Value);
            if (korisnik == null)
                return NotFound();

            ViewData["Title"] = $"{korisnik.Ime} {korisnik.Prezime} - Detalji";
            return View(korisnik);
        }
    }
}
