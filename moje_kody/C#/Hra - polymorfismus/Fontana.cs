class Fontana : Mistnost
{
    public override void Aktivuj(Hrac hrac)
    {
        Console.WriteLine("Nasel jsi lecivou fontanu!");

        if (hrac.Penize >= 20 && hrac.HP < 50)
        {
            hrac.Penize -= 20;
            hrac.HP += 20;

            if (hrac.HP > 50)
            {
                hrac.HP = 50;
            }

            Console.WriteLine("Vylecil ses za 20 penez.");
        }
        else
        {
            Console.WriteLine("Nemuzes se vylecit.");
        }
    }
}