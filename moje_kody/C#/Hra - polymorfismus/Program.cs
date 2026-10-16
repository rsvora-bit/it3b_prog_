class Program
{
    static void Main()
    {
        Hrac hrac = new Hrac();

        List<Mistnost> mistnosti = new List<Mistnost>()
        {
            new Truhla(),
            new Truhla(),
            new Nepritel(),
            new Fontana(),
            new Truhla(),
            new Nepritel(),
            new Truhla(),
            new Truhla(),
            new Fontana(),
            new Nepritel(),
            new Truhla(),
            new Trun()
        };

        Console.WriteLine("VITEJ V LABYRINTU!");
        Console.WriteLine("------------------");

        foreach (Mistnost m in mistnosti)
        {
            if (hrac.HP <= 0 || hrac.Vyhral)
            {
                break;
            }

            Console.WriteLine();
            m.Aktivuj(hrac);
            hrac.VypisStav();

            Console.WriteLine("------------------");
        }

        if (hrac.Vyhral)
        {
            Console.WriteLine("VYHRAL JSI!");
            Console.WriteLine($"Dokoncil jsi labyrint s {hrac.Penize} penezi!");
        }
        else
        {
            Console.WriteLine("PROHRAL JSI!");
            Console.WriteLine("Dosly ti zivoty.");
        }
    }
}