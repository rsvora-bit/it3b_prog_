class Sestricka
{
    public string Jmeno { get; set; }
    private int Plat;
    public string Oddeleni { get; set; }

    public Sestricka(string jmeno, int plat)
    {
        Jmeno = jmeno;
        Plat = plat;
        Oddeleni = null;
    }

    public void ZvyseniPlatu(int zvysplat)
    {
        Plat += zvysplat;
    }

    public void SnizeniPlatu(int snizplat)
    {
        if (snizplat > Plat)
        {
            Console.WriteLine("Nelze snížit plat o více než je aktuální plat.");
            return;
        }

        Plat -= snizplat;
    }

    Oddeleni oddeleni = new Oddeleni("Chirurgie", "101", "Jana Nováková");


}

