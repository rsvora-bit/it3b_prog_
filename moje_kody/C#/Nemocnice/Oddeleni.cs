class Oddeleni
{
    public string Jmeno { get; set; }
    public string Mistnost { get; set; }
    public string VrchniSestra { get; set; }

    public Oddeleni(string jmeno, string mistnost, string vrchnisestra)
    {
        Jmeno = jmeno;
        Mistnost = mistnost;
        VrchniSestra = vrchnisestra;
    }

    public void VolneLuzka(int volneluska)
    {
        Mistnost volnaLuzka = new Mistnost(10, 5); 
        volnaLuzka.VolneLuzka(volneluska);

    }

    Oddeleni oddeleni = new Oddeleni("Chirurgie", "101", "Jana Nováková");
    
}