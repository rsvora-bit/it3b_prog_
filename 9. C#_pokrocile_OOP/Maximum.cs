static class Matematika
{
    static public int Maximum(int a, int b)
    {
        if (a < b)
            return b;
        return a;
    }

    static public int Maximum(int a, int b, int c)
    {
        if (a >= b && a >= c)
            return a;
        else if (b >= c)
            return b;
        return c;
    }

    static public int Maximum(int[] pole)
    {
        if (pole.Length == 0)
            Console.WriteLine("Nelze získat maxium prázdného pole");
            return 0;

        int max = pole[0];
        foreach(int prvek in pole)
        {
            if (prvek > max)
                max = prvek;
        }
        return max;
    }
}