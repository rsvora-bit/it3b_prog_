using System;

class Hrac
{
    public const int MaxHP = 50;

    public int HP = MaxHP;
    public int Penize = 0;
    public bool Vyhral = false;

    public void VypisStav()
    {
        Console.WriteLine($"HP: {HP}, peníze: {Penize}");
    }
}
