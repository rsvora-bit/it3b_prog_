/*
  Kvůli stručnosti jsou všechny třídy umístěny do jednoho souboru.
  V reálu by bylo vhodné je rozdělit do více souborů.
*/

class Vozidlo
{
    // Společné vlastnosti všech vozidel.
    public string Nazev { get; set; }
    public int Rychlost { get; set; }

    // Konstruktor nadtřídy.
    public Vozidlo(string nazev, int rychlost)
    {
        Nazev = nazev;
        Rychlost = rychlost;
    }

    // Tuto metodu zdědí všechny podtřídy.
    public void Jed()
    {
        Console.WriteLine($"{Nazev} jede rychlostí {Rychlost} km/h.");
    }
}

// Auto dědí ze třídy Vozidlo.
class Auto : Vozidlo
{
    public int PocetDveri { get; set; }

    // Pomocí base(...) zavoláme konstruktor nadtřídy Vozidlo.
    public Auto(string nazev, int rychlost, int pocetDveri)
        : base(nazev, rychlost)
    {
        PocetDveri = pocetDveri;
    }

    // Metoda, kterou má pouze Auto.
    public void Zatroubit()
    {
        Console.WriteLine($"{Nazev}: Tůt tůt!");
    }
}

// Motorka  dědí ze třídy Vozidlo.
class Motorka : Vozidlo
{
    public bool MaKufr { get; set; }

    public Motorka(string nazev, int rychlost, bool maKufr)
        : base(nazev, rychlost)
    {
        MaKufr = maKufr;
    }

    public void PostavNaStojan()
    {
        Console.WriteLine($"{Nazev} byla postavena na stojan.");
    }
}

class Program
{
    static void Main()
    {
        Auto auto = new Auto("Škoda Octavia", 130, 5);

        // Zděděná metoda z Vozidlo.
        auto.Jed();

        // Metoda podtřídy Auto.
        auto.Zatroubit();

        Console.WriteLine($"Počet dveří: {auto.PocetDveri}");

        Console.WriteLine();

        Motorka motorka = new Motorka("Honda CB500", 160, true);

        // I Motorka zdědila metodu Jed().
        motorka.Jed();

        // Metoda podtřídy Motorka.
        motorka.PostavNaStojan();

        Console.WriteLine($"Má kufr: {motorka.MaKufr}");
    }
}
