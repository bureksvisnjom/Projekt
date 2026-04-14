namespace OcjenjivanjeTrgovina.Models
{
    public class Trgovina
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public string Grad { get; set; }
        public DateTime DatumOtvaranja { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }

        public List<Ocjena> Ocjene { get; set; }
        public List<Proizvod> Proizvodi { get; set; }
        public List<Kupnja> Kupnje { get; set; }

        public Trgovina()
        {
            Ocjene = new List<Ocjena>();
            Proizvodi = new List<Proizvod>();
            Kupnje = new List<Kupnja>();
        }
    }
}
