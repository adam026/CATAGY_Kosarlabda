using System;

namespace CATAGY_Kosarlabda
{
    class Csapat
    {
        public string HazaiCsapat { get; set; }
        public string IdegenCsapat { get; set; }
        public int HazaiPont { get; set; }
        public int IdegenPont { get; set; }
        public string Helyszin { get; set; }
        public DateTime Idopont { get; set; }

        public Csapat(string sor)
        {
            var buff = sor.Split(';');
            HazaiCsapat = buff[0];
            IdegenCsapat = buff[1];
            HazaiPont = int.Parse(buff[2]);
            IdegenPont = int.Parse(buff[3]);
            Helyszin = buff[4];
            var datum = buff[5].Split('-');
            Idopont = new DateTime(
                year: int.Parse(datum[0]),
                month: int.Parse(datum[1]),
                day: int.Parse(datum[2])); 
        }
    }
}
