namespace Paskaita04
{
    internal class Program
    {
        // 4. Užduotis: Studentų administravimas
        // Sukurti programą, kuri atliks šias užduotis:
        // Sukurkite klasę Studentas su šiais laukais: vardas(string), pavarde(string), amzius(int), balai int masyvas, vidurkis double.
        // Sukurkite meniu(1. Sukurti studenta, 2. Istrinti studenta, 3. Isvesti studentus i ekrana)
        // Klasėje Studentas sukurkite funkciją kuri skaičiuoja studento vidurkį
        // Prieš išvedant studentą į ekraną, visada iškviesti šią funkciją, kad ji suskaičiuotų studento vidurkį. (Override'e ToString)
            
        private static List<Studentas> studentai = new();

        public static void Main(string[] args)
        {
            PirminisMeniu();
        }

        public static void PirminisMeniu()
        {
            int selection;
            bool isInt;
            do
            {
                Console.WriteLine("1.Sukurti studenta. 2.Istrinti studenta. 3.Isvesti studentus i ekrana. 0. Baigti darba.");
                isInt = int.TryParse(Console.ReadLine(), out selection);
            }
            while (!isInt || (selection != 0 && selection != 1 && selection != 2 && selection != 3));

            switch (selection)
            {
                case 0:
                    Console.WriteLine($"Programa baigia darba.");
                    return;
                case 1:
                    SukurtiStudenta();
                    PirminisMeniu();
                    break;
                case 2:
                    if (studentai.Count == 0)
                    {
                        Console.WriteLine("Nera studentu sarase.\n");
                    }
                    else
                    {
                        ParodytiStudentusEkrane();
                        studentai.RemoveAt(PasirinktiStudentoNumeri());
                    }
                    PirminisMeniu();
                    break;
                case 3:
                    if (studentai.Count == 0)
                        Console.WriteLine("Nera studentu sarase.\n");
                    else
                        ParodytiStudentusEkrane();
                    PirminisMeniu();
                    break;
                default:
                    Console.WriteLine($"Ivyko klaida, programa baigia darba.");
                    return;
            }
            Console.WriteLine();
        }

        public static void SukurtiStudenta()
        {
            // Gauti vardą
            string vardas;
            do
            {
                Console.WriteLine("Iveskite varda");
                vardas = Console.ReadLine();
            }
            while (vardas == null);

            // Gauti pavardę
            string pavarde;
            do
            {
                Console.WriteLine("Iveskite pavarde");
                pavarde = Console.ReadLine();
            }
            while (pavarde == null);

            // Gauti amžių
            int amzius; bool isInt;
            do
            {
                Console.WriteLine("Iveskite amziu (sveikaji skaiciu)");
                isInt = int.TryParse(Console.ReadLine(), out amzius);
            }
            while (!isInt || amzius < 1);

            // Preliminariai sukuriame studento įrašą be pažymių
            Studentas studentas = new(vardas, pavarde, amzius, [0]);

            // Patikrinti, ar nėra studento su tokiais pačiais vardu, pavarde ir amžiumi.
            // Jei yra, atšaukti studento kūrimą
            if (studentai.Contains(studentas))
            {
                Console.WriteLine($"Studentas su tokiais vardu, pavarde ir amžiumi jau egzistuoja!\nJei norite redaguoti, ištrinkite esamą įrašą.");
                studentai.Remove(studentas);

                return;
            }

            // Gauti pažymių masyvą (pirma - masyvo ilgį, po to - kiekvieną pažymį)
            int pazymiuSkaicius;
            do
            {
                Console.WriteLine("Kiek pazymiu turi studentas?");
                isInt = int.TryParse(Console.ReadLine(), out pazymiuSkaicius);
            }
            while (!isInt || pazymiuSkaicius < 1);

            int[] balai = new int[pazymiuSkaicius];

            for (int i = 0; i < pazymiuSkaicius; i++)
            {
                int balas;
                do
                {
                    Console.WriteLine($"Iveskite pazymi nr. {i + 1}");
                    isInt = int.TryParse(Console.ReadLine(), out balas);
                }
                while (!isInt || balas < 1 || balas > 10);

                balai[i] = balas;
            }

            studentas.Balai = balai;
            // Įdėti studentą į sąrašą, grąžinti užpildytą studentą
            studentai.Add(studentas);

            Console.WriteLine($"Sukurtas naujas studentas:\n{studentas.ToString()}\n");
        }

        public static void ParodytiStudentusEkrane()
        {
            for (int i = 0; i < studentai.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {studentai[i].ToString()}");
            }
            Console.WriteLine();
        }

        public static int PasirinktiStudentoNumeri()
        {
            int selection;
            bool isInt;
            do
            {
                Console.WriteLine("Parašykite studento eilės numerį iš sąrašo (pvz., \"5\")");
                isInt = int.TryParse(Console.ReadLine(), out selection);
            }
            while (!isInt || selection < 1 || selection > studentai.Count);

            Console.WriteLine();

            return selection - 1;
        }
    }
}