class VolneListy : Dokument
{
    public VolneListy(string nazev, int pocetStran)
        : base(nazev, pocetStran)
    {
    }

    public override double OdhadMinut()
    {
        return PocetStran + 5;
    }
}