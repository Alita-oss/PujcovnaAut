using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace projekt_Pujcovna_automobilu
{
    internal class Pujcovna
    {
        public List<Auto> auta;
        public List<Auto> autaVenku;
        public List<Zakaznik> zakaznici;
        public List<Pujcka> pujcky;
        public Pujcovna()
        {
            auta = new List<Auto>();
            autaVenku = new List<Auto>();
            zakaznici = new List<Zakaznik>();
            pujcky = new List<Pujcka>();
        }

        public void PridatVozidlo() // přidávání nového vozidla
        {
            Console.WriteLine("Zadáváš nové vozidlo: ");

            Console.Write("Značka: ");
            string znacka = Console.ReadLine();

            Console.Write("VIN (17 místný kód): ");
            string vin = Console.ReadLine();

            Console.Write("SPZ (8 znaků): ");
            string spz = Console.ReadLine();

            Console.Write("Výrobce: ");
            string vyrobce = Console.ReadLine();

            Console.Write("Model: ");
            string model = Console.ReadLine();

            //Console.Write("Typ vozidla (A/B): ");
            //string typ = Console.ReadLine();

            Console.Write("Rok výroby: ");
            int rokVyroby = 0;
            while (!int.TryParse(Console.ReadLine(), out rokVyroby) || rokVyroby < 1995)
            {
                Console.WriteLine("Takovéto auta tady nemáme možnost půjčovat, zkus znova.");
            }

            Console.Write("Cena za den: ");
            double cenaZaDen = 0;
            while (!double.TryParse(Console.ReadLine(), out cenaZaDen) || cenaZaDen < 0)
            {
                Console.WriteLine("Špatně zadaná hodnota, zkus to znovu.");
            } 

            Console.Write("Stav tachometru: ");
            double stavTachometru = 0;
            while (!double.TryParse(Console.ReadLine(), out stavTachometru)|| stavTachometru < 0)
            {
                Console.WriteLine("Špatně zadaná hodnota, zkus to znovu.");
            }

            Console.Write("Počet míst ve vozidle: ");
            int pocetMist = 0;
            while (!int.TryParse(Console.ReadLine(), out pocetMist)|| pocetMist < 0 || pocetMist > 9)
            {
                Console.WriteLine("Takovéto auta tady nemáme možnost půjčovat, zkus znova.");
            }

            Console.WriteLine("Auto bylo přidáno");

            Auto auto = new Auto(znacka, vin, spz, vyrobce, model, rokVyroby, cenaZaDen, stavTachometru, pocetMist); //typ
            auta.Add(auto);
        }

        public void OdebratVozidlo() // odebírá pouze dostupná vozidla (když má někdo půjčené auto, tak ho nemůžeme odebrat)
        {
            if (auta.Count > 0)
            {
                Console.WriteLine("Seznam aut pro odebrání: ");
                for (int i = 0; i < auta.Count; i++)
                {
                    Console.WriteLine($" {i + 1} {auta[i].Znacka}, {auta[i].SPZ}");
                }
                Console.Write("Zadej číslo auta, které chceš odebrat: ");
                int indexSmazani = int.Parse(Console.ReadLine()) - 1;
                if (indexSmazani >= 0 && indexSmazani < auta.Count)
                {
                    Console.WriteLine($" Vozidlo {auta[indexSmazani].Znacka}, SPZ: {auta[indexSmazani].SPZ} bylo smazáno");
                    auta.RemoveAt(indexSmazani);
                }
                else
                {
                    Console.WriteLine("Špatné číslo, vozidlo nebylo smazáno");
                }
            } else
            {
                Console.WriteLine("Nejsou žádná dostupná vozidla, které lze odebrat");
            }
        }

        public void UpravitVozidlo() // upráva pouze dostpných vozidel (auto se jen tak nezmění, když ho má někdo půjčené)
        {
            if (auta.Count > 0)
            {
                Console.WriteLine("Vyberte auto, které chcete upravit: ");
                for (int i = 0; i < auta.Count; i++)
                {
                    Console.WriteLine($" {i + 1} {auta[i].Znacka}, {auta[i].SPZ}");
                }
                int indexEdit = int.Parse(Console.ReadLine()) - 1;
            
                if (indexEdit >= 0 && indexEdit < auta.Count)
                {
                    Console.WriteLine("Úprava vozidla");
                    Auto auto = auta[indexEdit];

                    Console.WriteLine("Aktualní značka: " + auto.Znacka + " Chceš upravit a/n?");
                    if (Console.ReadLine().ToLower() == "a")
                    {
                        Console.Write("Nová značka: ");
                        auto.Znacka = Console.ReadLine();
                    }
                    Console.WriteLine("Aktualní VIN: " + auto.VIN + " Chceš upravit a/n?");
                    if (Console.ReadLine().ToLower() == "a")
                    {
                        Console.Write("Nový VIN: ");
                        auto.VIN = Console.ReadLine();
                    }
                    Console.WriteLine("Aktualní SPZ: " + auto.SPZ + " Chceš upravit a/n?");
                    if (Console.ReadLine().ToLower() == "a")
                    {
                        Console.Write("Nová SPZ: ");
                        auto.SPZ = Console.ReadLine();
                    }
                    Console.WriteLine("Aktualní Výrobce: " + auto.Vyrobce + " Chceš upravit a/n?");
                    if (Console.ReadLine().ToLower() == "a")
                    {
                        Console.Write("Nový Výrobce: ");
                        auto.Vyrobce = Console.ReadLine();
                    }
                    Console.WriteLine("Aktualní Model: " + auto.Model + " Chceš upravit a/n?");
                    if (Console.ReadLine().ToLower() == "a")
                    {
                        Console.Write("Nový Model: ");
                        auto.Model = Console.ReadLine();
                    }
                    //Console.WriteLine("Typ vozidla nejde změnit");
                    //Console.ReadKey();
                    Console.WriteLine("Aktualní rok výroby: " + auto.RokVyroby + " Chceš upravit a/n?");
                    if (Console.ReadLine().ToLower() == "a")
                    {
                        Console.Write("Nový rok výroby: ");
                        auto.RokVyroby = int.Parse(Console.ReadLine());
                    }
                    Console.WriteLine("Aktualní cena za den: " + auto.CenaZaDen + " Chceš upravit a/n?");
                    if (Console.ReadLine().ToLower() == "a")
                    {
                        Console.Write("Nová  cena za den: ");
                        auto.CenaZaDen = double.Parse(Console.ReadLine());
                    }
                    Console.WriteLine("Aktualní stav tachometru: " + auto.StavTachometru + " Chceš upravit a/n?");
                    if (Console.ReadLine().ToLower() == "a")
                    {
                        Console.Write("Nový stav tachometru: ");
                        auto.StavTachometru = double.Parse(Console.ReadLine());
                    }
                    Console.WriteLine("Aktualní počet míst: " + auto.PocetMist + " Chceš upravit a/n?");
                    if (Console.ReadLine().ToLower() == "a")
                    {
                        Console.Write("Nový počet míst: ");
                        auto.PocetMist = int.Parse(Console.ReadLine());
                    }
                    Console.WriteLine("Úprava byla dokončena");
                } else
                {
                    Console.WriteLine("Špatně zadané číslo auta, auto nebylo upraveno");
                }
            } else
            {
                Console.WriteLine("Neexistuje žádné dostupné auto, které lze upravit");
            }
        }

        public void VypisAut() // vypis buď auta dostupná (ta která jdou půjčit) nebo autaVenku (ta co jsou zrovna nedostupná/půjčená) 
        {
            if (auta.Count > 0 || autaVenku.Count > 0) // podmínka, zda se vubec ptát, jestli chteme vypsat s/p když není ani jedno
            {
                Console.WriteLine("Chcete zobrazit dostupná auta nebo ta, co jsou již půjčená? d/p");
                string choice = Console.ReadLine();

                // vypsání aut dostupných (pokud jsou)
                if (choice.ToLower() == "d" && auta.Count <= 0)
                {
                    Console.WriteLine("Právě nejsou žádná dostupná auta");

                }
                else if (choice.ToLower() == "d" && auta.Count > 0)
                {
                    Console.WriteLine("Výpis dostupných aut:");
                    foreach (Auto auto in auta)
                    {
                        auto.VypisInfo();
                        Console.WriteLine();
                    }

                    // dodatečné ptaní, jestli chcou vypsat i půjčené (pokud jsou)
                    Console.WriteLine("Chcete ještě vypsat auta, která jsou zrovna půjčená? a/n");
                    string choice1 = Console.ReadLine();

                    if (choice1.ToLower() == "a" && autaVenku.Count <= 0)
                    {
                        Console.WriteLine("Právě nejsou žádná auta půjčená");

                    }
                    else if (choice1.ToLower() == "a" && autaVenku.Count > 0)
                    {
                        Console.WriteLine("Výpis půjčených aut:");
                        foreach (Auto auto in autaVenku)
                        {
                            auto.VypisInfo();
                            Console.WriteLine();
                        }
                    }
                }
                
                // výpis aut půjčených (pokud jsou) neboli to samé jak nahoře, akorát opačně 
                if (choice.ToLower() == "p" && autaVenku.Count <= 0)
                {
                    Console.WriteLine("Právě nejsou žádná auta půjčená");

                }
                else if (choice.ToLower() == "p" && autaVenku.Count > 0)
                {
                    Console.WriteLine("Výpis půjčených aut:");
                    foreach (Auto auto in autaVenku)
                    {
                        auto.VypisInfo();
                        Console.WriteLine();
                    }

                    // dodatečné ptaní jestli chcou vypsat i auta dostupná (pokud jsou)
                    Console.WriteLine("Chcete ještě vypsat auta, která jsou dostupná? a/n");
                    string choice2 = Console.ReadLine();
                    if (choice.ToLower() == "a" && auta.Count <= 0)
                    {
                        Console.WriteLine("Právě nejsou žádná dostupná auta");
                    }
                    else if (choice.ToLower() == "a" && auta.Count > 0)
                    {
                        Console.WriteLine("Výpis dostupných aut:");
                        foreach (Auto auto in auta)
                        {
                            auto.VypisInfo();
                            Console.WriteLine();
                        }
                    }
                }

                if (choice.ToLower() == "d" && auta.Count > 0 && choice.ToLower() == "p" && autaVenku.Count > 0) // kdyby se uživatel uklikl při volení
                {
                    Console.WriteLine("Špatně zadaná volba");
                }

            }
            else if (auta.Count <= 0 && autaVenku.Count <= 0) // pokud není ani jedno, zeptáme se, zda chtějí přidat vozidlo
            {
                Console.WriteLine("Ještě nebyla zadána žádná auta, tudíž nelze žádné vypsat");
                Console.WriteLine("Chtěli byste teď jedno přidat? a/n");
                string volbaPridatAuto = Console.ReadLine();
                if (volbaPridatAuto.ToLower() == "a")
                {
                    PridatVozidlo();
                }
                else // pokud ne => zpět do menu
                {
                    Console.WriteLine("Dobře, vrátíme Vás na hlavní menu");
                }
            }
        }

        public void PridatZakaznika() // přidává nového zákazníka
        {
            Console.WriteLine("Zadáváš nového zákazníka: ");

            Console.Write("Jméno: ");
            string jmeno = Console.ReadLine();

            Console.Write("Příjmení: ");
            string prijmeni = Console.ReadLine();

            Console.Write("Datum narození: ");
            DateTime datumNarozeni;
            while (!DateTime.TryParse(Console.ReadLine(), out datumNarozeni))
            {
                Console.WriteLine("Špatně zadaná hodnota, zkus to znovu.");
            }

            Console.Write("Telefonní číslo: ");
            int telefon = 0;
            while (!int.TryParse(Console.ReadLine(), out telefon))
            {
                Console.WriteLine("Špatně zadané hodnoty, zkus znova.");
            }

            Console.Write("Emailová adresa: ");
            string email = Console.ReadLine();

            Console.WriteLine("Zákazník byl zaregistrován");

            Zakaznik zakaznik = new Zakaznik(jmeno, prijmeni, datumNarozeni, telefon, email);
            zakaznici.Add(zakaznik);
        }

        public void UpravitZakaznika() // úprava zákazníků
        {
            if (zakaznici.Count > 0)
            {
                Console.WriteLine("Vyberte zákazníka, kterého chcete upravit: ");
                for (int i = 0; i < zakaznici.Count; i++)
                {
                    Console.WriteLine($" {i + 1}. {zakaznici[i].Jmeno} {zakaznici[i].Prijmeni}");
                }
                int indexEdit = int.Parse(Console.ReadLine()) - 1;

                if (indexEdit >= 0 && indexEdit < zakaznici.Count)
                {
                    Console.WriteLine("Úprava Zákazníka");
                    Zakaznik zakaznik = zakaznici[indexEdit];

                    Console.WriteLine("Aktualní jméno: " + zakaznik.Jmeno + " Chceš upravit a/n?");
                    if (Console.ReadLine().ToLower() == "a")
                    {
                        Console.Write("Nové jméno: ");
                        zakaznik.Jmeno = Console.ReadLine();
                    }
                    Console.WriteLine("Aktualní příjmení: " + zakaznik.Prijmeni + " Chceš upravit a/n?");
                    if (Console.ReadLine().ToLower() == "a")
                    {
                        Console.Write("Nové příjmení: ");
                        zakaznik.Prijmeni = Console.ReadLine();
                    }
                    Console.WriteLine("Datum narození nejde změnit, aby se vyhnulo obcházení systému, když je někdo nezletilý");
                    Console.ReadKey();
                    Console.WriteLine("Aktualní telefon: " + zakaznik.Telefon + " Chceš upravit a/n?");
                    if (Console.ReadLine().ToLower() == "a")
                    {
                        Console.Write("Nový telefon: ");
                        zakaznik.Telefon = int.Parse(Console.ReadLine());
                    }
                    Console.WriteLine("Aktualní email: " + zakaznik.Email + " Chceš upravit a/n?");
                    if (Console.ReadLine().ToLower() == "a")
                    {
                        Console.Write("Nový email: ");
                        zakaznik.Email = Console.ReadLine();
                    }

                    Console.WriteLine("Úprava byla dokončena");
                } else
                {
                    Console.WriteLine("Špatně zadané číslo zákazníka, zákazník nebyl upraven");
                }
            } else
            {
                Console.WriteLine("Neexistuje zatím žádný zákazník, kterého lze upravit");
            }
        }

        public void VypisZakazniku() // výpis zákazníků
        {
            if (zakaznici.Count > 0)
            {
                Console.WriteLine("Výpis zákazníků: ");
                foreach (Zakaznik zakaznik in zakaznici)
                {
                    zakaznik.VypisInfoZ();
                    Console.WriteLine();
                }
            } else
            {
                Console.WriteLine("Zatím nejsou zaregistrovaní žádní zákazníci");
            }

        }

        public bool OvereniVeku(Zakaznik pujcujiciZakaznik) // ověřování zda dotyčný zákazník může řídit 
        {
            DateTime datumNarozeni = pujcujiciZakaznik.DatumNarozeni;
            DateTime dnes = DateTime.Today; // získání aktuálního data
            int vek = dnes.Year - datumNarozeni.Year; // výpočet rozdílu let mezi aktuálním datem a datem narození

            if (dnes.Month < datumNarozeni.Month || (dnes.Month == datumNarozeni.Month && dnes.Day < datumNarozeni.Day)) // kontrola, zda již osoba měla narozeniny v aktuálním roce
            {
                vek--; // pokud ne => odečíst jeden rok od věku
            }

            if (vek < 18)
            {
                Console.WriteLine("Je nám líto, ale váš věk neodpovídá požadavkům legálně řídit auto, tudíž vám ho nemůžeme půjčit");
                return false;
            }
            else
            {
                Console.WriteLine("Auto lze půjčit, váš věk odpovídá požadavkům");
                return true;
            }
        }

        public void PujcitVozidlo(DateTime denPujceni, DateTime denVraceni) // půjčování vozidla
        {
            if (auta.Count > 0 && zakaznici.Count > 0)
            {
                // výpis zákazníků, kteří si mohou půjčovat
                Console.WriteLine("Vyberte zákazníka, který si bude půjčovat vozidlo:");
                for (int i = 0; i < zakaznici.Count; i++)
                {
                    Console.WriteLine($" {i + 1}. {zakaznici[i].Jmeno} {zakaznici[i].Prijmeni}");
                }

                // výběr zákazníka, který si bude půjčovat
                Console.Write("Volba zákazníka: ");
                int indexZakaznika = int.Parse(Console.ReadLine()) - 1;
                if (indexZakaznika >= 0 && indexZakaznika < zakaznici.Count)
                {
                    // ukládání půjčujícího si zákazníka 
                    Zakaznik pujcujiciZakaznik = zakaznici[indexZakaznika];

                    // Ověření věku zákazníka
                    if (!OvereniVeku(pujcujiciZakaznik))
                    {
                        return;
                    }
                    Console.WriteLine();

                    // výpis dostupných aut aby si z nich zákazník mohl vybrat
                    Console.WriteLine("Vyberte vozidlo, které si chcete půjčit: ");
                    for (int i = 0; i < auta.Count; i++)
                    {
                        Console.WriteLine($" {i + 1} {auta[i].Znacka}, {auta[i].SPZ}");

                    }

                    // vybraný zákazník si vybírá vozidlo, které si vypůjčí
                    Console.Write("Volba auta: ");
                    int indexVozidla = int.Parse(Console.ReadLine()) - 1;
                    if (indexVozidla >= 0 && indexVozidla < auta.Count)
                    {
                        // ukládání půjčeného auta
                        Auto pujceneAuto = auta[indexVozidla];

                        // vytvoření instance nové půjčky
                        Pujcka novaPujcka = new Pujcka(denPujceni, denVraceni, pujceneAuto, pujcujiciZakaznik);

                        // nastavení instance půjčky v autě
                        pujceneAuto.PujceneAuto = novaPujcka;

                        // přidání půjčky k zákazníkovi
                        pujcujiciZakaznik.Pujcky.Add(novaPujcka);

                        Console.WriteLine($"Zákazník {pujcujiciZakaznik.Jmeno} {pujcujiciZakaznik.Prijmeni} si vybral auto: {auta[indexVozidla].Znacka}, {auta[indexVozidla].SPZ}");
                        Console.WriteLine("Půjčení vozidla bylo dokončeno");

                        // přesunutí auta z auta na autaVenku (list auta - dostupné, list autaVenku - nedostupné, neboli právě půjčené)
                        autaVenku.Add(auta[indexVozidla]);
                        auta.RemoveAt(indexVozidla);
                    }
                    else
                    {
                        Console.WriteLine("Neplatná volba vozidla.");
                    }
                }
                else
                {
                    Console.WriteLine("Neplatná volba zákazníka.");
                }

            } else if (auta.Count <= 0) // pro případ, že někdo zvolí funkci půjčit vozidlo, když ještě žádné neexistuje
            {
                Console.WriteLine("Je možné, že ještě není přidané žádné auto");
                Console.WriteLine("Chcete ho přidat? a/n");
                string volbaPridatAuto = Console.ReadLine();

                if (volbaPridatAuto.ToLower() == "a")
                {
                    PridatVozidlo();
                    PujcitVozidlo(denPujceni, denVraceni);
                }
            } else if (zakaznici.Count <= 0) // pro případ, že někdo zvolí funkci půjčit vozidlo, když ani neexistuje zákazník, který by si ho mohl půjčit
            {
                Console.WriteLine("Je možné, že ještě není zaregistrován žádný zákazník");
                Console.WriteLine("Chcete ho/ji přidat? a/n");
                string volbaPridatZakaznika = Console.ReadLine();
                if (volbaPridatZakaznika.ToLower() == "a")
                {
                    PridatZakaznika();
                    PujcitVozidlo(denPujceni, denVraceni);
                } 
            }
        }

        public (DateTime, DateTime) VypocetDnuPujcky() // metoda slouží k výpočtu počtu dní zapůjčení // způsob, jak vrátit více hodnot z metody
        {
            Console.Write("Den zapůjčení vozidla: ");
            DateTime denPujceni;
            while (!DateTime.TryParse(Console.ReadLine(), out denPujceni))
            {
                Console.WriteLine("Špatně zadaná hodnota, zkus to znovu.");
            }

            Console.Write("Den vrácení vozidla: ");
            DateTime denVraceni;
            while (!DateTime.TryParse(Console.ReadLine(), out denVraceni))
            {
                Console.WriteLine("Špatně zadaná hodnota, zkus to znovu.");
            }

            TimeSpan pujceneDny = denVraceni - denPujceni;
            int pujceneDnyFormat = (int)pujceneDny.TotalDays;

            Console.WriteLine($"Počet dní zapůjčení: {pujceneDnyFormat}");
            VypocetCeny(pujceneDnyFormat);
            Console.WriteLine();

            return (denPujceni, denVraceni);
        }
        public void VypocetCeny(int pujceneDnyFormat) // spočítá cenu za všechny půjčené dny (podle toho kolik má cenu auto za den)
        {
            // pro každé půjčené auto spočítáme cenu a vypišeme ji
            foreach (var auto in auta)
            {
                // cena za den
                double cenaZaDen = auto.CenaZaDen;

                // celková cena půjčení
                double celkovaCena = pujceneDnyFormat * cenaZaDen;

                Console.WriteLine($"Cena za půjčení vozidla {auto.Znacka}: {celkovaCena} Kč");
            }
        }

        public void VratitVozidlo() // vracení vozidla
        {
            if (autaVenku.Count > 0)
            {
                // výběr zákazníka, který vrací auto
                Console.WriteLine("Vyberte zákazníka, který vrací auto: ");
                for (int i = 0; i < zakaznici.Count; i++)
                {
                    Console.WriteLine($" {i + 1}. {zakaznici[i].Jmeno} {zakaznici[i].Prijmeni}");
                }
                Console.Write("Volba zákazníka: ");
                int indexZakaznika = int.Parse(Console.ReadLine()) - 1;

                if (indexZakaznika >= 0 && indexZakaznika < zakaznici.Count)
                {
                    Zakaznik vracejiciZakaznik = zakaznici[indexZakaznika]; // získání zákazníka, který vrací auto
                    List<Auto> pujceneAuta = vracejiciZakaznik.Pujcky.Select(p => p.PujceneAuto).ToList(); // vytváří seznam aut, které jsou aktuálně půjčené daným zákazníkem

                    // vypsání seznamu aut, které má zákazník půjčené
                    if (pujceneAuta.Count > 0)
                    {
                        Console.WriteLine($"Zákazník {vracejiciZakaznik.Jmeno} {vracejiciZakaznik.Prijmeni} má půjčené následující vozy:");
                        for (int i = 0; i < pujceneAuta.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {pujceneAuta[i].Znacka}, {pujceneAuta[i].SPZ}");
                        }

                        Console.WriteLine("Vyberte vozidlo, které vracíte: ");
                        int indexVratit = int.Parse(Console.ReadLine()) - 1;
                        if (indexVratit >= 0 && indexVratit < pujceneAuta.Count)
                        {
                            Auto autoVenku = pujceneAuta[indexVratit]; // získání půjčeného auta, které je vybráno k vrácení
                            Console.WriteLine($"Vybraly jste vozidlo: {autaVenku[indexVratit].Znacka}, {autaVenku[indexVratit].SPZ} ");

                            Console.WriteLine("Zadejte prosím novou hodnotu tachometru před vrácením: ");
                            Console.WriteLine("Aktualní stav tachometru: " + autoVenku.StavTachometru); // nový stav tachometru
                            Console.Write("Nový stav tachometru: ");
                            autoVenku.StavTachometru = double.Parse(Console.ReadLine());

                            Console.WriteLine("Vrácení bylo dokončeno");

                            auta.Add(autoVenku); // přehození aut zpátky do "dostupných" aut (auta)
                            autaVenku.RemoveAt(indexVratit);
                        } 
                        else
                        {
                            Console.WriteLine("Neplatná volba vozidla");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Tento zákazník nemá žádné půjčené vozy k vrácení.");
                    }
                } else
                {
                    Console.WriteLine("Neplatná volba zákazníka");
                } 
            }
            else
            {
                Console.WriteLine("Zatím nebylo žádné auto půjčeno");
            }
        }

        public void ZaznamyPujcekZakazniku() // vypisuje záznamy půjček jednotlivých zákazníků
        {
            if (zakaznici.Count > 0)
            {
                Console.WriteLine("Vyberte zákazníka, u kterého chcet vypsat záznam půjček: ");
                for (int i = 0; i < zakaznici.Count; i++)
                {
                    Console.WriteLine($" {i + 1}. {zakaznici[i].Jmeno} {zakaznici[i].Prijmeni}");
                }
                int indexZakaznika = int.Parse(Console.ReadLine()) - 1;

                if (indexZakaznika >= 0 && indexZakaznika < zakaznici.Count)
                {
                    // získání seznamu půjček daného zákazníka
                    List<Pujcka> pujckyZakaznika = zakaznici[indexZakaznika].Pujcky;

                    //výpis
                    Console.WriteLine($"Záznámy půjček zákazníka {zakaznici[indexZakaznika].Jmeno} {zakaznici[indexZakaznika].Prijmeni}: ");
                    if (pujckyZakaznika.Count > 0)
                    {
                        foreach (Pujcka pujcka in pujckyZakaznika)
                        {
                            Console.WriteLine($"- půjčeno vozidlo: {pujcka.PujceneAuto.Znacka}\n\tDatum půjčení: {pujcka.DenPujceni}\n\tDatum vrácení: {pujcka.DenVraceni}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Tento zákazník nemá žádné záznamy půjček.");
                    }
                }
                else
                {
                    Console.WriteLine("Špatně zadané číslo zákazníka");
                }
            } 
            else
            {
                Console.WriteLine("Ještě neexistují žádní zákazníci");
            }

        }

        public void UlozitDoSouboruAuto(string filePath) // ukladání do souboru Auta
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (Auto auto in auta)
                {
                    writer.WriteLine($"{auto.Znacka}, {auto.VIN}, {auto.SPZ}, {auto.Vyrobce}, {auto.Model}, {auto.RokVyroby}, {auto.CenaZaDen}, {auto.StavTachometru}, {auto.PocetMist}");
                }
            }
            Console.WriteLine("Data byla úspěšně uložena do souboru.");
        }

        public void NacistZeSouboruAuto(string filePath) // načítání ze souboru Auta
        {
            if (File.Exists(filePath))
            {
                auta.Clear();
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 9)
                        {
                            string znacka = parts[0];
                            string vin = parts[1];
                            string spz = parts[2];
                            string vyrobce = parts[3];
                            string model = parts[4];
                            int rokVyroby = int.Parse(parts[5]);
                            double cenaZaDen = double.Parse(parts[6]);
                            double stavTachometru = double.Parse(parts[7]);
                            int pocetMist = int.Parse(parts[8]);

                            Auto auto = new Auto(znacka, vin, spz, vyrobce, model, rokVyroby, cenaZaDen, stavTachometru, pocetMist);
                            auta.Add(auto);
                        }
                    }
                }
                Console.WriteLine("Data byla úspěšně načtena ze souboru.");
            }
            else
            {
                Console.WriteLine("Soubor neexistuje.");
            }
        }

        public void UlozitDoSouboruZ(string filePath) // ukládání do souboru Zakazníci
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (Zakaznik zakaznik in zakaznici)
                {
                    writer.WriteLine($"{zakaznik.Jmeno}, {zakaznik.Prijmeni}, {zakaznik.DatumNarozeni}, {zakaznik.Telefon}, {zakaznik.Email}");
                }
            }
            Console.WriteLine("Data byla úspěšně uložena do souboru.");
        }

        public void NacistZeSouboruZ(string filePath) // načítání ze souboru Zákazníci
        {
            if (File.Exists(filePath))
            {
                zakaznici.Clear();
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 5)
                        {
                            string jmeno = parts[0];
                            string prijmeni = parts[1];
                            DateTime datumNarozeni;
                            if (DateTime.TryParse(parts[2], out datumNarozeni))
                            {
                                int telefon = int.Parse(parts[3]);
                                string email = parts[4];

                                Zakaznik zakaznik = new Zakaznik(jmeno, prijmeni, datumNarozeni, telefon, email);
                                zakaznici.Add(zakaznik);
                            }
                            else
                            {
                                Console.WriteLine($"Chyba při načítání řádku: {line}. Neplatné datum narození.");
                            }
                        }
                    }
                }
                Console.WriteLine("Data byla úspěšně načtena ze souboru.");
            }
            else
            {
                Console.WriteLine("Soubor neexistuje.");
            }
        }

        /*
        public void UlozitDoSouboruPujcky(string filePath) // ukladání do souboru Půjčky
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (Pujcka pujcka in pujcky)
                {
                    writer.WriteLine($"{pujcka.DenPujceni}, {pujcka.DenVraceni}, {pujcka.PujceneAuto}, {pujcka.PujcujiciZakaznik}");
                }
            }
            Console.WriteLine("Data byla úspěšně uložena do souboru.");
        }

        public void NacistZeSouboruPujcky(string filePath) // načítání ze souboru Půjčky
        {
            if (File.Exists(filePath))
            {
                pujcky.Clear();
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 4)
                        {
                            DateTime denPujceni;
                            DateTime denVraceni;

                            Pujcka pujcka = new Pujcka(denPujceni, denVraceni, pujceneAuto, pujcujiciZakaznik);
                            pujcky.Add(pujcka);
                        }
                    }
                }
                Console.WriteLine("Data byla úspěšně načtena ze souboru.");
            }
            else
            {
                Console.WriteLine("Soubor neexistuje.");
            }
        }
        */
    }
}