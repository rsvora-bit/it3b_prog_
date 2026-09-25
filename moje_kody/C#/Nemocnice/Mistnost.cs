class Mistnost
{
    public int PocetLuzek { get; set; }
    public int PocetObsazenychLuzek { get; set; }

    public Mistnost(int pocetluzek, int pocetobsazenychluzek)
    {
        PocetLuzek = pocetluzek;
        PocetObsazenychLuzek = pocetobsazenychluzek;

    }
    public void VolneLuzka(int volneluzka)
    {
        if (volneluzka < 0)
        {
            Console.WriteLine("Počet volných lůžek nemůže být záporný.");
            return;
        }

        if (volneluzka > PocetLuzek - PocetObsazenychLuzek)
        {
            Console.WriteLine("Počet volných lůžek nemůže být větší než celkový počet lůžek minus obsazená lůžka.");
            return;
        }

        PocetObsazenychLuzek = PocetLuzek - volneluzka;
    }
    
   
}