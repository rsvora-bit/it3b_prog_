using System;

class Truhla : Mistnost
{
    public override void Aktivuj(Hrac hrac)
    {
        hrac.Penize += 10;
        Console.WriteLine("Našel jsi truhlu a získal 10 peněz.");
    }
}
