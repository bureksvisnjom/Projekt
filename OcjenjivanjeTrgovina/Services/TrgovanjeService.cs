using OcjenjivanjeTrgovina.Models;

namespace OcjenjivanjeTrgovina.Services
{
    public class TrgovanjeService
    {
        /// <summary>
        /// Async metoda koja simulira učitavanje trgovina iz baze podataka
        /// Koristi Task.Delay za simulaciju sporoga pristupa bazi
        /// </summary>
        public async Task<List<Trgovina>> DohvatiTrgoveAsync(List<Trgovina> trgovine)
        {
            Console.WriteLine("[ASYNC] Započeto učitavanje trgovina iz baze...");
            await Task.Delay(2000);
            Console.WriteLine("[ASYNC] Učitavanje trgovina završeno!");
            return trgovine;
        }

        /// <summary>
        /// Async metoda koja simulira učitavanje proizvoda za određenu trgovinu
        /// </summary>
        public async Task<List<Proizvod>> DohvatiProizvodeTrgoveAsync(Trgovina trgovina)
        {
            Console.WriteLine($"[ASYNC] Učitavanje proizvoda za {trgovina.Naziv}...");
            await Task.Delay(1500);
            Console.WriteLine($"[ASYNC] Učitani proizvodi za {trgovina.Naziv}!");
            return trgovina.Proizvodi;
        }

        /// <summary>
        /// Async metoda koja simulira učitavanje ocjena za sve trgovine
        /// </summary>
        public async Task<List<Ocjena>> DohvatiSveOcjeneAsync(List<Trgovina> trgovine)
        {
            Console.WriteLine("[ASYNC] Započeto učitavanje svih ocjena iz baze...");
            await Task.Delay(3000);
            
            var sveOcjene = new List<Ocjena>();
            foreach (var trgovina in trgovine)
            {
                sveOcjene.AddRange(trgovina.Ocjene);
            }
            
            Console.WriteLine("[ASYNC] Sve ocjene su učitane!");
            return sveOcjene;
        }

        /// <summary>
        /// Async metoda koja simulira učitavanje kupnji korisnika
        /// </summary>
        public async Task<List<Kupnja>> DohvatiKupnjeKorisnikaAsync(Korisnik korisnik, List<Kupnja> sveKupnje)
        {
            Console.WriteLine($"[ASYNC] Učitavanje kupnji za korisnika {korisnik.Ime} {korisnik.Prezime}...");
            await Task.Delay(1000);
            
            var kupnjeKorisnika = sveKupnje.Where(k => k.KorisnikId == korisnik.Id).ToList();
            
            Console.WriteLine($"[ASYNC] Učitane kupnje za {korisnik.Ime}!");
            return kupnjeKorisnika;
        }

        /// <summary>
        /// Async metoda koja simulira izračun prosječne ocjene za trgovinu
        /// </summary>
        public async Task<(string NazivTrgove, double Prosijek)> IzracunajProsjecnuOcjenuAsync(Trgovina trgovina)
        {
            Console.WriteLine($"[ASYNC] Izračunavanje prosječne ocjene za {trgovina.Naziv}...");
            await Task.Delay(1200);
            
            double prosijek = trgovina.Ocjene.Count > 0 
                ? trgovina.Ocjene.Average(o => o.Vrijednost) 
                : 0;
            
            Console.WriteLine($"[ASYNC] Prosječna ocjena za {trgovina.Naziv} je {prosijek:F2}");
            return (trgovina.Naziv, prosijek);
        }

        /// <summary>
        /// Async metoda koja paralelno učitava podatke za sve trgovine
        /// </summary>
        public async Task<Dictionary<string, List<Proizvod>>> DohvatiProizvodeSvihTrgoveAsync(List<Trgovina> trgovine)
        {
            Console.WriteLine("[ASYNC] Paralelno učitavanje proizvoda svih trgovina...");
            
            var tasks = new List<Task<(string, List<Proizvod>)>>();
            
            foreach (var trgovina in trgovine)
            {
                tasks.Add(DohvatiProizvodeTrgoveParalelnoAsync(trgovina));
            }
            
            var rezultati = await Task.WhenAll(tasks);
            
            var rezultatDictionary = new Dictionary<string, List<Proizvod>>();
            foreach (var (naziv, proizvodi) in rezultati)
            {
                rezultatDictionary[naziv] = proizvodi;
            }
            
            Console.WriteLine("[ASYNC] Svi proizvodi su učitani!");
            return rezultatDictionary;
        }

