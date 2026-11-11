class DigitalizacniLinka
{
    public double ZbyvajiciCas { get; set; }
    public List<Dokument> Dokumenty { get; set; }

    public DigitalizacniLinka(double zbyvajiciCas)
    {
        ZbyvajiciCas = zbyvajiciCas;
        Dokumenty = new List<Dokument>();
    }

    public void Zarad(Dokument dokument)
    {
        Dokumenty.Add(dokument);
    }

    public void Zarad(string nazev, int pocetStran)
    {
        Dokument dokument = new Dokument(nazev, pocetStran);
        Dokumenty.Add(dokument);
    }

    public void SpustDavku()
    {
        
    }
}