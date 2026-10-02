class Pes : Savec {
    
    public string Plemeno { get; set; }

    public Pes(string jmeno, string hmotnost, string plemeno) : base(jmeno, hmotnost){
        Plemeno = plemeno;
    }

    public void Hafni (){
        Console.WriteLine($"{Jmeno} štěká");
    }

    public void VypisInformace (){
        base.VypisInformace();
        Console.WriteLine($"Plemeno: {Plemeno}");
    }

    public void SnesiJidlo (string jidlo){
        Console.WriteLine($"{Jmeno} snědl {jidlo} a spokojeně zavrčel");
    }
}