class Program
{
    static void Main()
    {

        try
        {
            Console.WriteLine("Zadej cenu skupinového lístku: ");
            int cena = int.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Mušíš zadat číslo! ");
            return;
        }

        try
        {
            Console.WriteLine("Zadej počet osob: ");
            int pocetosob = int.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Musíš zadat číslo! ");
            return;
        }



    }
}