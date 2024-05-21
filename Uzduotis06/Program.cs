namespace Uzduotis06
{
    // 6 užduotis.
    // Sukurkite restorano užsakymų valdymo sistemą, kuri leis sekti klientų užsakymus ir užsakytų patiekalų būseną.
    // 
    // 4. Sukurkite konsolės programą, kuri leis vartotojui pasirinkti veiksmus (pvz., pridėti patiekalą į meniu, rodyti visus
    // patiekalus, pridėti užsakymą, keisti patiekalo būseną, rodyti visus užsakymus, rodyti konkretaus užsakymo informaciją).
    internal class Program
    {
        private static Restoranas restoranas = new();
        private static int meniuID = 0;
        private static int uzsakymuID = 0;
        public static void Main(string[] args)
        {
            PirminisMeniu();
        }

        private static void PirminisMeniu()
        {
            int selection;
            bool isInt;
            do
            {
                Console.WriteLine("1.Prideti patiekala i Meniu" +
                                "\n2.Rodyti visa Meniu" +
                                "\n3.Naujas uzsakymas" +
                                "\n4.Keisti patiekalo busena uzsakyme" +
                                "\n5.Rodyti visus uzsakymus" +
                                "\n6.Rodyti uzsakymo informacija" +
                                "\n7.Naikinti patiekala is Meniu" +
                                "\n8.Naikinti patiekala is uzsakymo" +
                                "\n9.Naikinti uzsakyma" +
                                "\n           0. Baigti darba.\n");
                isInt = int.TryParse(Console.ReadLine(), out selection);
                Console.WriteLine();
            }
            while (!isInt || selection < 0 || selection > 9);

            switch (selection)
            {
                case 0:
                    Console.WriteLine($"Programa baigia darba.");
                    return;
                case 1: // Prideti nauja patiekala i Meniu
                    restoranas.PridetiPatiekalaIMeniu(SukurtiPatiekala(ref meniuID));
                    break;
                case 2: // Rodyti visa Meniu
                    if (restoranas.Meniu.Count > 0)
                    {
                        restoranas.RodytiVisusPatiekalus();
                    }
                    else
                    {
                        Console.WriteLine("Meniu nera patiekalu.\n");
                    }
                    break;
                case 3: // Naujas uzsakymas
                    if (restoranas.Meniu.Count > 0)
                    {
                        restoranas.PridetiUzsakyma(SukurtiUzsakyma(ref uzsakymuID));
                        uzsakymuID++;
                    }
                    else
                    {
                        Console.WriteLine("Meniu dar nera patiekalu.\n");
                    }
                    break;
                case 4: // Keisti patiekalo busena uzsakyme
                    if (restoranas.Uzsakymai.Count > 0)
                    {
                        restoranas.RodytiVisusUzsakymus();
                        int uzsakymoID = PasirinktiUzsakymoID();
                        if (uzsakymoID == -1)
                            break;

                        restoranas.RodytiUzsakyma(uzsakymoID);
                        int patiekaloID = PasirinktiPatiekaloID(uzsakymoID);
                        if (patiekaloID != -1)
                            restoranas.KeistiPatiekaloBusena(uzsakymoID, patiekaloID, PasirinktiPatiekaloBusena());
                    }
                    else
                    {
                        Console.WriteLine("Uzsakymu sarasas tuscias.\n");
                    }
                    break;
                case 5: // Rodyti visus uzsakymus
                    if (restoranas.Uzsakymai.Count > 0)
                    {
                        restoranas.RodytiVisusUzsakymus();
                    }
                    else
                    {
                        Console.WriteLine("Uzsakymu sarasas tuscias.\n");
                    }
                    break;
                case 6: // Rodyti uzsakymo informacija
                    if (restoranas.Uzsakymai.Count > 0)
                    {
                        restoranas.RodytiVisusUzsakymus();
                        int uzsakymoID = PasirinktiUzsakymoID();
                        if (uzsakymoID != -1)
                            restoranas.RodytiUzsakyma(uzsakymoID);
                    }
                    else
                    {
                        Console.WriteLine("Uzsakymu sarasas tuscias.\n");
                    }
                    break;
                case 7: // Naikinti patiekala is Meniu
                    if (restoranas.Meniu.Count > 0)
                    {
                        restoranas.RodytiVisusPatiekalus();
                        restoranas.NaikintiPatiekalaIsMeniu(PasirinktiPatiekaloID());
                    }
                    else
                    {
                        Console.WriteLine("Meniu tuscias.\n");
                    }
                    break;
                case 8: // Naikinti patiekala is uzsakymo
                    if (restoranas.Uzsakymai.Count > 0)
                    {
                        restoranas.RodytiVisusUzsakymus();
                        int uzsakymoID = PasirinktiUzsakymoID();
                        if (uzsakymoID == -1)
                            break;
                        restoranas.RodytiUzsakyma(uzsakymoID);
                        int patiekaloID = PasirinktiPatiekaloID(uzsakymoID);
                        if (patiekaloID != -1)
                            restoranas.NaikintiPatiekalaIsUzsakymo(uzsakymoID, patiekaloID);
                    }
                    else
                    {
                        Console.WriteLine("Uzsakymu sarasas tuscias.\n");
                    }
                    break;
                case 9: // Naikinti uzsakyma
                    if (restoranas.Uzsakymai.Count > 0)
                    {
                        restoranas.RodytiVisusUzsakymus();
                        int uzsakymoID = PasirinktiUzsakymoID();
                        if (uzsakymoID != -1)
                            restoranas.NaikintiUzsakymaIsUzsakymu(uzsakymoID);
                    }
                    else
                    {
                        Console.WriteLine("Uzsakymu sarasas tuscias.\n");
                    }
                    break;
                default:
                    Console.WriteLine($"Ivyko nenumatyta klaida, programa baigia darba.");
                    return;
            }
            PirminisMeniu();
        }

        static Patiekalas? SukurtiPatiekala(ref int id)
        {
            // Gauti patiekalo pavadinimą
            string? pavadinimas;
            do
            {
                Console.WriteLine("Koks patiekalo pavadinimas? " +
                    "(Atsaukti: -1)\n");
                pavadinimas = Console.ReadLine();
                if (pavadinimas == "-1")
                {
                    Console.WriteLine("\nAtsaukta\n");
                    return null;
                }
            }
            while (pavadinimas == null);

            // Gauti patiekalo kainą
            double kaina;
            bool isDouble;
            do
            {
                Console.WriteLine("Kokia patiekalo kaina eurais? (Pvz., 2.56)" +
                    "(Atsaukti: -1)\n");
                isDouble = double.TryParse(Console.ReadLine(), out kaina);
                if (kaina == -1)
                {
                    Console.WriteLine("\nAtsaukta\n");
                    return null;
                }
            }
            while (!isDouble || kaina < 0.01 || kaina > 10000);
            Console.WriteLine();

            // Sukurti patiekalą ir jį grąžinti
            Patiekalas patiekalas = new(id, pavadinimas, kaina);
            id++;
            
            Console.WriteLine($"Sukurtas naujas patiekalas:\n{patiekalas.ToString()}\n");

            return patiekalas;
        }

        public static Uzsakymas? SukurtiUzsakyma(ref int id)
        {
            // Kiekvienas užsakymas turi naujus ID patiekalams
            int patiekaloIdUzsakyme = 0;
            List<Patiekalas> patiekalai = new();

            // Gauti kliento vardą
            string? klientas;
            do
            {
                Console.WriteLine("Koks Jusu vardas, o, maloningasai kliente? " +
                    "(Atsaukti: -1)\n");
                klientas = Console.ReadLine();
                if (klientas == "-1")
                {
                    Console.WriteLine("\nAtsaukta\n");
                    return null;
                }
            }
            while (klientas == null);

            // Toliau prašoma kliento pasirinkti patiekalą iš Meniu ir patvirtinti arba atmesti.
            // Tai kartojama, kol klientas pasirenka nebesirinkti naujo patiekalo.
            string confirmation = "";
            do
            {
                restoranas.RodytiVisusPatiekalus();
                int patiekaloIdMeniu = PasirinktiPatiekaloID();
                if (patiekaloIdMeniu != -1)
                {
                    do
                    {
                        Console.WriteLine("Patvirtinkite pasirinkima (taip / ne)\n");
                        try
                        {
                            confirmation = Console.ReadLine();
                        }
                        catch
                        {
                            confirmation = "";
                        }
                        Console.WriteLine();
                        confirmation = confirmation.ToLower();
                    }
                    while (confirmation != "taip" && confirmation != "ne");

                    if (confirmation != "ne")
                    {
                        Patiekalas patiekalas = new(patiekaloIdUzsakyme, restoranas.Meniu[restoranas.GautiPatiekaloIndexIsID(patiekaloIdMeniu)].Pavadinimas,
                                                                    restoranas.Meniu[restoranas.GautiPatiekaloIndexIsID(patiekaloIdMeniu)].Kaina);
                        patiekalai.Add(patiekalas);
                        patiekaloIdUzsakyme++;
                    }
                }
                
                do
                {
                    Console.WriteLine("Ar norite uzsakyti dar viena patiekala (taip / ne)?\n");
                    try
                    {
                        confirmation = Console.ReadLine();
                    }
                    catch
                    {
                        confirmation = "";
                    }
                    Console.WriteLine();
                    confirmation = confirmation.ToLower();
                }
                while (confirmation != "taip" && confirmation != "ne");
            }
            while (confirmation == "taip");
            
            if (patiekalai.Count > 0)
            {
                Uzsakymas uzsakymas = new(id, klientas, patiekalai);
                return uzsakymas;
            }
            else
            {
                return null;
            }
        }
        // Nenurodant ID, patiekalas pasirenkamas iš Meniu
        public static int PasirinktiPatiekaloID()
        {
            int selection;
            bool isInt;
            do
            {
                Console.WriteLine("Irasykite patiekalo ID numerį iš sąrašo (pvz., \"5\" ar \"005\") " +
                    "(Atsaukti: -1)\n");
                isInt = int.TryParse(Console.ReadLine(), out selection);
                if (selection == -1)
                {
                    Console.WriteLine("\nAtsaukta\n");
                    return selection;
                }
            }
            while (!isInt || !restoranas.YraPatiekaloID(selection));

            Console.WriteLine();

            return selection;
        }
        // Nurodant ID, patiekalas pasirenkamas iš konkretaus užsakymo
        public static int PasirinktiPatiekaloID(int uzsakymoId)
        {
            int selection;
            bool isInt;
            int uzsakymoIndex = restoranas.GautiUzsakymoIndexIsID(uzsakymoId);
            do
            {
                Console.WriteLine("Irasykite patiekalo ID numerį iš sąrašo (pvz., \"5\" ar \"005\") " +
                    "(Atsaukti: -1)\n");
                isInt = int.TryParse(Console.ReadLine(), out selection);
                if (selection == -1)
                {
                    Console.WriteLine("\nAtsaukta\n");
                    return selection;
                }
            }
            while (!isInt || !restoranas.Uzsakymai[uzsakymoIndex].YraPatiekaloID(selection));

            Console.WriteLine();

            return selection;
        }

        // Naudotojo prašoma pasirinkti užsakymą, su kuriuo nori dirbti
        public static int PasirinktiUzsakymoID()
        {
            int selection;
            bool isInt;
            do
            {
                Console.WriteLine("Irasykite uzsakymo ID numerį iš sąrašo (pvz., \"5\" ar \"005\") " +
                    "(Atsaukti: -1)\n");
                isInt = int.TryParse(Console.ReadLine(), out selection);
                if (selection == -1)
                {
                    Console.WriteLine("\nAtsaukta\n");
                    return selection;
                }
            }
            while (!isInt || !restoranas.YraUzsakymoID(selection));

            Console.WriteLine();

            return selection;
        }

        // Naudotojo prašoma pasirinkti užsakymo patiekalo būseną
        public static string PasirinktiPatiekaloBusena()
        {
            string selection;
            do
            {
                Console.WriteLine("Irasykite busena: \"laukiama\", \"ruosiama\" arba \"paruosta\" " +
                    "(Atsaukti: -1)\n");
                selection = Console.ReadLine();
                if (selection == "-1")
                {
                    Console.WriteLine("\nAtsaukta\n");
                    return selection;
                }
                selection = selection.ToLower();
            }
            while (selection == null || (selection != "laukiama" && selection != "ruosiama" && selection != "paruosta"));

            Console.WriteLine();

            return selection;
        }
    }
}
