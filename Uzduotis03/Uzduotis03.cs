namespace Uzduotis03
{
    internal class Uzduotis03
    {
        // Užduotis 3: Ciklai ir Sąlygos Sakiai
        // Sukurkite programą, kuri atliks šias užduotis:
        // Sugeneruos atsitiktinių (nuo 1 iki 100) sveikųjų skaičių sąrašą, kurio ilgį nustato naudotojas.
        // Naudos ciklą, kad patikrintų kiekvieną skaičių ir išspausdins
        // "Fizz", jei skaičius dalijasi iš 3,
        // "Buzz", jei dalijasi iš 5, ir
        // "FizzBuzz", jei dalijasi ir iš 3, ir iš 5. Jei nei viena iš šių sąlygų netinka, išspausdins patį skaičių.
        public static void Main(string[] args)
        {
            Random random = new();
            List<int> ints = new();

            // Gauti is naudotojo, kiek skaiciu reikia patikrinti
            bool isInt = false;
            int intCount;
            do
            {
                Console.WriteLine("Irasykite teigiama sveikaji skaiciu, kiek norite ju patikrinti: ");
                isInt = int.TryParse(Console.ReadLine(), out intCount);

            }
            while (!isInt || intCount < 1);

            int temp;

            for (int i = 0; i < intCount; i++)
            {
                // Generuoti ir pridėti naują skaičių
                temp = random.Next(1, 101);
                ints.Add(temp);

                // Patikrinti Fizz, Buzz ir FizzBuzz sąlygas ir atspausdinti tai, ką atitinka
                if (temp % 3 == 0 && temp % 5 == 0)
                    Console.WriteLine("FizzBuzz");
                else if (temp % 3 == 0)
                    Console.WriteLine("Fizz");
                else if (temp % 5 == 0)
                    Console.WriteLine("Buzz");
                else
                    Console.WriteLine(temp);
            }
        }
    }
}