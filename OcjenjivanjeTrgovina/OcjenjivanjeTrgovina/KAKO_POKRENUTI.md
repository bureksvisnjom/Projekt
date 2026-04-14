# 🚀 KAKO ZAVRŠITI PROJEKT

## KORAK 1: Zatvori Visual Studio

1. Otvori Visual Studio
2. Spremi sve datoteke (**Ctrl+Shift+S**)
3. Zatvori Visual Studio

---

## KORAK 2: Očisti Build Datoteke

Otvori PowerShell i pokreni:

```powershell
cd "C:\Users\Brani\OneDrive\Radna površina\OcjenjivanjeTrgovanja\OcjenjivanjeTrgovanja"
```

Zatim:

```powershell
# Briši bin i obj folderе
Remove-Item -Path "bin", "obj" -Recurse -Force -ErrorAction SilentlyContinue
Write-Host "Očišćeno!"
```

---

## KORAK 3: Kompaјliraj Projekt

```powershell
dotnet clean
dotnet build
```

Trebao bi izbaciti: `Build successful`

---

## KORAK 4: Pokreni Projekt

```powershell
dotnet run
```

### Očekivani Output:

```
========== LINQ UPITI ==========

=== LINQ Upit 1: Ocjene za Trgovinu Prima (sortirane po vrijednosti - silazno) ===
Vrijednost: 5, Komentar: Odličan izbor proizvoda!
Vrijednost: 4, Komentar: Dobra usluga, mogućo bolje cijene

=== LINQ Upit 2: Dostupni proizvodi u Trgovini Prima ===
Naziv: Hleb, Cijena: 5.5€
Naziv: Mlijeko, Cijena: 8.99€

... (više LINQ upita)

========== ASYNC/AWAIT UPITI - Simulacija učitavanja iz baze ==========

[ASYNC] Započeto učitavanje trgovina iz baze...
[ASYNC] Učitavanje trgovina završeno!

Ukupno učitanih trgovina: 3

[ASYNC] Učitavanje proizvoda za Trgovina Prima...
[ASYNC] Učitani proizvodi za Trgovina Prima!

Broj proizvoda za Trgovina Prima: 2

... (više ASYNC upita sa [ASYNC] porukama)
```

Trebali bi vidjeti:
- ✅ Svi LINQ upiti s rezultatima
- ✅ [ASYNC] poruke
- ✅ Svi async upiti s rezultatima

---

## KORAK 5: GitHub Setup (Opciono - za početak)

Ako trebate lokalno giti:

```powershell
# Pozicioniraj se u folder projekta
cd "C:\Users\Brani\OneDrive\Radna površina\OcjenjivanjeTrgovanja"

# Inicijalizuj git
git init

# Dodaj sve datoteke
git add .

# Commit
git commit -m "Lab 1: Ocjenjivanja Trgovina - Objektni Model + LINQ + Async/Await"

# (Nakon što kreirate GitHub repozitorij)
git remote add origin https://github.com/YOUR_USERNAME/OcjenjivanjeTrgovanja.git
git branch -M main
git push -u origin main
```

---

## STRUKTURA PROJEKTA

Sve datoteke su već na mjestu:

```
OcjenjivanjeTrgovanja\
├── OcjenjivanjeTrgovanja\
│   ├── Models\                    ✅ (8 klasa)
│   │   ├── OcjeneEnum.cs
│   │   ├── Korisnik.cs
│   │   ├── Kategorija.cs
│   │   ├── Trgovina.cs
│   │   ├── Proizvod.cs
│   │   ├── Ocjena.cs
│   │   ├── Kupnja.cs
│   │   └── KupnjaProizvod.cs
│   ├── Services\
│   │   └── TrgovanjeService.cs    ✅ (7 async metoda)
│   ├── Controllers\
│   ├── Program.cs                 ✅ (450+ linija, LINQ + Async)
│   ├── README.md                  ✅
│   └── .gitignore                 ✅
├── lab-1\                         ✅ (Dokumentacija)
│   ├── README.md
│   └── AI_AGENT_LOG.md
├── SUMMARY.md                     ✅
└── OcjenjivanjeTrgovanja.slnx
```

---

## PROBLEMI I RJEŠENJA

### Problem: "Couldn't find a project to run"
**Rješenja**:
1. Provjeri da si u ispravnom direktoriju (`OcjenjivanjeTrgovanja\OcjenjivanjeTrgovanja`)
2. Provjeri da postoji `Program.cs`

### Problem: "The process cannot access the file"
**Rješenja**:
1. Zatvori Visual Studio
2. Zatvori sve Terminal prozore s dotnetom
3. Provjeri Task Manager za `dotnet.exe` i zaustavi ga

### Problem: Build greške
**Rješenja**:
1. `dotnet clean` - očisti stare datoteke
2. `dotnet build` - novi build
3. Ako ne radi, provjeri da su sve klase u `/Models` folderu

---

## PROVJERA PRIJE PREDAJE

Prije nego što preداš projekat, provjeri:

- ✅ Project se kompajlira bez greške
- ✅ `dotnet run` ispisuje sve LINQ upite
- ✅ `dotnet run` ispisuje sve ASYNC upite s [ASYNC] porukama
- ✅ GitHub repozitorij je kreiран
- ✅ Sav kod je na GitHub-u
- ✅ lab-1/ folder je na GitHub-u
- ✅ README.md datoteke postoje

---

## KONTAKT NAKON ZAVRŠETKA

Kada je sve gotovo:

1. **Pošalji GitHub link** na mail **do 20.3.2026.**
2. Biti spreman za **usmeno objašnjenje**:
   - Što je LINQ?
   - Što je async/await?
   - Objasniti jedan od upita
   - Objasniti relacije u objektnom modelu

---

## GOTOVO! 🎉

Projekt je **100% završen** za predaju!

Svi zahtjevi su ispunjeni:
- ✅ Objektni model (8 klasa)
- ✅ LINQ upiti (8 upita)
- ✅ Async/Await (7 upita)
- ✅ Dokumentacija
- ✅ GitHub struktura

**Sretno s predajom! 👍**
