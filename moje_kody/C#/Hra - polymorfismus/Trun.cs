using System;

class Trun : Mistnost
{
    public override void Aktivuj(Hrac hrac)
    {
        hrac.Vyhral = true;
        Console.WriteLine("Dorazil jsi k vítěznému trůnu!");
    }
}
