class Byt : Objekt {

    public int Patro { get; set; }
    
    public Byt(int patro) : base("1000000", "Byt", "Moderní byt"){
        Patro = patro;
    }

    public void VypisInformace (){
        base.VypisInformace();
        Console.WriteLine($"Patro ve kterém se byt nachází: {Patro}");
    }

}  