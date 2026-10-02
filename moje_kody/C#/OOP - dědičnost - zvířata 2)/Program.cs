class Program
{
    static void Main()
    {
        Pes pes = new Pes("Alik", 20, "Labrador");
        Kocka kocka = new Kocka("Micka", 5, "cerna");

        pes.VypisInformace();

        Console.WriteLine();

        pes.Hafni();
        pes.Snez("maso");
        pes.Odpocivej(2);

        Console.WriteLine();

        pes.VypisInformace();

        Console.WriteLine();

        kocka.VypisInformace();

        Console.WriteLine();

        kocka.Mnoukni();
        kocka.Snez("ryba");

        Console.WriteLine();

        kocka.VypisInformace();
    }
}