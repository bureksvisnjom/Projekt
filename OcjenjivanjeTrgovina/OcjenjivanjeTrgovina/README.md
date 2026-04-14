# Ocjenjivanja Trgovina - Lab 1

Aplikacija za ocjenjivanje online trgovina s demonstracijom C#, LINQ i async/await koncepata.

## Što je Uključeno

- ✅ **8 klasa** s objektnim modelom
- ✅ **4 kompleksne klase** s 5+ svojstava
- ✅ **Vlastiti enum** (OcjeneEnum)
- ✅ **DateTime svojstva** u svim relevantnim klasama
- ✅ **Relacije 1-N i N-N** između klasa
- ✅ **Inicijalizacija** s 3+ trgovine, 3 korisnika, 5 proizvoda
- ✅ **8 LINQ upita** s različitim operacijama
- ✅ **7 Async/Await upita** s simulacijom učitavanja
- ✅ **Lab-1 dokumentacija** s detaljnim objašnjenjima

## Brz Start

```bash
cd OcjenjivanjeTrgovina
dotnet run
```

## Struktura Projekta

```
OcjenjivanjeTrgovina/
├── Models/              # Objektni model (8 klasa)
│   ├── OcjeneEnum.cs
│   ├── Korisnik.cs
│   ├── Kategorija.cs
│   ├── Trgovina.cs
│   ├── Proizvod.cs
│   ├── Ocjena.cs
│   ├── Kupnja.cs
│   └── KupnjaProizvod.cs
├── Services/            # Servisne klase
│   └── TrgovanjeService.cs
├── Controllers/         # API kontroleri
├── Program.cs           # Glavna aplikacija s LINQ i Async upitima
├── lab-1/               # Lab dokumentacija
│   └── README.md
└── .gitignore
```

## Objektni Model

### Glavne Klase:
1. **Korisnik** - Korisnici sustava
2. **Trgovina** - Online trgovine
3. **Proizvod** - Dostupni proizvodi
4. **Ocjena** - Korisničke ocjene
5. **Kupnja** - Kupnje korisnika
6. **Kategorija** - Kategorije proizvoda
7. **KupnjaProizvod** - Veza N-N između kupnji i proizvoda
8. **OcjeneEnum** - Tipovi ocjena

## LINQ Upiti

Projekt demonstrira 8 LINQ upita:
- Filtriranje s `Where()`
- Sortiranje s `OrderBy()` i `OrderByDescending()`
- Agregaciju s `Average()`, `Count()`
- Selekciju s `First()`, `FirstOrDefault()`
- Transformaciju s `ToList()`

## Async/Await

Projekt demonstrira asinkroni rad:
- Async metode s povratnom vrijednosti `Task<T>`
- Korištenje `await` za čekanje na taskove
- `Task.Delay()` za simulaciju sporih operacija
- `Task.WhenAll()` za paralelno čekanje više taskova

## Tehnologije

- **C# 14.0**
- **.NET 10**
- **LINQ (Language Integrated Query)**
- **Async/Await pattern**
- **ASP.NET Core**

## Pokretanje Testova i Validacije

```bash
# Kompajliranje
dotnet build

# Pokretanje s outputom
dotnet run

# Publikacija
dotnet publish -c Release
```

## Datoteke

- `Program.cs` - Glavna aplikacija (435+ linija koda)
- `TrgovanjeService.cs` - Servis s async metodama
- `Models/*.cs` - Sve klase objektnog modela
- `lab-1/README.md` - Detaljnu dokumentaciju

## Lab Zahtjevi

✅ Granularno izvođenje agenta po taskovima  
✅ Ispitivanje agenta za pojašnjenja  
✅ Usmeno ispitivanje LINQ/async ili C# koncepata  
✅ Objektni model s 7+ klasa  
✅ 4 kompleksne klase s 5+ svojstava  
✅ Vlastiti enum  
✅ DateTime svojstva  
✅ Ispravne 1-N i N-N veze  
✅ Inicijalizacija barem 3 glavna objekta  
✅ LINQ upiti za kasnije korištenje  
✅ Razumijevanje async-await koncepata  
✅ GitHub repozitorij  
✅ Lab-1 folder s dokumentacijom  

## Priprema za GitHub

1. Kreiraj javni GitHub repozitorij
2. Kloniraj ga lokalno ili puši kod
3. Sve kod koji se ocjenjuje trebao bi biti na GH repozitoriju
4. Pošalji link do repozitorija na mail

## Autor

Razvijeno kao Lab 1 za C# i LINQ kolegiij.

---

Za više detalja pogledaj [lab-1/README.md](lab-1/README.md).
