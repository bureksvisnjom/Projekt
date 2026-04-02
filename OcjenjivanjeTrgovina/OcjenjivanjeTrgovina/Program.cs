using OcjenjivanjeTrgovina.Models;
using OcjenjivanjeTrgovina.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

// ===== INICIJALIZACIJA PODATAKA =====

// Kreiraj kategorije
var kategorija1 = new Kategorija 
{ 
    Id = 1, 
    Naziv = "Prehrambeni proizvodi", 
    Opis = "Svježa hrana i napitci" 
};

var kategorija2 = new Kategorija 
{ 
    Id = 2, 
    Naziv = "Elektronika", 
    Opis = "Tehnički uređaji i oprema" 
};

var kategorija3 = new Kategorija 
{ 
    Id = 3, 
    Naziv = "Odjeća", 
    Opis = "Odjevni komadi i obuća" 
};

// Kreiraj korisnike
var korisnik1 = new Korisnik 
{ 
    Id = 1, 
    Ime = "Marko", 
    Prezime = "Horvat", 
    Email = "marko@example.com", 
    Telefon = "0981234567",
    DatumRegistracije = new DateTime(2023, 1, 15) 
};

var korisnik2 = new Korisnik 
{ 
    Id = 2, 
    Ime = "Ana", 
    Prezime = "Horvat", 
    Email = "ana@example.com", 
    Telefon = "0987654321",
    DatumRegistracije = new DateTime(2023, 3, 20) 
};

var korisnik3 = new Korisnik 
{ 
    Id = 3, 
    Ime = "Petar", 
    Prezime = "Petrović", 
    Email = "petar@example.com", 
    Telefon = "0989999999",
    DatumRegistracije = new DateTime(2023, 6, 10) 
};

// Kreiraj trgovine
var trgovina1 = new Trgovina 
{ 
    Id = 1, 
    Naziv = "Trgovina Prima", 
    Adresa = "Trg bana Jelačića 10", 
    Grad = "Zagreb",
    DatumOtvaranja = new DateTime(2020, 5, 1),
    Telefon = "014880123",
    Email = "prima@example.com" 
};

var trgovina2 = new Trgovina 
{ 
    Id = 2, 
    Naziv = "Supermarket Zlata", 
    Adresa = "Radnička cesta 50", 
    Grad = "Zagreb",
    DatumOtvaranja = new DateTime(2018, 3, 15),
    Telefon = "014880456",
    Email = "zlata@example.com" 
};

var trgovina3 = new Trgovina 
{ 
    Id = 3, 
    Naziv = "ElektroShop", 
    Adresa = "Kneza Miloša 1", 
    Grad = "Zagreb",
    DatumOtvaranja = new DateTime(2019, 9, 20),
    Telefon = "014880789",
    Email = "elektroshop@example.com" 
};

// Kreiraj proizvode
var proizvod1 = new Proizvod 
{ 
    Id = 1, 
    Naziv = "Hleb", 
    Opis = "Svježi kruh od pšenice", 
    Cijena = 5.50m,
    TrgovinaId = 1,
    KategorijId = 1,
    Dostupan = true 
};

var proizvod2 = new Proizvod 
{ 
    Id = 2, 
    Naziv = "Mlijeko", 
    Opis = "Pasterizovano mlijeko", 
    Cijena = 8.99m,
    TrgovinaId = 1,
    KategorijId = 1,
    Dostupan = true 
};

var proizvod3 = new Proizvod 
{ 
    Id = 3, 
    Naziv = "Laptop", 
    Opis = "Gaming laptop", 
    Cijena = 5999.99m,
    TrgovinaId = 3,
    KategorijId = 2,
    Dostupan = true 
};

var proizvod4 = new Proizvod 
{ 
    Id = 4, 
    Naziv = "Traperice", 
    Opis = "Muške plave traperice", 
    Cijena = 199.99m,
    TrgovinaId = 2,
    KategorijId = 3,
    Dostupan = true 
};

var proizvod5 = new Proizvod 
{ 
    Id = 5, 
    Naziv = "Jabuke", 
    Opis = "Svježe jabuke", 
    Cijena = 12.50m,
    TrgovinaId = 2,
    KategorijId = 1,
    Dostupan = false 
};

// Dodaj proizvode u trgovine
trgovina1.Proizvodi.AddRange(new[] { proizvod1, proizvod2 });
trgovina2.Proizvodi.AddRange(new[] { proizvod4, proizvod5 });
trgovina3.Proizvodi.Add(proizvod3);

