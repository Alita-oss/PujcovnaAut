# PujcovnaAut

Funkce aplikace:
1. Přidat nové vozidlo: Umožňuje uživatelům přidání nového vozidla do evidence půjčoven.
2. Odebrat vozidlo: Uživatelé mohou odebrat existující vozidlo z evidence půjčoven.
3. Upravit vozidlo: Poskytuje možnost úpravy informací o vozidlech již zaznamenaných v evidenci.
4. Vypsat auta a jejich stav: Uživatelé mohou získat přehled o všech dostupných vozidlech a jejich aktuálním stavu.
5. Registrace nového zákazníka: Slouží k zaregistrování nového zákazníka do systému půjčoven.
6. Upravit zákazníka: Umožňuje uživatelům upravit informace o existujících zákaznících.
7. Vypsat evidenci zákazníků: Poskytuje uživatelům seznam všech registrovaných zákazníků.
8. Vypsat historii půjček zákazníků: Uživatelé mohou získat přehled historie půjček pro každého zákazníka.
9. Půjčit vozidlo: Umožňuje uživatelům půjčit si vozidlo z nabídky dostupných vozidel.
10. Vrátit vozidlo: Slouží k vrácení půjčeného vozidla zpět do evidence půjčoven.
11. Uložit vozidla do souboru: Ukládá data o vozidlech do souboru pro budoucí použití.
12. Načíst vozidla ze souboru: Načítá data o vozidlech ze souboru do evidence půjčoven.
13. Uložit zákazníky do souboru: Ukládá informace o zákaznících do souboru pro budoucí použití.
14. Načíst zákazníky ze souboru: Načítá informace o zákaznících ze souboru do evidence půjčoven.
15. Ukončit program: Ukončuje běh aplikace.

Aplikace "Půjčovna vozidel" se skládá z 5 tříd, zde je jejich seznam a popis jejich funkcí:
1. Třída Auto: Tato třída reprezentuje jedno konkrétní vozidlo. Obsahuje informace jako značka, SPZ, VIN, výrobce, model, rok výroby, cena za den půjčení, stav tachometru a počet míst.
2. Třída Zakaznik: Třída Zakaznik představuje jednoho zákazníka půjčovny. Obsahuje informace jako jméno, příjmení, datum narození, telefonní číslo a e-mailovou adresu.
3. Třída Pujcka: Třída Pujcka zaznamenává informace o jedné půjčce, jako je datum půjčení, datum vrácení, půjčené auto a zákazník.
4. Třída Pujcovna: Hlavní řídící třída aplikace. Obsahuje metody pro správu vozidel, zákazníků a půjček. Třída Pujcovna umožňuje přidávat, upravovat a odstraňovat vozidla a zákazníky, půjčovat a vracet vozidla a ukládat a načítat data ze souborů.
5. Třída Program: Tato třída obsahuje metodu Main, která je vstupním bodem programu a umožňuje uživatelům interakci s aplikací pomocí konzole.
