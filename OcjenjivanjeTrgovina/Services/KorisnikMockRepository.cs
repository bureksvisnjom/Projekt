using OcjenjivanjeTrgovina.Models;

namespace OcjenjivanjeTrgovina.Services
{
    public class KorisnikMockRepository
    {
        private static List<Korisnik> _korisnici = new();

        public KorisnikMockRepository()
        {
            InicijalizirajPodatke();
        }

        private void InicijalizirajPodatke()
        {
            if (_korisnici.Count == 0)
            {
                _korisnici = new List<Korisnik>
                {
                    new Korisnik 
                    { 
                        Id = 1, 
                        Ime = "Marko", 
                        Prezime = "Horvat", 
                        Email = "marko@example.com", 
                        Telefon = "0981234567",
                        DatumRegistracije = new DateTime(2023, 1, 15)
                    },
                    new Korisnik 
                    { 
                        Id = 2, 
                        Ime = "Ana", 
                        Prezime = "Horvat", 
                        Email = "ana@example.com", 
                        Telefon = "0987654321",
                        DatumRegistracije = new DateTime(2023, 3, 20)
                    },
                    new Korisnik 
                    { 
                        Id = 3, 
                        Ime = "Petar", 
                        Prezime = "Petrović", 
                        Email = "petar@example.com", 
                        Telefon = "0989999999",
                        DatumRegistracije = new DateTime(2023, 6, 10)
                    },
                };
            }
        }

        public async Task<List<Korisnik>> GetAll()
        {
            await Task.Delay(300);
            return new List<Korisnik>(_korisnici);
        }

        public async Task<Korisnik> GetById(int id)
        {
            await Task.Delay(200);
            return _korisnici.FirstOrDefault(k => k.Id == id);
        }
    }
}
