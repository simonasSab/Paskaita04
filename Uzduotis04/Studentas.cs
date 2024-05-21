namespace Uzduotis04
{
    internal class Studentas
    {
        public string Vardas { get; set; }
        public string Pavarde { get; set; }
        public int Amzius { get; set; }
        public int[] Balai { get; set; }
        public double Vidurkis { get; set; }

        public override string ToString()
        {
            double vidurkis = VidurkioSkaiciavimas(Balai);
            return $"{Vardas} {Pavarde} ({Amzius} m.), Vidurkis {vidurkis:.00}";
        }

        public Studentas(string vardas, string pavarde, int amzius, int[] balai)
        {
            Vardas = vardas;
            Pavarde = pavarde;
            Amzius = amzius;
            Balai = balai;
        }

        public double VidurkioSkaiciavimas(int[] ints)
        {
            Vidurkis = (double)(ints.Sum()) / (double)ints.Length;
            return Vidurkis;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;

            Studentas studentas = (Studentas)obj;

            if (studentas.Vardas == this.Vardas && studentas.Pavarde == this.Pavarde && studentas.Amzius == this.Amzius)
                return true;
            else
                return false;
        }
    }
}
