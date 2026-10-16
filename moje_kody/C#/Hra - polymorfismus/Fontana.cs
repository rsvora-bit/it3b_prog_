using System;

class Fontana : Mistnost
{
    public override void Aktivuj(Hrac hrac)
    {
        Console.WriteLine("Našel jsi léčivou fontánu.");

        if (hrac.HP >= Hrac.MaxHP)
        {
            Console.WriteLine("Máš plné zdraví, léčení nepotřebuješ.");
        }
        else if (hrac.Penize >= 20)
        {
            hrac.Penize -= 20;
            hrac.HP = Math.Min(Hrac.MaxHP, hrac.HP + 20);
            Console.WriteLine("Vyléčil ses za 20 peněz.");
        }
        else
        {
            Console.WriteLine("Na léčení potřebuješ 20 peněz.");
        }
    }
}
