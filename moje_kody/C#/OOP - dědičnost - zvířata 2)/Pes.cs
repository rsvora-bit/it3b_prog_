class Pes : Savec
{
    public string Plemeno { get; set; }

    public Pes(string jmeno, int hmotnost, string plemeno) : base(jmeno, hmotnost, "maso")
    {
        Plemeno = plemeno;
    }

    public void Hafni()
    {
        Energie -= 10;

        Console.WriteLine($"{Jmeno} steka");

        ZkontrolujEnergii();
    }

    public void VypisInformace()
    {
        base.VypisInformace();
        Console.WriteLine($"Plemeno: {Plemeno}");
    }
}