// Kreiraj ocjene
var ocjena1 = new Ocjena 
{ 
    Id = 1, 
    TrgovinaId = 1, 
    KorisnikId = 1, 
    Vrijednost = 5,
    Komentar = "Odličan izbor proizvoda!",
    DatumOcjene = new DateTime(2024, 1, 10),
    VrstaOcjene = OcjeneEnum.KvalitetaProizvoda
};

var ocjena2 = new Ocjena 
{ 
    Id = 2, 
    TrgovinaId = 1, 
    KorisnikId = 2, 
    Vrijednost = 4,
    Komentar = "Dobra usluga, mogućo bolje cijene",
    DatumOcjene = new DateTime(2024, 1, 12),
    VrstaOcjene = OcjeneEnum.CjenovnikKompetitivnost
};

var ocjena3 = new Ocjena 
{ 
    Id = 3, 
    TrgovinaId = 2, 
    KorisnikId = 1, 
    Vrijednost = 3,
    Komentar = "Osrednja usluga",
    DatumOcjene = new DateTime(2024, 1, 15),
    VrstaOcjene = OcjeneEnum.UslugaKorisnika
};

var ocjena4 = new Ocjena 
{ 
    Id = 4, 
    TrgovinaId = 3, 
    KorisnikId = 3, 
    Vrijednost = 5,
    Komentar = "Najbolja cijena za laptope!",
    DatumOcjene = new DateTime(2024, 1, 20),
    VrstaOcjene = OcjeneEnum.CjenovnikKompetitivnost
};

// Dodaj ocjene u trgovine i korisnike
trgovina1.Ocjene.AddRange(new[] { ocjena1, ocjena2 });
trgovina2.Ocjene.Add(ocjena3);
trgovina3.Ocjene.Add(ocjena4);

korisnik1.Ocjene.AddRange(new[] { ocjena1, ocjena3 });
korisnik2.Ocjene.Add(ocjena2);
korisnik3.Ocjene.Add(ocjena4);

// Kreiraj kupnje
var kupnja1 = new Kupnja 
{ 
    Id = 1, 
    KorisnikId = 1, 
    TrgovinaId = 1,
    DatumKupnje = new DateTime(2024, 1, 8),
    UkupanIznos = 14.49m,
    Napomena = "Nije dostavljeno"
};

var kupnja2 = new Kupnja 
{ 
    Id = 2, 
    KorisnikId = 2, 
    TrgovinaId = 2,
    DatumKupnje = new DateTime(2024, 1, 14),
    UkupanIznos = 199.99m,
    Napomena = ""
};

var kupnja3 = new Kupnja 
{ 
    Id = 3, 
    KorisnikId = 3, 
    TrgovinaId = 3,
    DatumKupnje = new DateTime(2024, 1, 18),
    UkupanIznos = 5999.99m,
    Napomena = "Prijavljen garantni slučaj"
};

// Kreiraj stavke kupnje
var stavka1 = new KupnjaProizvod 
{ 
    KupnjaId = 1, 
    ProizvodId = 1, 
    Količina = 2,
    Cijena = 5.50m
};

var stavka2 = new KupnjaProizvod 
{ 
    KupnjaId = 1, 
    ProizvodId = 2, 
    Količina = 1,
    Cijena = 8.99m
};

var stavka3 = new KupnjaProizvod 
{ 
    KupnjaId = 2, 
    ProizvodId = 4, 
    Količina = 1,
    Cijena = 199.99m
};

var stavka4 = new KupnjaProizvod 
{ 
    KupnjaId = 3, 
    ProizvodId = 3, 
    Količina = 1,
    Cijena = 5999.99m
};

// Dodaj stavke u kupnje
kupnja1.StavkeKupnje.AddRange(new[] { stavka1, stavka2 });
kupnja2.StavkeKupnje.Add(stavka3);
kupnja3.StavkeKupnje.Add(stavka4);

// Dodaj kupnje u korisnike i trgovine
korisnik1.Kupnje.Add(kupnja1);
korisnik2.Kupnje.Add(kupnja2);
korisnik3.Kupnje.Add(kupnja3);

trgovina1.Kupnje.Add(kupnja1);
trgovina2.Kupnje.Add(kupnja2);
trgovina3.Kupnje.Add(kupnja3);

// Dodaj stavke u proizvode
proizvod1.KupnjeProizvoda.Add(stavka1);
proizvod2.KupnjeProizvoda.Add(stavka2);
proizvod4.KupnjeProizvoda.Add(stavka3);
proizvod3.KupnjeProizvoda.Add(stavka4);

// ===== LINQ UPITI =====

Console.WriteLine("========== LINQ UPITI ==========\n");