        /// <summary>
        /// Privatna async pomoćna metoda za paralelno učitavanje
        /// </summary>
        private async Task<(string, List<Proizvod>)> DohvatiProizvodeTrgoveParalelnoAsync(Trgovina trgovina)
        {
            await Task.Delay(1500);
            return (trgovina.Naziv, trgovina.Proizvodi);
        }

        /// <summary>
        /// Async metoda koja simulira popis kupnje
        /// </summary>
        public async Task<decimal> IzracunajUkupanIznosKupnjeAsync(Kupnja kupnja)
        {
            Console.WriteLine($"[ASYNC] Izračunavanje ukupnog iznosa kupnje ID: {kupnja.Id}...");
            await Task.Delay(800);
            
            decimal ukupno = kupnja.StavkeKupnje.Sum(s => s.Cijena * s.Količina);
            
            Console.WriteLine($"[ASYNC] Ukupan iznos: {ukupno}€");
            return ukupno;
        }

        // Statička kolekcija za simulaciju baze podataka
        private static List<Trgovina> _trgovine = new List<Trgovina>();

        /// <summary>
        /// Inicijalizacija statičke liste sa podacima
        /// </summary>
        public void InicijalizirajTrgovine(List<Trgovina> trgovine)
        {
            _trgovine = new List<Trgovina>(trgovine);
        }

        /// <summary>
        /// Dohvata sve trgovine iz "baze" - async verzija
        /// </summary>
        public async Task<List<Trgovina>> DohvatiSveTrgovine()
        {
            Console.WriteLine("[ASYNC] Dohvaćanje svih trgovina...");
            await Task.Delay(500);
            return new List<Trgovina>(_trgovine);
        }

        /// <summary>
        /// Dohvata specifičnu trgovinu po ID - async verzija
        /// </summary>
        public async Task<Trgovina> DohvatiTrgovinu(int id)
        {
            Console.WriteLine($"[ASYNC] Dohvaćanje trgovine sa ID: {id}...");
            await Task.Delay(300);
            return _trgovine.FirstOrDefault(t => t.Id == id);
        }

        /// <summary>
        /// Kreira novu trgovinu - async verzija
        /// </summary>
        public async Task<Trgovina> KreirajTrgovinu(Trgovina trgovina)
        {
            Console.WriteLine($"[ASYNC] Kreiranje nove trgovine: {trgovina.Naziv}...");
            await Task.Delay(1000);
            
            // Postavi ID kao najveći ID + 1
            int noviId = _trgovine.Any() ? _trgovine.Max(t => t.Id) + 1 : 1;
            trgovina.Id = noviId;
            
            _trgovine.Add(trgovina);
            
            Console.WriteLine($"[ASYNC] Trgovina {trgovina.Naziv} je kreirana sa ID: {noviId}");
            return trgovina;
        }

        /// <summary>
        /// Ažurira stalnu trgovinu - async verzija
        /// </summary>
        public async Task<bool> AzurirajTrgovinu(Trgovina trgovina)
        {
            Console.WriteLine($"[ASYNC] Ažuriranje trgovine: {trgovina.Naziv}...");
            await Task.Delay(800);
            
            var postojeca = _trgovine.FirstOrDefault(t => t.Id == trgovina.Id);
            if (postojeca == null)
                return false;
            
            postojeca.Naziv = trgovina.Naziv;
            postojeca.Adresa = trgovina.Adresa;
            postojeca.Grad = trgovina.Grad;
            postojeca.Telefon = trgovina.Telefon;
            postojeca.Email = trgovina.Email;
            
            Console.WriteLine($"[ASYNC] Trgovina {trgovina.Naziv} je ažurirana");
            return true;
        }

        /// <summary>
        /// Briše trgovinu - async verzija
        /// </summary>
        public async Task<bool> BrisiTrgovinu(int id)
        {
            Console.WriteLine($"[ASYNC] Brisanje trgovine sa ID: {id}...");
            await Task.Delay(700);
            
            var trgovina = _trgovine.FirstOrDefault(t => t.Id == id);
            if (trgovina == null)
                return false;
            
            _trgovine.Remove(trgovina);
            
            Console.WriteLine($"[ASYNC] Trgovina sa ID: {id} je obrisana");
            return true;
        }
    }
}
