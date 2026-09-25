class Program
{

    static void Main()
    {
        Console.WriteLine("Volná lůžka: ");
        try
        {
            int volneluzka = int.Parse(Console.ReadLine());
            Oddeleni oddeleni = new Oddeleni("Chirurgie", "101", "Jana Nováková");
            oddeleni.VolneLuzka(volneluzka);
        }
        catch (FormatException)
        {
            Console.WriteLine("Musíš zadat číslo! ");
            return;
        }

        
    }
}