# Lab 1 - Ocjenjivanja Trgovina

## Opis Projekta

Projekt "Ocjenjivanja Trgovina" je C# aplikacija koja demonstrira osnove jezika C#, LINQ upite i asinkroni rad (async/await).

Aplikacija simulira sustav za ocjenjivanje online trgovina gdje korisnici mogu ostavljati ocjene i kupovati proizvode.

## Objektni Model

### Klase (8 Klasa):

1. **OcjeneEnum** - Enum s vrstama ocjena
   - KvalitetaProizvoda
   - UslugaKorisnika
   - CjenovnikKompetitivnost
   - Čistoća
   - Dostupnost

2. **Korisnik** (Kompleksna - 6 svojstava)
   - Id (int)
   - Ime (string)
   - Prezime (string)
   - Email (string)
   - Telefon (string)
   - DatumRegistracije (DateTime)
   - Veze: List<Ocjena>, List<Kupnja>

3. **Kategorija** (3 svojstva)
   - Id (int)
   - Naziv (string)
   - Opis (string)
   - Veza: List<Proizvod>

4. **Trgovina** (Kompleksna - 7 svojstava)
   - Id (int)
   - Naziv (string)
   - Adresa (string)
   - Grad (string)
   - DatumOtvaranja (DateTime)
   - Telefon (string)
   - Email (string)
   - Veze: List<Ocjena>, List<Proizvod>, List<Kupnja>

5. **Proizvod** (Kompleksna - 7 svojstava)
   - Id (int)
   - Naziv (string)
   - Opis (string)
   - Cijena (decimal)
   - TrgovinaId (int)
   - KategorijId (int)
   - Dostupan (bool)
   - Veze: Trgovina, Kategorija, List<KupnjaProizvod>

6. **Ocjena** (Kompleksna - 7 svojstava)
   - Id (int)
   - TrgovinaId (int)
   - KorisnikId (int)
   - Vrijednost (int)
   - Komentar (string)
   - DatumOcjene (DateTime)
   - VrstaOcjene (OcjeneEnum)
   - Veze: Korisnik, Trgovina

7. **Kupnja** (Kompleksna - 6 svojstava)
   - Id (int)
   - KorisnikId (int)
   - TrgovinaId (int)
   - DatumKupnje (DateTime)
   - UkupanIznos (decimal)
   - Napomena (string)
   - Veze: Korisnik, Trgovina, List<KupnjaProizvod>

8. **KupnjaProizvod** - Veza N-N (4 svojstva)
   - KupnjaId (int)
   - ProizvodId (int)
   - Količina (int)
   - Cijena (decimal)
   - Veze: Kupnja, Proizvod

## Inicijalizovani Podaci

### Kategorije:
- Prehrambeni proizvodi
- Elektronika
- Odjeća

### Korisnici:
- Marko Horvat (Email: marko@example.com)
- Ana Horvat (Email: ana@example.com)
- Petar Petrović (Email: petar@example.com)

### Trgovine:
1. **Trgovina Prima** - Zagreb, Trg bana Jelačića 10
   - Proizvodi: Hleb, Mlijeko
   - Ocjene: 2

2. **Supermarket Zlata** - Zagreb, Radnička cesta 50
   - Proizvodi: Traperice, Jabuke
   - Ocjene: 1

3. **ElektroShop** - Zagreb, Kneza Miloša 1
   - Proizvodi: Laptop
   - Ocjene: 1

### Kupnje:
- Kupnja 1: Marko - Trgovina Prima (2x Hleb, 1x Mlijeko) - 14.49€
- Kupnja 2: Ana - Supermarket Zlata (1x Traperice) - 199.99€
- Kupnja 3: Petar - ElektroShop (1x Laptop) - 5999.99€

## LINQ Upiti (8 Upita)

1. **Upiti 1**: Sve ocjene za Trgovinu Prima (sortirane po vrijednosti - silazno)
   - Koristi: `OrderByDescending()`, `ToList()`

2. **Upit 2**: Dostupni proizvodi u Trgovini Prima
   - Koristi: `Where()`, `ToList()`

