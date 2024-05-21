namespace Uzduotis05
{
    internal class Program
    {
        // Bibliotekos Valdymo Sistema.
        // Sukurkite bibliotekos valdymo sistemą, kuri leis sekti knygas ir jų paskolą.

        // 3. Sukurkite konsolės programą, kuri leis vartotojui pasirinkti veiksmus
        // (pvz., pridėti knygą, pašalinti knygą, paskolinti knygą, grąžinti knygą, rodyti visas knygas, rodyti paskolintas knygas).

        private static int id = 0;
        private static Biblioteka biblioteka = new();

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
                Console.WriteLine("1.Prideti knyga\n2.Pasalinti knyga\n3.Paskolinti knyga\n4.Grazinti knyga\n" +
                    "5.Rodyti visas knygas\n6.Rodyti paskolintas knygas\n           0. Baigti darba.\n");
                isInt = int.TryParse(Console.ReadLine(), out selection);
                Console.WriteLine();
            }
            while (!isInt || selection < 0 || selection > 6);

            switch (selection)
            {
                case 0:
                    Console.WriteLine($"Programa baigia darba.");
                    return;
                case 1: // Prideti nauja knyga
                    biblioteka.PridetiKnyga(SukurtiKnyga());
                    PirminisMeniu();
                    break;
                case 2: // Pasalinti knyga
                    if (biblioteka.Knygos.Count > 0)
                    {
                        biblioteka.RodytiVisasKnygas();
                        biblioteka.PasalintiKnyga(PasirinktiKnygosID());
                    }
                    else
                    {
                        Console.WriteLine("Nera knygu sarase.\n");
                    }
                    PirminisMeniu();
                    break;
                case 3: // Paskolinti knyga
                    if (biblioteka.Knygos.Count > 0 && biblioteka.ArYraNepaskolintuKnygu())
                    {
                        biblioteka.RodytiNepaskolintasKnygas();
                        biblioteka.PaskolintiKnyga(PasirinktiKnygosID());
                    }
                    else
                    {
                        Console.WriteLine("Nera knygu, kurias galima paskolinti.\n");
                    }
                    PirminisMeniu();
                    break;
                case 4: // Grazinti knyga
                    if (biblioteka.Knygos.Count > 0 && biblioteka.ArYraPaskolintuKnygu())
                    {
                        biblioteka.RodytiPaskolintasKnygas();
                        biblioteka.GrazintiKnyga(PasirinktiKnygosID());
                    }
                    else
                    {
                        Console.WriteLine("Nera knygu, kurias galima grazinti.\n");
                    }
                    PirminisMeniu();
                    break;
                case 5: // Rodyti visas knygas
                    if (biblioteka.Knygos.Count > 0)
                    {
                        biblioteka.RodytiVisasKnygas();
                    }
                    else
                    {
                        Console.WriteLine("Nera knygu sarase.\n");
                    }
                    PirminisMeniu();
                    break;
                case 6: // Rodyti paskolintas knygas
                    if (biblioteka.Knygos.Count > 0)
                    {
                        biblioteka.RodytiPaskolintasKnygas();
                    }
                    else
                    {
                        Console.WriteLine("Nera knygu sarase.\n");
                    }
                    PirminisMeniu();
                    break;
                default:
                    Console.WriteLine($"Ivyko nenumatyta klaida, programa baigia darba.");
                    return;
            }
        }

        public static Knyga? SukurtiKnyga()
        {
            // Gauti knygos pavadinimą
            string? pavadinimas;
            do
            {
                Console.WriteLine("Koks knygos pavadinimas? " +
                    "(Atsaukti: -1)\n");
                pavadinimas = Console.ReadLine();
                if (pavadinimas == "-1")
                {
                    Console.WriteLine("\nAtsaukta\n");
                    return null;
                }
            }
            while (pavadinimas == null);

            // Gauti knygos autorių
            string? autorius;
            do
            {
                Console.WriteLine("Kas yra knygos autorius? " +
                    "(Atsaukti: -1)\n");
                autorius = Console.ReadLine();
                if (autorius == "-1")
                {
                    Console.WriteLine("\nAtsaukta\n");
                    return null;
                }
            }
            while (autorius == null);
            Console.WriteLine();

            // Sukurti knygą ir grąžinti ją
            Knyga knyga = new(id, pavadinimas, autorius);
            id++;
            Console.WriteLine($"Sukurta nauja knyga:\n{knyga.ToString()}\n");

            return knyga;
        }

        public static int PasirinktiKnygosID()
        {
            int selection;
            bool isInt;
            do
            {
                Console.WriteLine("Irasykite knygos ID numerį iš sąrašo (pvz., \"5\" ar \"005\") " +
                    "(Atsaukti: -1)\n");
                isInt = int.TryParse(Console.ReadLine(), out selection);
                if (selection == -1)
                {
                    Console.WriteLine("\nAtsaukta\n");
                    return selection;
                }
            }
            while (!isInt || !biblioteka.YraKnygosID(selection));

            Console.WriteLine();

            return selection;
        }
    }
}
