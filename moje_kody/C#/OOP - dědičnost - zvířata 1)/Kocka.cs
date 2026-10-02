class Kocka : Savec {

    public string Barva { get; set; }

    public Kocka(string jmeno, string hmotnost, string barva) : base(jmeno, hmotnost){
        Barva = barva;
    }

    public void Mňoukni (){
        Console.WriteLine($"{Jmeno} mňouká");
    }

    public void VypisInformace (){
        base.VypisInformace();
        Console.WriteLine($"Barva: {Barva}");
    }

    public void SnesiJidlo (string jidlo){
        Console.WriteLine($"{Jmeno} snědl {jidlo} a spokojeně přede");
    }
    
}