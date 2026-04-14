namespace OcjenjivanjeTrgovina.Models
{
    public class Ocjena
    {
        public int Id { get; set; }
        public int TrgovinaId { get; set; }
        public int KorisnikId { get; set; }
        public int Vrijednost { get; set; }
        public string Komentar { get; set; }
        public DateTime DatumOcjene { get; set; }
        public OcjeneEnum VrstaOcjene { get; set; }

        public Korisnik Korisnik { get; set; }
        public Trgovina Trgovina { get; set; }
    }
}
