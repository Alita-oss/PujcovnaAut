using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace projekt_Pujcovna_automobilu
{
    internal class Zakaznik
    {
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public DateTime DatumNarozeni { get; set; }
        public int Telefon { get; set; }
        public string Email { get; set; }
        public List<Pujcka> Pujcky { get; set; } // seznam půjček zákazníka

        public Zakaznik(string jmeno, string prijmeni, DateTime datumNarozeni, int telefon, string email)
        {
            Jmeno = jmeno;
            Prijmeni = prijmeni;
            DatumNarozeni = datumNarozeni;
            Telefon = telefon;
            Email = email;
            Pujcky = new List<Pujcka>();
        }

        public void VypisInfoZ() // vypisuje info o zákazníkovi
        {
            Console.WriteLine($"Jméno: {Jmeno}\nPříjmení: {Prijmeni}\nDatum narození: {DatumNarozeni}\nTelefon: {Telefon}\nEmail: {Email}");
        }
    }
}
