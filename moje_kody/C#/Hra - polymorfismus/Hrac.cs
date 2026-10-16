class Hrac
{
    public int HP = 50;
    public int Penize = 0;
    public bool Vyhral = false;

    public void VypisStav()
    {
        Console.WriteLine($"HP: {HP}, Penize: {Penize}");
    }
}