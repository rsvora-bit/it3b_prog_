class Savec
{
    public string Jmeno { get; set; }
    public int Hmotnost { get; set; }
    public int Energie { get; set; }
    public string PovoleneJidlo { get; set; }
    public bool Nazivu { get; set; }

    public Savec(string jmeno, int hmotnost, string povoleneJidlo)
    {
        Jmeno = jmeno;
        Hmotnost = hmotnost;
        Energie = 100;
        PovoleneJidlo = povoleneJidlo;
        Nazivu = true;
    }

    public void Snez(string jidlo)
    {
        if (jidlo == PovoleneJidlo)
        {
            Energie += 10;
            Console.WriteLine($"{Jmeno} snedl {jidlo} a ziskal energii");
        }
        else
        {
            Console.WriteLine($"{Jmeno} nemuze jist {jidlo}");
        }
    }

    public void Odpocivej(int pocet_hodin)
    {
        Energie += pocet_hodin * 10;
        Console.WriteLine($"{Jmeno} odpocival {pocet_hodin} hodin");
    }

    public void ZkontrolujEnergii()
    {
        if (Energie < 0)
        {
            Nazivu = false;
            Console.WriteLine($"{Jmeno} umrel");
        }
    }

    public void VypisInformace()
    {
        Console.WriteLine($"Jmeno: {Jmeno}");
        Console.WriteLine($"Hmotnost: {Hmotnost}");
        Console.WriteLine($"Energie: {Energie}");
        Console.WriteLine($"Nazivu: {Nazivu}");
    }
}