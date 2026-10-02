class Kocka : Savec
{
    public string Barva { get; set; }

    public Kocka(string jmeno, int hmotnost, string barva) : base(jmeno, hmotnost, "ryba")
    {
        Barva = barva;
    }

    public void Mnoukni()
    {
        Energie -= 5;

        Console.WriteLine($"{Jmeno} mnouka");

        ZkontrolujEnergii();
    }

    public void VypisInformace()
    {
        base.VypisInformace();
        Console.WriteLine($"Barva: {Barva}");
    }
}