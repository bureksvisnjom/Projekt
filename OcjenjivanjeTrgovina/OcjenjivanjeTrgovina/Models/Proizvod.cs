namespace OcjenjivanjeTrgovina.Models
{
    public class Proizvod
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public decimal Cijena { get; set; }
        public int TrgovinaId { get; set; }
        public int KategorijId { get; set; }
        public bool Dostupan { get; set; }

        public Trgovina Trgovina { get; set; }
        public Kategorija Kategorija { get; set; }
        public List<KupnjaProizvod> KupnjeProizvoda { get; set; }

        public Proizvod()
        {
            KupnjeProizvoda = new List<KupnjaProizvod>();
        }
    }
}
