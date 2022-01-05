
namespace CBRadio
{

    internal class Program
    {
        static List<adas> Adasok = new List<adas>();
        static Dictionary<string,int> Becenevek = new Dictionary<string,int>();

        static void Main()
        {
            Feladta02();
            Feladat03();
            Feladat04();
            Feladat05();
            Feladat06();
            Feladat07();
            Feladat08();
            Feladat09();
        }

        private static void Feladat07()
        {
            using (StreamWriter sw = new StreamWriter("cb2.txt"))
            {
                sw.WriteLine("Kezdes;Nev;AdasDb");
                foreach (adas item in Adasok)
                {
                    sw.WriteLine( $"{AtszamolPercre(item.Ora,item.Perc)};{item.Nev};{item.AdasDb}");    
                }
            }
        }

        private static void Feladat08()
        {
            foreach (adas ad in Adasok)
            {
                if (Becenevek.ContainsKey(ad.Nev))
                {
                    Becenevek[ad.Nev]++;
                }
                else
                {
                    Becenevek.Add(ad.Nev, 1);
                }
            }
            Console.WriteLine($"8. feladat : Soforok szama: {Becenevek.Count} fo");
        }
        


        private static void Feladat09()
        {

            foreach (var bn in Becenevek)
            {
                Becenevek[bn.Key] = 0;

            }

            foreach (adas ad in Adasok)
            {
                Becenevek[ad.Nev] += ad.AdasDb;
            }

            var ordered = Becenevek.OrderBy(x => x.Value);
            Console.WriteLine("9.feladat : A legtobb adast indito sofor:");
            Console.WriteLine($"Nev: {ordered.Last().Key}");
            Console.WriteLine($"Adasok szama: {ordered.Last().Value} alkalom");

          

           

        }

        private static void Feladat06()
        {
         //   Console.Write(AtszamolPercre(8, 5));
        }


        private static void Feladat05()
        {
            Console.Write("5. feladat : Kerek egy nevet: ");
            string nev = Console.ReadLine();
            int hasznalatokSzama = 0;
            foreach (adas ad in Adasok)
            {
                if (ad.Nev==nev) hasznalatokSzama+= ad.AdasDb;
            }
            if (hasznalatokSzama == 0) Console.WriteLine("Nincs ilyen nevu sofor");
            else Console.WriteLine($"{nev} {hasznalatokSzama}x hasznalta a cb radiot");
            
        }

        private static void Feladat04()
        {
            int i = 0;
            bool negyetinditott= false;
            while (i < Adasok.Count | negyetinditott==false)
            {
                if (Adasok[i].AdasDb == 4) negyetinditott = true;
                i++;
            }
            if (negyetinditott) Console.WriteLine("4. feladat : volt 4 adast indito sofor");
            else Console.WriteLine("4. feladat : nem volt 4 adast indito sofor");
        }

        private static void Feladat03()
        {
            Console.WriteLine($"3. feladat : Bejegyzesek szama: {Adasok.Count} db.");
        }

        private static void Feladta02()
        {
            using (var sr = new StreamReader("cb.txt"))
            {
                var elsosor = sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    Adasok.Add(new adas(sr.ReadLine()));
                }
            }
        }
        private static int AtszamolPercre(int o, int p)
        {

            return ((o * 60) + p);
        }

    }
}
