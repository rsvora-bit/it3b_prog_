class Hráč {

    public void Utokuje() {
        Console.WriteLine("Hráč útočí!");
    }

    public void Utok(int sila) {
        Console.WriteLine($"Hráč útočí s {síla} silou!");
    }

    public void Utok(string zbran) {
        Console.WriteLine($"Hráč útočí s {zbran}!");
    }

    public void Utok(string zbran, int sila) {
        Console.WriteLine($"Hráč útočí s {zbran} a {síla} silou!");
    }
}