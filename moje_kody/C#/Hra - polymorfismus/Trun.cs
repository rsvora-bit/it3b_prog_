class Trun : Mistnost
{
    public override void Aktivuj(Hrac hrac)
    {
        Console.WriteLine("Dorazil jsi k viteznemu trunu!");
        hrac.Vyhral = true;
    }
}