namespace OcjenjivanjeTrgovina.Models
{
    public class Korisnik
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public DateTime DatumRegistracije { get; set; }
        public string Telefon { get; set; }

        public List<Ocjena> Ocjene { get; set; }
        public List<Kupnja> Kupnje { get; set; }

        public Korisnik()
        {
            Ocjene = new List<Ocjena>();
            Kupnje = new List<Kupnja>();
        }
    }
}
