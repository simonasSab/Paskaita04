namespace Uzduotis05
{
    internal class Knyga
    {
        // Bibliotekos Valdymo Sistema.
        // Sukurkite bibliotekos valdymo sistemą, kuri leis sekti knygas ir jų paskolą.

        // 1. Sukurkite klasę Knyga su šiais laukais:
        //  * Id(int)
        //  * Pavadinimas(string)
        //  * Autorius(string)
        //  * YraPaskolinta(bool)

        public int Id { get; set; }
        public string Pavadinimas { get; set; }
        public string Autorius { get; set; }
        public bool YraPaskolinta { get; set; }

        public Knyga(int id, string pavadinimas, string autorius)
        {
            Id = id;
            Pavadinimas = pavadinimas;
            Autorius = autorius;
            YraPaskolinta = false;
        }

        public override string ToString()
        {
            if (YraPaskolinta)
                return $"ID: {Id:000}, {Pavadinimas}, {Autorius} (Paskolinta)";
            else
                return $"ID: {Id:000}, {Pavadinimas}, {Autorius} (Nepaskolinta)";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;

            Knyga knyga = (Knyga)obj;

            if (knyga.Id == this.Id)
                return true;
            else
                return false;
        }
    }
}
