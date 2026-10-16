using System;

class Nepritel : Mistnost
{
    public override void Aktivuj(Hrac hrac)
    {
        Console.WriteLine("Narazil jsi na nepřítele.");

        if (Random.Shared.Next(2) == 0)
        {
            Console.WriteLine("Vyhrál jsi souboj!");
        }
        else
        {
            hrac.HP = Math.Max(0, hrac.HP - 10);
            Console.WriteLine("Prohrál jsi souboj a ztratil 10 HP.");
        }
    }
}
