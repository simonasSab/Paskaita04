namespace Paskaita04
{
    public class Uzduotis01
    {
        // Užduotis 1: Sąrašų Manipuliacija
        // Sukurkite programą, kuri atliks šias užduotis su sąrašu:
        // Sukurs sąrašą, kuriame yra šie sveikieji skaičiai: 5, 3, 8, 4, 2.
        // Išspausdins sąrašo elementus.
        // Pridės skaičių 10 į sąrašo pabaigą.
        // Ištrins skaičių 4 iš sąrašo.
        // Rūšiuos sąrašą didėjančia tvarka.
        // Išspausdins sąrašą po kiekvieno pakeitimo.
        public static void Main(string[] args)
        {
            List<int> ints = new() { 5, 3, 8, 4, 2 };

            foreach (int x in ints)
            {
                Console.Write($"{x} ");
            }

            ints.Add(10);
            foreach (int x in ints)
            {
                Console.Write($"{x} ");
            }

            ints.Remove(4);
            foreach (int x in ints)
            {
                Console.Write($"{x} ");
            }

            ints.Sort();
            foreach (int x in ints)
            {
                Console.Write($"{x} ");
            }
        }
    }
}