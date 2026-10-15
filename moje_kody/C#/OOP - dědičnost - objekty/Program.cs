class Program {

    static void Main() {

        Dům dům = new Dům(1000, 5);
        Byt byt = new Byt(3);

        dům.VypisInformace();
        Console.WriteLine();
        byt.VypisInformace();
    }
}