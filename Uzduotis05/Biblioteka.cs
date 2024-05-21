namespace Uzduotis05
{
    internal class Biblioteka
    {
        // Bibliotekos Valdymo Sistema.
        // Sukurkite bibliotekos valdymo sistemą, kuri leis sekti knygas ir jų paskolą.

        // 2. Sukurkite klasę Biblioteka, kuri turės metodus:
        //  * PridetiKnyga(Knyga knyga):   Prideda naują knygą į biblioteką.
        //  * SalintiKnyga(int id):        Pašalina knygą pagal ID.
        //  * PaskolintiKnyga(int id):     Pažymi knygą kaip paskolintą, jei ji nėra paskolinta.
        //  * GrazintiKnyga(int id):       Pažymi knygą kaip grąžintą, jei ji yra paskolinta.
        //  * RodytiVisasKnygas():         Išspausdina visų knygų sąrašą.
        //  * RodytiPaskolintasKnygas():   Išspausdina tik paskolintų knygų sąrašą.

        public List<Knyga> knygos { set; get; }

        public Biblioteka()
        {
            knygos = new();
        }

        public void PridetiKnyga(Knyga? knyga)
        {
            if (knyga != null)
                knygos.Add(knyga);
        }

        public void PasalintiKnyga(int id)
        {
            if (id != -1)
            {
                knygos.RemoveAt(GetIndexByID(id));
                Console.WriteLine($"Sekmingai panaikinta knyga (ID: {id:000})\n");
            }

        }

        public void PaskolintiKnyga(int id)
        {
            if (id != -1)
            {
                if (knygos[GetIndexByID(id)].YraPaskolinta)
                {
                    Console.WriteLine("Knygos paskolinti negalima - ji jau paskolinta!\n");
                }
                else
                {
                    Console.WriteLine($"Sekmingai paskolinta knyga (ID: {id:000})\n");
                    knygos[GetIndexByID(id)].YraPaskolinta = true;
                }
            }
        }

        public void GrazintiKnyga(int id)
        {
            if (id != -1)
            {
                if (!knygos[GetIndexByID(id)].YraPaskolinta)
                {
                    Console.WriteLine("Knygos grazinti negalima - ji jau grazinta!\n");
                }
                else
                {
                    Console.WriteLine($"Sekmingai grazinta knyga (ID: {id:000})\n");
                    knygos[GetIndexByID(id)].YraPaskolinta = false;
                }
            }
        }

        public void RodytiVisasKnygas()
        {
            Console.WriteLine("_____VISOS KNYGOS_____");
            foreach (Knyga knyga in knygos)
            {
                Console.WriteLine(knyga.ToString());
            }
                Console.WriteLine();
        }

        public void RodytiPaskolintasKnygas()
        {
            bool exists = false;
            Console.WriteLine("_____PASKOLINTOS KNYGOS_____");
            foreach (Knyga knyga in knygos)
            {
                if (knyga.YraPaskolinta)
                {
                    Console.WriteLine(knyga.ToString());
                    exists = true;
                }
            }
            if (!exists)
                Console.WriteLine("Paskolintu knygu nera");

            Console.WriteLine();
        }

        // Papildoma funkcija - parodyti nepaskolintas knygas
        public void RodytiNepaskolintasKnygas()
        {
            bool exists = false;
            Console.WriteLine("_____NEPASKOLINTOS KNYGOS_____");
            foreach (Knyga knyga in knygos)
            {
                if (!knyga.YraPaskolinta)
                {
                    Console.WriteLine(knyga.ToString());
                    exists = true;
                }
            }
            if (!exists)
                Console.WriteLine("Visos knygos paskolintos ir dar negrazintos!");

            Console.WriteLine();
        }

        // Papildoma funkcija - pasakyti, ar knygų sąraše yra knyga su konkrečiu ID
        public bool YraKnygosID(int id)
        {
            foreach (Knyga knyga in knygos)
            {
                if (knyga.Id == id)
                    return true;
            }
            return false;
        }

        // Papildoma funkcija - gauti knygų sąrašo indeksą pagal ID
        public int GetIndexByID(int id)
        {
            for (int i = 0; i < knygos.Count; i++)
            {
                if (knygos[i].Id == id)
                    return i;
            }
            Console.WriteLine("\nKlaida: nesutampa ID.\n");
            return -1;
        }

        // Papildoma funkcija - atsako, ar yra paskolintų knygų
        public bool ArYraPaskolintuKnygu()
        {
            for (int i = 0; i < knygos.Count; i++)
            {
                if (knygos[i].YraPaskolinta)
                    return true;
            }
            return false;
        }

        // Papildoma funkcija - atsako, ar yra nepaskolintų knygų
        public bool ArYraNepaskolintuKnygu()
        {
            for (int i = 0; i < knygos.Count; i++)
            {
                if (!knygos[i].YraPaskolinta)
                    return true;
            }
            return false;
        }
    }
}
