namespace OcjenjivanjeTrgovina.Models
{
    public class Kategorija
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }

        public List<Proizvod> Proizvodi { get; set; }

        public Kategorija()
        {
            Proizvodi = new List<Proizvod>();
        }
    }
}
