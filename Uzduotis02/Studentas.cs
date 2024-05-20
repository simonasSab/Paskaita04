using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uzduotis02
{
    public class Studentas
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
