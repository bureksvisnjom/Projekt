namespace OcjenjivanjeTrgovina.Models
{
    public class KupnjaProizvod
    {
        public int KupnjaId { get; set; }
        public int ProizvodId { get; set; }
        public int Količina { get; set; }
        public decimal Cijena { get; set; }

        public Kupnja Kupnja { get; set; }
        public Proizvod Proizvod { get; set; }
    }
}
