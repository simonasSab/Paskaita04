namespace Uzduotis06
{
    // 1. Sukurkite klasę Patiekalas su šiais laukais:
    // * Id(int)
    // * Pavadinimas(string)
    // * Kaina(double)
    // * Busena(string) – gali būti "laukiama", "ruosiama", "paruosta"
    internal class Patiekalas
    {
        public int Id { set; get; }
        public string Pavadinimas { set; get; }
        public double Kaina { set; get; }
        public string Busena { set; get; }

        public Patiekalas(int id, string pavadinimas, double kaina)
        {
            Id = id;
            Pavadinimas = pavadinimas;
            Kaina = kaina;
            Busena = "Meniu";
        }

        public Patiekalas(int id, string pavadinimas, double kaina, string busena)
        {
            Id = id;
            Pavadinimas = pavadinimas;
            Kaina = kaina;
            Busena = busena;
        }

        public override string ToString()
        {
            return $"ID: {Id:000}, {Pavadinimas}, {Kaina:.00} Eur ({Busena})";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;

            Patiekalas patiekalas = (Patiekalas)obj;

            if (patiekalas.Id == this.Id)
                return true;
            else
                return false;
        }
    }
}
