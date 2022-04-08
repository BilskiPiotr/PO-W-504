// Autor. mgr. inż Piotr Bilski
// Programowanie Obiektowe
using System;

namespace PO_W_504
{
    class Mecz
    {
        // deklaracja właściwości z jednoczesnym przypisaniem wartości
        public int wynik { get; set; } = 0;
        // nadpisanie pozytywnego operatora porównania
        public static bool operator ==(Mecz blueTeam, Mecz redTeam)
        {
            return blueTeam.wynik == redTeam.wynik;
        }
        // nadpisanie negatynego operatora porównania
        public static bool operator !=(Mecz blueTeam, Mecz redTeam)
        {
            return blueTeam.wynik != redTeam.wynik;
        }
        //następnie przeciążamy operator logiczny Equals()
        public bool Equals(Mecz check)
        {
            if (ReferenceEquals(check, null)) return false;
            if (ReferenceEquals(check, this)) return true;
            return int.Equals(wynik, check.wynik);
        }
        // nadpisujemy metodę Equals() na potrzeby klasy Mecz
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;

            return Equals(obj as Mecz);
        }
        // nadpisanie metody GetHashCode(), która teraz porówna
        // wartość pola wynik a nie generowanej wartości int
        public override int GetHashCode()
        {
            return wynik.GetHashCode();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // tworzymy dwa obiekty o różnej wartości
            Mecz playerOne = new Mecz();
            Mecz playerTwo = new Mecz();
            // i jednemu z nich przypisujemy wartość
            playerOne.wynik = 10;

            // porównujemy kody hash nowych obiektów
            Console.WriteLine("  Porównujemy obiekty playerOne oraz playerTwo pod kątem " +
                              "\n  wartości hash, co da nam odpowiedź na pytanie, " +
                              "\n  czy sa one podobne:\n");
            bool porównajHashCode = (playerOne.GetHashCode() == playerTwo.GetHashCode());
            if (porównajHashCode)
                Console.WriteLine("  HashCode playerOne = {0}, " +
                                  "\n  HashCode PlayerTwo = {1}, " +
                                  "\n  co oznacza, że obiekty sa podobne",
                                  playerOne.GetHashCode(), playerTwo.GetHashCode());
            else
                Console.WriteLine("  HashCode playerOne = {0}, " +
                                  "\n  HashCode PlayerTwo = {1}, " +
                                  "\n  co oznacza, że obiekty sa różne",
                                  playerOne.GetHashCode(), playerTwo.GetHashCode());
            Console.ReadKey();

            // jeśli są podobne, to sprawdzamy czy to ten sam obiekt,
            // czy też po prostu różne obiekty o tej samej wartości.
            Console.WriteLine("\n\n\n  Porównanie referencji obiektów, jeśli metoda" +
                              " GetHashCode() zwróciła TRUE:\n");
            if (porównajHashCode)
            {
                bool porównajObiekty = (playerOne.Equals(playerTwo));
                if (porównajObiekty)
                    Console.WriteLine("  Referencje obiektów wskazują " +
                                      "na ten sam obszar pamięci");
                else
                    Console.WriteLine("Referencje obiektów wskazują " +
                                      "na rózne obszary pamięci");
            }
            else
                Console.WriteLine("  Metoda Equals() nie została wywołana.");
            Console.ReadKey();

            // wykorzystanie operatora porównania
            Console.WriteLine("\n\n\n  Sprawdzenie wyniku meczu, czyli ustalenie" +
                              " czy w meczu jest zwycięzca:\n");
            if (!porównajHashCode)
            {
                bool czyJestZwycięzca = (playerOne == playerTwo);
                if (czyJestZwycięzca)
                    Console.WriteLine("  Remis");
                else
                    Console.WriteLine("  Jest zwycięzca");
                Console.ReadKey();
            }
        }
    }
}
