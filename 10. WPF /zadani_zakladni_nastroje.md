# Úlohy – C#: Windows Presentation Foundation (IT3)

---

## Úlohy – První UI a události

### 1. Moje první aplikace
Vytvoř jednoduchý formulář ve WPF.

- aplikace bude mít název **„Moje první appka“**
- formulář bude po uživateli požadovat jeho jméno
- použij `TextBlock`, `TextBox` a tlačítko `Button` s textem **„Odeslat“**
- po stisknutí tlačítka vypiš pozdrav **„Ahoj [JMÉNO]!“**

**Bonus:** Nastav aplikaci vlastní ikonu.

---

### 2. Dvojnásobič
Vytvoř aplikaci, která zdvojnásobí uživatelem zadané číslo.

- uživatel zadá číslo do `TextBox`
- aplikace vypočítá jeho dvojnásobek a zobrazí výsledek
- při zpracování vstupu využij `int.TryParse()`
- upozorni uživatele na neplatný vstup

---

### 3. Kopírování textu
Vytvoř aplikaci, která průběžně zobrazuje text zadávaný uživatelem.

- uživatel zadává text do `TextBox`
- stejný text se **v reálném čase** zobrazuje v dolní části okna
- zobrazený text bude mít jiný font než text ve vstupním poli

---

### 4. Kalkulačka
Vytvoř jednoduchou kalkulačku s grafickým uživatelským rozhraním.

- uživatel zadá čísla a vybere požadovanou početní operaci
- aplikace vypočítá a zobrazí výsledek
- u číselných vstupů využij `int.TryParse()` a upozorni na neplatné hodnoty

---

## Úlohy – `CheckBox` a `IsEnabled`

### 5. Souhlas s licenčními podmínkami
Vytvoř formulář, ve kterém uživatel odsouhlasí licenční podmínky.

- přidej `CheckBox` pro souhlas s podmínkami
- přidej tlačítko **„Pokračovat“**
- dokud uživatel podmínky neodsouhlasí, tlačítko bude zakázané (`IsEnabled = false`)
- po zaškrtnutí souhlasu se tlačítko zpřístupní

---

### 6. Objednávka pizzy
Vytvoř aplikaci pro sestavení pizzy pomocí `CheckBox` prvků.

- základní pizza stojí **150 Kč**
- uživatel může přidat libovolnou kombinaci přísad:
  - sýr: **+20 Kč**
  - ananas: **+30 Kč**
  - olivy: **+25 Kč**
- **průběžně aktualizuj** výslednou cenu pizzy podle zaškrtnutých přísad

---

## Úlohy – `RadioButton` a `CheckBox`

### 7. Objednávka vstupenek
Vytvoř aplikaci pro objednávání vstupenek na koncert.

- uživatel si vybere **jednu kategorii vstupenek**:
  - dospělý: **200 Kč**
  - student: **150 Kč**
  - dítě: **100 Kč**
- uživatel může objednat libovolný počet vstupenek z vybrané kategorie
- k objednávce může přidat:
  - popcorn: **+60 Kč**
  - rychlý nákup: **+30 Kč**
- po kliknutí na tlačítko **„Objednat“** se zobrazí výsledná cena

---

### 8. Úprava písma
Vytvoř aplikaci, ve které může uživatel upravovat vzhled textu.

- pomocí `RadioButton` umožni výběr velikosti písma
- pomocí `RadioButton` umožni výběr barvy písma
- pomocí `CheckBox` umožni zapnout nebo vypnout:
  - tučné písmo
  - kurzívu
- vybrané nastavení aplikuj na zobrazený text

---

## Úlohy – `Image`, `RadioButton` a `CheckBox`

### 9. Výběr avatara
Vytvoř formulář, ve kterém si uživatel nastaví profil.

- uživatel zadá své jméno
- pomocí `RadioButton` si vybere **jednoho ze tří avatarů**
- přidej `CheckBox` **„Zobrazit náhled“**
  - pokud je zaškrtnutý, zobrazí se při výběru avatara jeho obrázek a jméno uživatele
- po kliknutí na tlačítko **„Pokračovat“** zobraz `MessageBox`

**Bonus:**

- nech uživatele vybrat font jeho jména
- umožni výběr barvy písma jména z předem daných možností

---

## Úlohy – `ComboBox`

### 10. Převodník měn
Vytvoř aplikaci pro převod českých korun do jiné měny.

- uživatel zadá částku v **Kč**
- v `ComboBox` si vybere cílovou měnu: **EUR, USD nebo GBP**
- po kliknutí na tlačítko **„Převést“** se zobrazí přepočítaná částka
- ověř, že uživatel vybral měnu a zadal platnou číselnou hodnotu

---

### 11. Objednávka občerstvení
Vytvoř aplikaci, ve které si uživatel sestaví objednávku jídla.

- pomocí `ComboBox` vybere **polévku** a **hlavní chod**
- různé možnosti budou mít různé ceny
- přidej `CheckBox` **„Dezert“**
  - po jeho zaškrtnutí se zpřístupní výběr dezertu
- jednotlivé dezerty budou mít různé ceny
- zobraz uživateli **celkovou cenu objednávky**

---

## Závěrečná úloha – Kombinace prvků WPF

### 12. Konfigurátor PC
Vytvoř aplikaci, která uživateli umožní sestavit vlastní počítač.

**Výběr komponent:**

- uživatel vybere procesor a operační paměť (RAM)
- pokud chce, může vybrat také samostatnou grafickou kartu
- za příplatek si může přikoupit:
  - RGB osvětlení
  - instalaci operačního systému

**Náhled počítače:**

- přidej `Image` s náhledem počítače
- pokud uživatel zaškrtne RGB osvětlení, náhled se změní

**Výpočet ceny:**

- základní cena počítače je **13 000 Kč**
- grafická karta, RGB osvětlení a instalace OS cenu zvyšují
- uživatel může zanechat **libovolné dýško**
- aplikace vypočítá výslednou cenu

**Dokončení objednávky:**

- uživatel musí souhlasit s obchodními podmínkami
- teprve až bude vše vyplněné a splněné, může kliknout na tlačítko **„Objednat“**

---

*K přepisu a sjednocení zadání z prezentace „Windows Presentation Foundation (IT3)“ do Markdownu byl využit ChatGPT.*
