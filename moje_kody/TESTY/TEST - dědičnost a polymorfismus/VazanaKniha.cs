class VazanaKniha : Dokument
{
    public VazanaKniha(string nazev, int pocetStran)
        : base(nazev, pocetStran)
    {
    }

    public override double OdhadMinut()
    {
        return PocetStran * 2;
    }
}
