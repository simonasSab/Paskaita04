namespace Uzduotis06
{
    // 2. Sukurkite klasę Uzsakymas su šiais laukais:
    //  * Id(int)
    //  * Klientas(string)
    //  * Patiekalai(List<Patiekalas>)
    internal class Uzsakymas
    {
        public int Id { get; set; }
        public string Klientas { get; set; }
        public List<Patiekalas> Patiekalai { get; set; }

        public Uzsakymas(int id, string klientas, List<Patiekalas> patiekalai)
        {
            Patiekalai = patiekalai;
            Id = id;
            Klientas = klientas;
        }

        public override string ToString()
        {
            return $"Uzsakymas - ID: {Id:000}, klientas: {Klientas})";
        }

        public int GautiPatiekaloIndexIsID(int id)
        {
            for (int i = 0; i < Patiekalai.Count; i++)
            {
                if (Patiekalai[i] != null && Patiekalai[i].Id == id)
                    return i;
            }
            Console.WriteLine("\nKlaida: nerastas patiekalo ID uzsakyme.\n");
            return -1;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;

            Uzsakymas uzsakymas = (Uzsakymas)obj;

            if (uzsakymas.Id == this.Id)
                return true;
            else
                return false;
        }

        // Papildoma funkcija - patikrinti, šiame užsakyme yra toks patiekalo ID
        public bool YraPatiekaloID(int id)
        {
            foreach (Patiekalas patiekalas in Patiekalai)
            {
                if (patiekalas.Id == id)
                    return true;
            }
            return false;
        }
    }
}
