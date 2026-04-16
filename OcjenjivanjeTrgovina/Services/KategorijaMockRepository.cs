using OcjenjivanjeTrgovina.Models;

namespace OcjenjivanjeTrgovina.Services
{
    public class KategorijaMockRepository
    {
        private static List<Kategorija> _kategorije = new();

        public KategorijaMockRepository()
        {
            InicijalizirajPodatke();
        }

        private void InicijalizirajPodatke()
        {
            if (_kategorije.Count == 0)
            {
                _kategorije = new List<Kategorija>
                {
                    new Kategorija 
                    { 
                        Id = 1, 
                        Naziv = "Prehrambeni proizvodi", 
                        Opis = "Svježa hrana i napitci",
                        Proizvodi = new List<Proizvod>()
                    },
                    new Kategorija 
                    { 
                        Id = 2, 
                        Naziv = "Elektronika", 
                        Opis = "Tehnički uređaji i oprema",
                        Proizvodi = new List<Proizvod>()
                    },
                    new Kategorija 
                    { 
                        Id = 3, 
                        Naziv = "Odjeća", 
                        Opis = "Odjevni komadi i obuća",
                        Proizvodi = new List<Proizvod>()
                    },
                };
            }
        }

        public async Task<List<Kategorija>> GetAll()
        {
            await Task.Delay(300);
            return new List<Kategorija>(_kategorije);
        }

        public async Task<Kategorija> GetById(int id)
        {
            await Task.Delay(200);
            return _kategorije.FirstOrDefault(k => k.Id == id);
        }

        public async Task<int> GetProductCount(int kategorijaId)
        {
            await Task.Delay(200);
            return _kategorije.FirstOrDefault(k => k.Id == kategorijaId)?.Proizvodi.Count ?? 0;
        }
    }
}
