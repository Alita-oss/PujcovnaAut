namespace projekt_Pujcovna_automobilu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pujcovna pujcovna = new Pujcovna();
            int volbaMenu = 0;
            string filePath;
            while (volbaMenu != 15)
            {
                Console.WriteLine("HLAVNÍ MENU: ");
                Console.WriteLine("1. Přidat nové vozidlo");
                Console.WriteLine("2. Odebrat vozidlo");
                Console.WriteLine("3. Upravit vozidlo");
                Console.WriteLine("4. Vypsat auta a jejich stav");
                Console.WriteLine("5. Registrace nového zákazníka");
                Console.WriteLine("6. Upravit zákazníka");
                Console.WriteLine("7. Vypsat evidenci zákazníků");
                Console.WriteLine("8. Vypsat historii půjček zákazníků"); 
                Console.WriteLine("9. Půjčit vozidlo");
                Console.WriteLine("10. Vrátit vozidlo");
                Console.WriteLine("11. Uložit vozidla do souboru"); 
                Console.WriteLine("12. Načíst vozidla ze souboru"); 
                Console.WriteLine("13. Uložit zákazníky do souboru");
                Console.WriteLine("14. Načíst zákazníky ze souboru");
                Console.WriteLine("15. Ukončit program");
                Console.Write("Volba: ");
           
                while (!int.TryParse(Console.ReadLine(), out volbaMenu) || volbaMenu < 1 || volbaMenu > 15)
                {
                    Console.WriteLine("Špatně zadaná hodnota, zkus to znovu.");
                }

                switch (volbaMenu)
                {
                    case 1:
                        pujcovna.PridatVozidlo();
                        Console.ReadKey();
                        break;
                    case 2:
                        pujcovna.OdebratVozidlo();
                        Console.ReadKey();
                        break;
                    case 3:
                        pujcovna.UpravitVozidlo();
                        Console.ReadKey();
                        break;
                    case 4:
                        pujcovna.VypisAut();
                        Console.ReadKey();
                        break;
                    case 5:
                        pujcovna.PridatZakaznika();
                        Console.ReadKey();
                        break;
                    case 6:
                        pujcovna.UpravitZakaznika();
                        Console.ReadKey();
                        break;
                    case 7:
                        pujcovna.VypisZakazniku();
                        Console.ReadKey();
                        break;
                    case 8:
                        pujcovna.ZaznamyPujcekZakazniku();
                        Console.ReadKey();
                        break;
                    case 9:
                        //pujcovna.PujcitVozidlo();
                        Console.WriteLine("Nejprve budete zadávat data půjčení a vrácení: ");
                        (DateTime denPujceni, DateTime denVraceni) = pujcovna.VypocetDnuPujcky(); // získání dat od uživatele
                        pujcovna.PujcitVozidlo(denPujceni, denVraceni); // předání dat do metody PujcitVozidlo()
                        Console.ReadKey();
                        break;
                    case 10:
                        pujcovna.VratitVozidlo();
                        Console.ReadKey();
                        break;
                    case 11:
                        Console.WriteLine("Zadejte cestu k souboru pro uložení vozidel:");
                        filePath = Console.ReadLine();
                        pujcovna.UlozitDoSouboruAuto(filePath);
                        Console.ReadKey();
                        break;
                    case 12:
                        Console.WriteLine("Zadejte cestu k souboru pro načtení vozidel:");
                        filePath = Console.ReadLine();
                        pujcovna.NacistZeSouboruAuto(filePath);
                        Console.ReadKey();
                        break;
                    case 13:
                        Console.WriteLine("Zadejte cestu k souboru pro uložení záakazníků:");
                        filePath = Console.ReadLine();
                        pujcovna.UlozitDoSouboruZ(filePath);
                        Console.ReadKey();
                        break;
                    case 14:
                        Console.WriteLine("Zadejte cestu k souboru pro načtení záakazníků:");
                        filePath = Console.ReadLine();
                        pujcovna.NacistZeSouboruZ(filePath);
                        Console.ReadKey();
                        break;
                }
                Console.Clear();
            }
        }
    }
}
