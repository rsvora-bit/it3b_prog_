static class Matematika {

    public int Maksymum(int a, int b) {
        if (a > b) {
            return a;
        } else {
            return b;
        }
    }

    public int Maksymum(int a, int b, int c) {
        if (a > b && a > c) {
            return a;
        } else if (b > a && b > c) {
            return b;
        } else {
            return c;
        }
    }

    public int Maksymum(int[])
    {
        int max = pole[0];
        foreach(int prvek in pole) {
            if(prvek > max) {
                max = prvek;
            }
        }
        return max;
    }
}