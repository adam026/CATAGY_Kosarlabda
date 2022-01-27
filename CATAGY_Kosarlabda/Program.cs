using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CATAGY_Kosarlabda
{
    internal class Program
    {
        static List<Csapat> csapatok = new List<Csapat>();
        static void Main(string[] args)
        {
            Beolvas();
            F03();
            F04();
            F05();
            F06();
            F07();
        }

        private static void F07()
        {
            Console.WriteLine("7. Feladat: ");
            var stadionokSzerint = new Dictionary<string, int>();
            foreach (var csapat in csapatok)
            {
                if (!stadionokSzerint.ContainsKey(csapat.Helyszin))
                {
                    stadionokSzerint.Add(csapat.Helyszin, 1);
                }
                else
                {
                    stadionokSzerint[csapat.Helyszin] += 1;
                }
            }

            foreach (var stadion in stadionokSzerint)
            {
                if (stadion.Value > 20)
                {
                    Console.WriteLine($"\t{stadion.Key}: {stadion.Value}");
                }
            }
        }

        private static void F06()
        {
            DateTime datum = new DateTime(2004, 11, 21);
            Console.WriteLine("6. Feladat:");
            foreach (var csapat in csapatok)
            {
                if (csapat.Idopont == datum)
                {
                    Console.WriteLine($"\t{csapat.HazaiCsapat}-{csapat.IdegenCsapat} ({csapat.HazaiPont}:{csapat.IdegenPont})");
                }
            }
        }

        private static void F05()
        {
            var vajonMiLehet = csapatok.Where(x => x.HazaiCsapat.Contains("Barcelona")).First();
            Console.WriteLine($"5. Feladat: A barcelonai csapat neve: {vajonMiLehet.HazaiCsapat}");
        }

        private static void F04()
        {
            var dontetlen = csapatok.Where(x => x.HazaiPont == x.IdegenPont).Count();
            if (dontetlen != 0)
            {
                Console.WriteLine($"4. Feladat: Volt döntetlen? Igen! ");
            }
            else
            {
                Console.WriteLine($"4. Feladat: Volt döntetlen? Nem! ");
            }
        }

        private static void F03()
        {
            var hazai = csapatok.Where(x => x.HazaiCsapat == "Real Madrid").Count();
            var vendeg = csapatok.Where(x => x.IdegenCsapat == "Real Madrid").Count();
            Console.WriteLine($"3. Feladat: Real Madrid: Hazai: {hazai}, Idegen: {vendeg}");
        }

        private static void Beolvas()
        {
            using (var sr = new StreamReader(@"..\..\RES\eredmenyek.csv", Encoding.UTF8))
            {
                var fejlec = sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    csapatok.Add(new Csapat(sr.ReadLine()));
                }
            }
        }
    }
}
