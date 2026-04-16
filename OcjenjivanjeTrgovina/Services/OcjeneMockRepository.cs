using OcjenjivanjeTrgovina.Models;

namespace OcjenjivanjeTrgovina.Services
{
    public class OcjeneMockRepository
    {
        private static List<Ocjena> _ocjene = new();

        public OcjeneMockRepository()
        {
            InicijalizirajPodatke();
        }

        private void InicijalizirajPodatke()
        {
            if (_ocjene.Count == 0)
            {
                _ocjene = new List<Ocjena>
                {
                    new Ocjena 
                    { 
                        Id = 1, 
                        TrgovinaId = 1, 
                        KorisnikId = 1, 
                        Vrijednost = 5,
                        Komentar = "Odličan izbor proizvoda!",
                        DatumOcjene = new DateTime(2024, 1, 10),
                        VrstaOcjene = OcjeneEnum.KvalitetaProizvoda
                    },
                    new Ocjena 
                    { 
                        Id = 2, 
                        TrgovinaId = 1, 
                        KorisnikId = 2, 
                        Vrijednost = 4,
                        Komentar = "Dobra usluga, moguće bolje cijene",
                        DatumOcjene = new DateTime(2024, 1, 12),
                        VrstaOcjene = OcjeneEnum.CjenovnikKompetitivnost
                    },
                    new Ocjena 
                    { 
                        Id = 3, 
                        TrgovinaId = 2, 
                        KorisnikId = 1, 
                        Vrijednost = 3,
                        Komentar = "Osrednja usluga",
                        DatumOcjene = new DateTime(2024, 1, 15),
                        VrstaOcjene = OcjeneEnum.UslugaKorisnika
                    },
                    new Ocjena 
                    { 
                        Id = 4, 
                        TrgovinaId = 3, 
                        KorisnikId = 3, 
                        Vrijednost = 5,
                        Komentar = "Najbolja cijena za laptope!",
                        DatumOcjene = new DateTime(2024, 1, 20),
                        VrstaOcjene = OcjeneEnum.CjenovnikKompetitivnost
                    },
                };
            }
        }

        public async Task<List<Ocjena>> GetAll()
        {
            await Task.Delay(300);
            return new List<Ocjena>(_ocjene);
        }

        public async Task<Ocjena> GetById(int id)
        {
            await Task.Delay(200);
            return _ocjene.FirstOrDefault(o => o.Id == id);
        }

        public async Task<List<Ocjena>> GetByTrgovina(int trgovinaId)
        {
            await Task.Delay(250);
            return _ocjene.Where(o => o.TrgovinaId == trgovinaId).OrderByDescending(o => o.DatumOcjene).ToList();
        }

        public async Task<List<Ocjena>> GetByKorisnik(int korisnikId)
        {
            await Task.Delay(250);
            return _ocjene.Where(o => o.KorisnikId == korisnikId).OrderByDescending(o => o.DatumOcjene).ToList();
        }

        public async Task<double> GetAveragRating(int trgovinaId)
        {
            await Task.Delay(200);
            var ratings = _ocjene.Where(o => o.TrgovinaId == trgovinaId).ToList();
            return ratings.Count > 0 ? ratings.Average(o => o.Vrijednost) : 0;
        }
    }
}
