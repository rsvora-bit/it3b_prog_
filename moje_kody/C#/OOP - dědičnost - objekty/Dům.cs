class Dům : Objekt {

    public int VymeraZahrady { get; set; }
    public int PočetPater { get; set; }
    
    public Dům(int vymeraZahrady, int početPater) : base("2000000", "Dům", "Pětipatrový dům"){
        VymeraZahrady = vymeraZahrady;
        PočetPater = početPater;
    }

    public void VypisInformace (){
        base.VypisInformace();
        Console.WriteLine($"Výmera zahrady v (m2): {VymeraZahrady}");
        Console.WriteLine($"Počet pater: {PočetPater}");
        Console.WriteLine($"Celková cena domu: {Cena}");
        Console.WriteLine($"Popis domu: {Popis}");
    }

}