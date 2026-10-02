class Savec{
    public string Jmeno { get; set; }
    public string Hmotnost { get; set; }

    public Savec(string jmeno, string hmotnost){
        Jmeno = jmeno;
        Hmotnost = hmotnost;
    }

    public void Snez (string jidlo){
        Console.WriteLine($"{Jmeno} snědl {jidlo}");
    }

    public void Spat (){
        Console.WriteLine($"{Jmeno} spí");
    }

    public void VypisInformace (){
        Console.WriteLine($"Jméno: {Jmeno}, Hmotnost: {Hmotnost}");
    }
}