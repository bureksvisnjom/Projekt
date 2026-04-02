namespace OcjenjivanjeTrgovina.Models
{
    public class Kupnja
    {
        public int Id { get; set; }
        public int KorisnikId { get; set; }
        public int TrgovinaId { get; set; }
        public DateTime DatumKupnje { get; set; }
        public decimal UkupanIznos { get; set; }
        public string Napomena { get; set; }

        public Korisnik Korisnik { get; set; }
        public Trgovina Trgovina { get; set; }
        public List<KupnjaProizvod> StavkeKupnje { get; set; }

        public Kupnja()
        {
            StavkeKupnje = new List<KupnjaProizvod>();
        }
    }
}