// Upit 1: Pronađi sve ocjene za Trgovinu Prima sortirane po vrijednosti (silazno)
var ocjeneZaTrgovina1 = trgovina1.Ocjene
    .OrderByDescending(o => o.Vrijednost)
    .ToList();

Console.WriteLine("=== LINQ Upit 1: Ocjene za Trgovinu Prima (sortirane po vrijednosti - silazno) ===");
foreach (var o in ocjeneZaTrgovina1)
{
    Console.WriteLine($"Vrijednost: {o.Vrijednost}, Komentar: {o.Komentar}");
}

// Upit 2: Pronađi sve proizvode dostupne u Trgovini Prima
var dostupniProizvodi = trgovina1.Proizvodi
    .Where(p => p.Dostupan)
    .ToList();

Console.WriteLine("\n=== LINQ Upit 2: Dostupni proizvodi u Trgovini Prima ===");
foreach (var p in dostupniProizvodi)
{
    Console.WriteLine($"Naziv: {p.Naziv}, Cijena: {p.Cijena}€");
}

// Upit 3: Pronađi sve kupnje korisnika Marko Horvat (korisnik1)
var kupnjeMarkoa = korisnik1.Kupnje
    .Where(k => k.KorisnikId == korisnik1.Id)
    .OrderByDescending(k => k.DatumKupnje)
    .ToList();

Console.WriteLine("\n=== LINQ Upit 3: Kupnje korisnika Marko Horvat (sortirane po datumu - od novije) ===");
foreach (var k in kupnjeMarkoa)
{
    Console.WriteLine($"Datum: {k.DatumKupnje:yyyy-MM-dd}, Iznos: {k.UkupanIznos}€");
}

// Upit 4: Pronađi sve ocjene sa vrijednosti >= 4 nad svim trgovinama
var visokihOcjena = new List<Ocjena>();
visokihOcjena.AddRange(trgovina1.Ocjene.Where(o => o.Vrijednost >= 4));
visokihOcjena.AddRange(trgovina2.Ocjene.Where(o => o.Vrijednost >= 4));
visokihOcjena.AddRange(trgovina3.Ocjene.Where(o => o.Vrijednost >= 4));

Console.WriteLine("\n=== LINQ Upit 4: Ocjene sa vrijednosti >= 4 ===");
foreach (var o in visokihOcjena)
{
    Console.WriteLine($"Trgovina ID: {o.TrgovinaId}, Vrijednost: {o.Vrijednost}, Vrsta: {o.VrstaOcjene}");
}

// Upit 5: Pronađi sve proizvode iz Kategorije "Prehrambeni proizvodi"
var prehrambenici = new List<Proizvod>();
prehrambenici.AddRange(trgovina1.Proizvodi.Where(p => p.KategorijId == kategorija1.Id));
prehrambenici.AddRange(trgovina2.Proizvodi.Where(p => p.KategorijId == kategorija1.Id));
prehrambenici.AddRange(trgovina3.Proizvodi.Where(p => p.KategorijId == kategorija1.Id));

Console.WriteLine("\n=== LINQ Upit 5: Proizvodi iz kategorije 'Prehrambeni proizvodi' ===");
foreach (var p in prehrambenici)
{
    Console.WriteLine($"Naziv: {p.Naziv}, Cijena: {p.Cijena}€, Dostupan: {(p.Dostupan ? "DA" : "NE")}");
}

// Upit 6: Pronađi prosječnu vrijednost ocjena po trgovini
var prosjecneOcjene = new List<(string Naziv, double Prosijek)>();
prosjecneOcjene.Add((
    trgovina1.Naziv, 
    trgovina1.Ocjene.Count > 0 ? trgovina1.Ocjene.Average(o => o.Vrijednost) : 0
));
prosjecneOcjene.Add((
    trgovina2.Naziv, 
    trgovina2.Ocjene.Count > 0 ? trgovina2.Ocjene.Average(o => o.Vrijednost) : 0
));
prosjecneOcjene.Add((
    trgovina3.Naziv, 
    trgovina3.Ocjene.Count > 0 ? trgovina3.Ocjene.Average(o => o.Vrijednost) : 0
));

Console.WriteLine("\n=== LINQ Upit 6: Prosječne ocjene po trgovini ===");
foreach (var (naziv, prosijek) in prosjecneOcjene)
{
    Console.WriteLine($"Trgovina: {naziv}, Prosječna ocjena: {prosijek:F2}");
}

