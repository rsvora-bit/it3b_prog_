class Truhla : Mistnost
{
    public override void Aktivuj(Hrac hrac)
    {
        Console.WriteLine("Nasel jsi truhlu!");
        hrac.Penize += 10;

        Console.WriteLine("Ziskal jsi 10 penez.");
    }
}