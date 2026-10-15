class Objekt {

    public string Cena { get; set; }
    public string Nazev { get; set; }
    public string Popis { get; set; }


    public Objekt(string cena, string nazev, string popis :base ){
        Cena = cena;
        Nazev = nazev;
        Popis = popis;
    }
    
    public void VypisInformace (){
        Console.WriteLine($"Název: {Nazev}");
        Console.WriteLine($"Cena: {Cena}");
        Console.WriteLine($"Popis: {Popis}");
    }


}