// Upit 7: Pronađi sve stavke kupnje za kupnju1 gdje je količina > 1
var stavkeSVecihKolicina = kupnja1.StavkeKupnje
    .Where(s => s.Količina > 1)
    .FirstOrDefault();

Console.WriteLine("\n=== LINQ Upit 7: Prve stavke kupnje sa količinom > 1 ===");
if (stavkeSVecihKolicina != null)
{
    Console.WriteLine($"Proizvod ID: {stavkeSVecihKolicina.ProizvodId}, Količina: {stavkeSVecihKolicina.Količina}");
}
else
{
    Console.WriteLine("Nema stavki sa količinom > 1");
}

// Upit 8: Pronađi korisnike koji su kupili u više od jedne trgovine
var korisnikeSViseKupnji = new List<Korisnik>();
if (korisnik1.Kupnje.Count > 1) korisnikeSViseKupnji.Add(korisnik1);
if (korisnik2.Kupnje.Count > 1) korisnikeSViseKupnji.Add(korisnik2);
if (korisnik3.Kupnje.Count > 1) korisnikeSViseKupnji.Add(korisnik3);

Console.WriteLine("\n=== LINQ Upit 8: Korisnici s više od jedne kupnje ===");
if (korisnikeSViseKupnji.Count > 0)
{
    foreach (var k in korisnikeSViseKupnji)
    {
        Console.WriteLine($"Korisnik: {k.Ime} {k.Prezime}, Broj kupnji: {k.Kupnje.Count}");
    }
}
else
{
    Console.WriteLine("Nema korisnika s više od jedne kupnje.");
}

// ===== ASYNC/AWAIT UPITI =====
Console.WriteLine("\n\n========== ASYNC/AWAIT UPITI - Simulacija učitavanja iz baze ==========\n");

var service = new TrgovanjeService();

// Async Upit 1: Dohvati sve trgovine
var sve_trgovine = await service.DohvatiTrgoveAsync(new List<Trgovina> { trgovina1, trgovina2, trgovina3 });
Console.WriteLine($"\nUkupno učitanih trgovina: {sve_trgovine.Count}\n");

// Async Upit 2: Dohvati proizvode za prvu trgovinu
var proizvodi_trgovina1 = await service.DohvatiProizvodeTrgoveAsync(trgovina1);
Console.WriteLine($"Broj proizvoda za {trgovina1.Naziv}: {proizvodi_trgovina1.Count}\n");

// Async Upit 3: Dohvati sve ocjene
var sve_ocjene = await service.DohvatiSveOcjeneAsync(sve_trgovine);
Console.WriteLine($"Ukupno učitanih ocjena: {sve_ocjene.Count}\n");

// Async Upit 4: Dohvati kupnje specifičnog korisnika
var sve_kupnje = new List<Kupnja> { kupnja1, kupnja2, kupnja3 };
var kupnje_marko = await service.DohvatiKupnjeKorisnikaAsync(korisnik1, sve_kupnje);
Console.WriteLine($"Broj kupnji za {korisnik1.Ime}: {kupnje_marko.Count}\n");

// Async Upit 5: Izračun prosječne ocjene za svaku trgovinu
Console.WriteLine("=== ASYNC Upit 5: Prosječne ocjene po trgovini ===");
var prosj_ocjena_t1 = await service.IzracunajProsjecnuOcjenuAsync(trgovina1);
var prosj_ocjena_t2 = await service.IzracunajProsjecnuOcjenuAsync(trgovina2);
var prosj_ocjena_t3 = await service.IzracunajProsjecnuOcjenuAsync(trgovina3);
Console.WriteLine();

// Async Upit 6: Paralelno učitavanje proizvoda za sve trgovine
Console.WriteLine("=== ASYNC Upit 6: Paralelno učitavanje proizvoda svih trgovina ===");
var proizvodi_sve_trgovine = await service.DohvatiProizvodeSvihTrgoveAsync(sve_trgovine);
foreach (var (naziv, proizvodi) in proizvodi_sve_trgovine)
{
    Console.WriteLine($"{naziv}: {proizvodi.Count} proizvoda");
}
Console.WriteLine();

// Async Upit 7: Izračun ukupnog iznosa kupnje
Console.WriteLine("=== ASYNC Upit 7: Izračun ukupnog iznosa kupnji ===");
var iznos_kupnja1 = await service.IzracunajUkupanIznosKupnjeAsync(kupnja1);
var iznos_kupnja2 = await service.IzracunajUkupanIznosKupnjeAsync(kupnja2);
var iznos_kupnja3 = await service.IzracunajUkupanIznosKupnjeAsync(kupnja3);
Console.WriteLine();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

await app.RunAsync();
