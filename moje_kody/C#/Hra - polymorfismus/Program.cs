using System;
using System.Collections.Generic;

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

        Console.WriteLine("VÍTEJ V LABYRINTU!");
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
            Console.WriteLine("VYHRÁL JSI!");
            Console.WriteLine($"Dokončil jsi labyrint s {hrac.Penize} penězi!");
        }
        else
        {
            Console.WriteLine("PROHRÁL JSI!");
            Console.WriteLine("Došly ti životy.");
        }
    }
}