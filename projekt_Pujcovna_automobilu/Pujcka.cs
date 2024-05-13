using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt_Pujcovna_automobilu
{
    internal class Pujcka
    {
        public DateTime DenPujceni { get; set; }
        public DateTime DenVraceni { get; set; }
        public Auto PujceneAuto { get; set; } // odkaz na půjčené auto
        public Zakaznik PujcujiciZakaznik { get; set; } // odkaz na třídu Zakaznik

        public Pujcka(DateTime denPujceni, DateTime denVraceni, Auto pujceneAuto, Zakaznik pujcujiciZakaznik) 
        {
            DenPujceni = denPujceni;
            DenVraceni = denVraceni;
            PujceneAuto = pujceneAuto;
            PujcujiciZakaznik = pujcujiciZakaznik;
        }
    }
}
 