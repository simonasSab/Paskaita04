namespace Uzduotis02
{
    internal class Studentas
    {
        public string Vardas { get; set; }
        public int Amzius { get; set; }
        public double Balas { get; set; }

        public string ReturnAllAsString()
        {
            return $"{Vardas} {Amzius} {Balas}";
        }

        public Studentas(string vardas, int amzius, double balas)
        {
            Vardas = vardas;
            Amzius = amzius;
            Balas = balas;
        }
    }
}
