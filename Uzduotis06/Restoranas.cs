namespace Uzduotis06
{
    // 3. Sukurkite klasę Restoranas, kuri turės metodus:
    //  * PridetiPatiekalaIPatiekaluSarasa(Patiekalas patiekalas): Prideda patiekalą į restorano meniu.
    //    Pervadinu į PridetiPatiekalaIMeniu(Patiekalas patiekalas)
    //  * RodytiVisusPatiekalus(): Išspausdina visų patiekalų sąrašą.
    //  * PridetiUzsakyma(Uzsakymas uzsakymas): Prideda naują užsakymą.
    //  * KeistiPatiekaloBusena(int uzsakymoId, int patiekaloId, string naujaBusena): Keičia patiekalo būseną užsakyme.
    //  * RodytiVisusUzsakymus(): Išspausdina visų užsakymų sąrašą.
    //  * RodytiUzsakyma(int uzsakymoId): Išspausdina konkretaus užsakymo informaciją.
    internal class Restoranas
    {
        public List<Patiekalas> Meniu { get; set; }
        public List<Uzsakymas> Uzsakymai { get; set; }

        public Restoranas()
        {
            Meniu = new();
            Uzsakymai = new();
        }

        public void PridetiPatiekalaIMeniu(Patiekalas? patiekalas)
        {
            if (patiekalas != null)
            {
                Meniu.Add(patiekalas);
                Console.WriteLine($"Sekmingai pridetas patiekalas {patiekalas.ToString()}\n");
            }
        }

        public void RodytiVisusPatiekalus()
        {
            foreach (Patiekalas patiekalas in Meniu)
            {
                Console.WriteLine(patiekalas.ToString());
            }
            Console.WriteLine();
        }

        public void PridetiUzsakyma(Uzsakymas? uzsakymas)
        {
            if (uzsakymas != null)
            {
                Uzsakymai.Add(uzsakymas);
                Console.WriteLine($"Sekmingai pridetas uzsakymas {uzsakymas.ToString()}\n");
            }
        }

        public void KeistiPatiekaloBusena(int uzsakymoId, int patiekaloId, string naujaBusena)
        {
            if (patiekaloId != -1 && naujaBusena != "-1")
                Uzsakymai[GautiPatiekaloIndexIsID(uzsakymoId)].Patiekalai[GautiPatiekaloIndexIsID(patiekaloId)].Busena = naujaBusena;
        }

        public void RodytiVisusUzsakymus()
        {
            foreach (Uzsakymas uzsakymas in Uzsakymai)
            {
                Console.WriteLine(uzsakymas.ToString());
            }
            Console.WriteLine();
        }

        public void RodytiUzsakyma(int uzsakymoId)
        {
            int index = GautiPatiekaloIndexIsID(uzsakymoId);
            Console.WriteLine($"{Uzsakymai[index].ToString()}\nPatiekalai:\n");
            foreach (Patiekalas patiekalas in Uzsakymai[index].Patiekalai)
            {
                Console.WriteLine(patiekalas.ToString());
            }
            Console.WriteLine();
        }

        // Papildoma funkcija
        public int GautiPatiekaloIndexIsID(int id)
        {
            for (int i = 0; i < Meniu.Count; i++)
            {
                if (Meniu[i] != null && Meniu[i].Id == id)
                    return i;
            }
            Console.WriteLine("\nKlaida: nerastas patiekalo ID Meniu sarase.\n");
            return -1;
        }

        // Papildoma funkcija
        public int GautiUzsakymoIndexIsID(int id)
        {
            for (int i = 0; i < Uzsakymai.Count; i++)
            {
                if (Uzsakymai[i] != null && Uzsakymai[i].Id == id)
                    return i;
            }
            Console.WriteLine("\nKlaida: nerastas uzsakymo ID uzsakymu sarase.\n");
            return -1;
        }

        // Papildoma funkcija - naikinti užsakymą is užsakymų sąrašo
        public void NaikintiUzsakymaIsUzsakymu(int id)
        {
            Uzsakymai.RemoveAt(GautiUzsakymoIndexIsID(id));
            Console.WriteLine($"Sekmingai panaikintas uzsakymas (ID: {id:000})\n");
        }

        // Papildoma funkcija - naikinti patiekalą iš užsakymo
        public void NaikintiPatiekalaIsUzsakymo(int uzsakymoId, int patiekaloId)
        {
            int uzsakymoIndex = GautiUzsakymoIndexIsID(uzsakymoId);
            int patiekaloIndex = Uzsakymai[uzsakymoIndex].GautiPatiekaloIndexIsID(patiekaloId);

            if (patiekaloId != -1)
            {
                Uzsakymai[uzsakymoIndex].Patiekalai.RemoveAt(patiekaloIndex);
                Console.WriteLine($"Sekmingai panaikintas uzsakymo (ID: {uzsakymoId:000}) patiekalas (ID: {patiekaloId:000})\n");
            }
        }

        // Papildoma funkcija - naikinti patiekalą iš meniu
        public void NaikintiPatiekalaIsMeniu(int id)
        {
            if (id != -1)
            {
                Meniu.RemoveAt(GautiPatiekaloIndexIsID(id));
                Console.WriteLine($"Sekmingai is Meniu panaikintas patiekalas (ID: {id:000})\n");
            }
        }

        // Papildoma funkcija - patikrinti, ar šiame Meniu yra toks patiekalo ID
        public bool YraPatiekaloID(int id)
        {
            foreach (Patiekalas patiekalas in Meniu)
            {
                if (patiekalas.Id == id)
                    return true;
            }
            return false;
        }

        // Papildoma funkcija - patikrinti, ar tarp užsakymų yra toks užsakymo ID
        public bool YraUzsakymoID(int id)
        {
            foreach (Uzsakymas uzsakymas in Uzsakymai)
            {
                if (uzsakymas.Id == id)
                    return true;
            }
            return false;
        }
    }
}
