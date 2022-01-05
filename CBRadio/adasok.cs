using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBRadio
{
    internal class adas
    {
        public int Ora { get; set; }
        public int Perc { get; set; }
        public int AdasDb { get; set; }
        public string Nev { get; set; }

        public adas(string sor)
        {
            var s = sor.Split(";");
            Ora = int.Parse(s[0]);
            Perc = int.Parse(s[1]);
            AdasDb = int.Parse(s[2]);
            Nev = s[3];
        }
    }
}