using OcjenjivanjeTrgovina.Models;

namespace OcjenjivanjeTrgovina.Services
{
    public class ProizvodiMockRepository
    {
        private static List<Proizvod> _proizvodi = new();

        public ProizvodiMockRepository()
        {
            InicijalizirajPodatke();
        }

        private void InicijalizirajPodatke()
        {
            if (_proizvodi.Count == 0)
            {
                _proizvodi = new List<Proizvod>
                {
                    new Proizvod { Id = 1, Naziv = "Kruh", Opis = "Svježi kruh od pšenice", Cijena = 5.50m, TrgovinaId = 1, KategorijId = 1, Dostupan = true },
                    new Proizvod { Id = 2, Naziv = "Mlijeko", Opis = "Pasterizovano mlijeko", Cijena = 8.99m, TrgovinaId = 1, KategorijId = 1, Dostupan = true },
                    new Proizvod { Id = 3, Naziv = "Laptop", Opis = "Gaming laptop", Cijena = 5999.99m, TrgovinaId = 3, KategorijId = 2, Dostupan = true },
                    new Proizvod { Id = 4, Naziv = "Traperice", Opis = "Muške plave traperice", Cijena = 199.99m, TrgovinaId = 2, KategorijId = 3, Dostupan = true },
                    new Proizvod { Id = 5, Naziv = "Jabuke", Opis = "Svježe jabuke", Cijena = 12.50m, TrgovinaId = 2, KategorijId = 1, Dostupan = false },
                };
            }
        }

        public async Task<List<Proizvod>> GetAll()
        {
            await Task.Delay(300);
            return new List<Proizvod>(_proizvodi);
        }

        public async Task<Proizvod> GetById(int id)
        {
            await Task.Delay(200);
            return _proizvodi.FirstOrDefault(p => p.Id == id);
        }

        public async Task<List<Proizvod>> GetByTrgovina(int trgovinaId)
        {
            await Task.Delay(250);
            return _proizvodi.Where(p => p.TrgovinaId == trgovinaId).ToList();
        }

        public async Task<List<Proizvod>> GetByKategorija(int kategorijaId)
        {
            await Task.Delay(250);
            return _proizvodi.Where(p => p.KategorijId == kategorijaId).ToList();
        }
    }
}
