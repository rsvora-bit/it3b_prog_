class Dokument
{
    public string Nazev { get; set; }
    public int PocetStran { get; set; }
    public bool Digitalizovany { get; set; }

    public Dokument(string nazev, int pocetStran)
    {
        Nazev = nazev;
        PocetStran = pocetStran;
        Digitalizovany = false;
    }

    public virtual double OdhadMinut()
    {
        return PocetStran * 1.5;
    }

    public void Digitalizuj()
    {
        Digitalizovany = true;
    }
} 