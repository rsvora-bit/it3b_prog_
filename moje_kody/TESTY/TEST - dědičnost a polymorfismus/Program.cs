class Program
{
    static void Main()
    {
        DigitalizacniLinka linka = new DigitalizacniLinka(25);

        linka.Zarad("Uredni dopis", 3);

        linka.Zarad(
            new VazanaKniha("Matrika", 15)
        );

        linka.Zarad(
            new VolneListy("Ucetni vykazy", 8)
        );

        linka.Zarad(
            new Dokument("Mapa", 2)
        );

        linka.SpustDavku();
    }
}