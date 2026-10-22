static class HracHlasky
{
    static public void Utok()
    {
        Console.WriteLine("Hráč útočí!");
    }

    static public void Utok(int sila)
    {
        Console.WriteLine($"Hráč útočí silou {sila}!");
    }

    static public void Utok(string zbran)
    {
        Console.WriteLine($"Hráč útočí zbraní {zbran}!");
    }

    static public void Utok(int sila, string zbran)
    {
        Console.WriteLine($"Hráč útočí zbraní {zbran} silou {sila}!");
    }

    /*
     *  static void Main() {
     *      HracHlasky.Utok(50);
     *      HracHlasky.Utok(60, "sekera");
     *  }
     */
}