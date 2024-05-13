using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt_Pujcovna_automobilu
{
    internal class Auto
    {
        public string Znacka { get; set; }
        public string VIN { get; set; }
        public string SPZ { get; set; }
        public string Vyrobce { get; set; }
        public string Model { get; set; }
       // public string Typ { get; set; }
        public int RokVyroby { get; set; }
        public double CenaZaDen { get; set; }
       // public bool Dostupnost { get; set; }
        public double StavTachometru { get; set; }
        public int PocetMist { get; set; }
        public Pujcka PujceneAuto { get; set; } // odkaz na aktualní půjčku
        public Zakaznik PujcujiciZakaznik { get; set; } // odkaz na zákazníka, který si auto půjčuje

        public Auto(string znacka, string vin, string spz, string vyrobce, string model, int rokVyroby, double cenaZaDen, double stavTachometru, int pocetMist) 
        {
            Znacka = znacka;
            VIN = vin;
            SPZ = spz;
            Vyrobce = vyrobce;
            Model = model;
            RokVyroby = rokVyroby;
            CenaZaDen = cenaZaDen;
            StavTachometru = stavTachometru;
            PocetMist = pocetMist;
        }

        public void VypisInfo() // vypisuje info a autě
        {
            Console.WriteLine($"Značka: {Znacka}\nVIN: {VIN}\nSPZ: {SPZ}\nVýrobce: {Vyrobce}\nModel: {Model}\nRok výroby: {RokVyroby}\nCena za den: {CenaZaDen}\nStav Tachometru: {StavTachometru}\nPočet míst: {PocetMist}");
        }
    }
}
