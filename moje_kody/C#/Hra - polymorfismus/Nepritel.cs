class Nepritel : Mistnost
{
    public override void Aktivuj(Hrac hrac)
    {
        Console.WriteLine("Narazil jsi na nepritele!");

        Random random = new Random();
        int sance = random.Next(0, 2);

        if (sance == 0)
        {
            Console.WriteLine("Vyhral jsi souboj!");
        }
        else
        {
            hrac.HP -= 15;
            Console.WriteLine("Prohral jsi souboj a ztratil 15 HP!");
        }
    }
}