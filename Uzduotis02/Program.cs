using Uzduotis02;

namespace Paskaita04
{
    public class Program
    {
        // Užduotis 2: Klasės ir Objektai
        // Sukurkite programą, kuri atliks šias užduotis:
        // Sukurkite klasę Studentas su šiais laukais: vardas(string), amzius(int), balas(double).
        // Sukurkite metodą, kuris grąžina studento informaciją kaip string.
        // Sukurkite kelis studentų objektus ir pridėkite juos į sąrašą.
        // Išspausdinkite visų studentų informaciją.
        public static void Main(string[] args)
        {
            Studentas studentas1 = new("Amelija", 21, 8.75);
            Studentas studentas2 = new("Benas", 20, 9.15);
            Studentas studentas3 = new("Cicinas", 22, 5.15);
            Studentas studentas4 = new("Daiva", 21, 9.95);
            Studentas studentas5 = new("Emilija", 19, 8.8);

            List<Studentas> studentai = new() { studentas1, studentas2, studentas3, studentas4, studentas5 };

            foreach (Studentas studentas in studentai)
            {
                Console.WriteLine(studentas.ReturnAllAsString());
            }
        }
    }
}