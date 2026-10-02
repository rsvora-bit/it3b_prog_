class Program {

    static void Main(string[] args)
    {
        Kocka kocka = new Kocka("Micka", "4kg", "černá");
        Pes pes = new Pes("Rex", "20kg", "Německý ovčák");

        kocka.VypisInformace();
        kocka.Mňoukni();
        kocka.SnesiJidlo("rybu");

        Console.WriteLine();

        pes.VypisInformace();
        pes.Hafni();
        pes.SnesiJidlo("maso");
    }

}