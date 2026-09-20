# Úlohy – C#: 4 pilíře OOP (IT3)

---

## Úlohy – Dědičnost

### 1. Další třídy zvířat
Navazuj na třídu `Savec`.

- vytvoř další třídy zvířat
- jednotlivé třídy budou dědit ze společné nadtřídy
- každé zvíře bude mít alespoň jednu vlastní unikátní metodu

---

### 2. Energie a povolené jídlo
Rozšiř třídy zvířat o energii a jídlo.

- v konstruktoru vytvoř atribut `Energie`
- vytvoř atribut `PovoleneJidlo`
- `Energie` má na začátku hodnotu `100`
- pokud zvíře sní své `PovoleneJidlo`, zvýší se mu energie
- vytvoř metodu `Odpocivej(pocet_hodin)`
- za každou hodinu odpočinku se energie zvýší o `10`
- podle typu zvířete přidej metody, které energii ubírají
- pokud energie klesne pod `0`, zvíře umírá a atribut `Nazivu` se nastaví na `false`

---

### 3. Vícevrstvá dědičnost
Vytvoř dědičnost o dvou vrstvách:

```text
Zvire
  ↓
Selma
  ↓
Lev
```

- vytvoř třídu `Zvire`
- z ní odvoď třídu `Selma`
- z třídy `Selma` odvoď třídu `Lev`

---

### 4. Dědičnost ve škole
Aplikuj dědičnost na školní příklad.

- vytvoř nadtřídu `Osoba`
- přesuň do ní společné atributy a metody studenta a učitele
- vytvoř nadtřídu `Zamestnanec`
- z `Zamestnanec` budou dědit:
  - `Ucitel`
  - `Udrzbar`
  - `VedeniSkoly`
  - `Uklizec`
- zaměstnanec má:
  - odvedené hodiny práce
  - mzdu
  - metodu `Pracuj(pocet_hodin)`
- `Udrzbar` má atribut `PocetOprav` a metodu `Oprav()`
- `VedeniSkoly` má pole s odkazy na podřízené zaměstnance

---

## Úlohy – Polymorfismus: overloading

### 5. Výpočet obsahu
Vytvoř třídu `Geometrie`, která bude pomocí metod stejného názvu počítat podle vstupních parametrů obsahy:

- čtverce
- obdélníku
- kvádru

Použij **overloading** – metody budou mít stejný název, ale různé parametry.

---

### 6. Útok hráče
Vytvoř třídu `Hrac`, která bude pomocí přetížených metod vypisovat různé hlášky pro útok.

Hráč může mít zadanou zbraň a sílu, ale nemusí.

Možné výstupy:

```text
Bojovník útočí.
Bojovník útočí silou 20.
Bojovník útočí pomocí meče.
Bojovník útočí pomocí meče silou 20.
```

- vytvoř více metod stejného názvu
- jednotlivé varianty se budou lišit vstupními parametry

---

### 7. Hledání maxima
Vytvoř třídu `Matematika` s přetíženými metodami pro hledání maxima.

Metody budou hledat maximum pro:

- dvě čísla typu `int`
- tři čísla typu `int`
- pole čísel typu `int`

Všechny metody budou mít stejný název, ale různé parametry.

---

## Úlohy – Polymorfismus: overriding

### 8. Zvířecí zvuky
Navazuj na třídu `Savec` s metodou `Promluv()`.

- vytvoř několik dalších tříd zvířat
- každá třída bude dědit ze třídy `Savec`
- v každé podtřídě přepiš metodu `Promluv()`
- použij `override`
- každé zvíře bude vydávat jiný zvuk

---

### 9. Labyrint
Vytvoř jednoduchou hru, ve které hráč postupně prochází místnostmi labyrintu.

#### Hráč
Vytvoř třídu `Hrac`.

- hráč má na začátku `50 HP`
- hráč může získávat peníze
- konkrétní hodnoty můžeš podle potřeby změnit

#### Místnosti
Vytvoř třídu reprezentující místnost labyrintu a několik jejích podtříd.

Všechny místnosti mají metodu:

```csharp
Aktivuj(Hrac hrac)
```

Vytvoř alespoň tyto typy místností:

- **léčivá fontána**
  - vyléčí `20` životů
  - stojí `20` peněz
- **truhla**
  - přidá hráči `10` peněz
- **nepřítel**
  - hráč má `50 %` šanci na vítězství v boji
  - při prohře mu nepřítel odebere životy
- **vítězný trůn**
  - ukončí hru

Každá podtřída přepíše metodu `Aktivuj()` podle svého chování.

#### Průchod labyrintem
Vytvoř seznam místností za sebou a postupně je aktivuj:

```csharp
foreach (Mistnost m in mistnosti)
{
    m.Aktivuj(hrac);
}
```

Cíl hry:

> Dostaň se do cíle s co největším množstvím peněz.

---

## Opakování

### 10. Větší zvíře
Ke zvířatům přidej metodu:

```csharp
JeTezsi(zvire2)
```

- metoda dostává na vstupu jiné zvíře
- porovná hmotnost obou zvířat
- vrátí těžší z těchto zvířat
- pokud mají obě zvířata stejnou hmotnost, může vrátit kterékoliv z nich

---

*K přepisu úloh z prezentace do Markdownu byl využit ChatGPT.*