3. **Upit 3**: Kupnje korisnika Marko Horvat (sortirane po datumu)
   - Koristi: `Where()`, `OrderByDescending()`, `ToList()`

4. **Upit 4**: Ocjene sa vrijednosti >= 4 (sve trgovine)
   - Koristi: `Where()`, `AddRange()`

5. **Upit 5**: Proizvodi iz kategorije "Prehrambeni proizvodi"
   - Koristi: `Where()` s filtriranjem po kategoriji

6. **Upit 6**: Prosječne ocjene po trgovini
   - Koristi: `Average()`, `Count`

7. **Upit 7**: Stavke kupnje sa količinom > 1
   - Koristi: `Where()`, `FirstOrDefault()`

8. **Upit 8**: Korisnici s više od jedne kupnje
   - Koristi: `Count` svojstva, logika filtriranja

## Async/Await Upiti (7 Async Upita)

Servis `TrgovanjeService` implementira async metode:

1. **DohvatiTrgoveAsync()** - Simulira učitavanje svih trgovina
2. **DohvatiProizvodeTrgoveAsync()** - Simulira učitavanje proizvoda
3. **DohvatiSveOcjeneAsync()** - Simulira učitavanje svih ocjena
4. **DohvatiKupnjeKorisnikaAsync()** - Simulira učitavanje kupnji korisnika
5. **IzracunajProsjecnuOcjenuAsync()** - Izračun prosječne ocjene
6. **DohvatiProizvodeSvihTrgoveAsync()** - Paralelno učitavanje sa `Task.WhenAll()`
7. **IzracunajUkupanIznosKupnjeAsync()** - Izračun ukupnog iznosa

### Async/Await Koncept:
- Korištenje `async` ključne riječi za deklarisanje asinkronih metoda
- Korištenje `await` za čekanje na asinkroni zadatak
- Korištenje `Task.Delay()` za simulaciju sporoga pristupa
- Korištenje `Task.WhenAll()` za paralelno čekanje više taskova
- Korištenje `await app.RunAsync()` za pokretanje web aplikacije asinkrino

## Struktura Projekta

```
OcjenjivanjeTrgovina/
├── Models/
│   ├── OcjeneEnum.cs
│   ├── Korisnik.cs
│   ├── Kategorija.cs
│   ├── Trgovina.cs
│   ├── Proizvod.cs
│   ├── Ocjena.cs
│   ├── Kupnja.cs
│   └── KupnjaProizvod.cs
├── Services/
│   └── TrgovanjeService.cs
├── Controllers/
│   └── WeatherForecastController.cs
└── Program.cs
```

## Pokretanje Projekta

```bash
cd OcjenjivanjeTrgovina
dotnet run
```

Aplikacija će ispisati sve LINQ upite, zatim sve async upite sa simulacijom učitavanja iz baze podataka.

## Ključne Koncepte Demonstrirani

### C# Osnove:
✅ Klase i objekti  
✅ Svojstva (properties) i polja  
✅ Konstruktori  
✅ Enumeracije (enum)  
✅ Nasljeđivanje i veze između klasa  
✅ Privatna i javna svojstva  

### LINQ:
✅ Lambda izrazi  
✅ Where() filtriranje  
✅ OrderBy() i OrderByDescending() sortiranje  
✅ First(), FirstOrDefault(), Single()  
✅ Average(), Count()  
✅ ToList()  
✅ Kombiniranje više LINQ operacija  

### Async/Await:
✅ Async metode sa `async` ključnom riječju  
✅ Await operatora za čekanje na taskove  
✅ Task<T> povratne vrijednosti  
✅ Task.Delay() za simulaciju  
✅ Task.WhenAll() za paralelno čekanje  
✅ Asinkriono pokretanje aplikacije  

## Korišteni AI Agent

Projekt je razvijen uz pomoć GitHub Copilota s sljedećim uputama:
1. Kreiraj objektni model s 7+ klasa
2. Inicijalizuj barem 3 glavna objekta
3. Napravi 8+ LINQ upita
4. Dodaj async/await primjere
5. Objediniti sve u jednoj aplikaciji

---

**Datum izrade**: ožujak 2026.  
**Jezik**: C# 14.0  
**.NET verzija**: .NET 10
