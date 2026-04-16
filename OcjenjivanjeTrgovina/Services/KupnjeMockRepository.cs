using OcjenjivanjeTrgovina.Models;

namespace OcjenjivanjeTrgovina.Services
{
    public class KupnjeMockRepository
    {
        private static List<Kupnja> _kupnje = new();

        public KupnjeMockRepository()
        {
            InicijalizirajPodatke();
        }

        private void InicijalizirajPodatke()
        {
            if (_kupnje.Count == 0)
            {
                _kupnje = new List<Kupnja>
                {
                    new Kupnja 
                    { 
                        Id = 1, 
                        KorisnikId = 1, 
                        TrgovinaId = 1,
                        DatumKupnje = new DateTime(2024, 1, 8),
                        UkupanIznos = 14.49m,
                        Napomena = "Nije dostavljeno"
                    },
                    new Kupnja 
                    { 
                        Id = 2, 
                        KorisnikId = 2, 
                        TrgovinaId = 2,
                        DatumKupnje = new DateTime(2024, 1, 14),
                        UkupanIznos = 199.99m,
                        Napomena = ""
                    },
                    new Kupnja 
                    { 
                        Id = 3, 
                        KorisnikId = 3, 
                        TrgovinaId = 3,
                        DatumKupnje = new DateTime(2024, 1, 18),
                        UkupanIznos = 5999.99m,
                        Napomena = "Prijavljen garantni slučaj"
                    },
                };
            }
        }

        public async Task<List<Kupnja>> GetAll()
        {
            await Task.Delay(300);
            return new List<Kupnja>(_kupnje);
        }

        public async Task<Kupnja> GetById(int id)
        {
            await Task.Delay(200);
            return _kupnje.FirstOrDefault(k => k.Id == id);
        }

        public async Task<List<Kupnja>> GetByKorisnik(int korisnikId)
        {
            await Task.Delay(250);
            return _kupnje.Where(k => k.KorisnikId == korisnikId).ToList();
        }

        public async Task<List<Kupnja>> GetByTrgovina(int trgovinaId)
        {
            await Task.Delay(250);
            return _kupnje.Where(k => k.TrgovinaId == trgovinaId).ToList();
        }
    }
}
