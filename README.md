# PujcovnaAut

Funkce aplikace:
Přidat nové vozidlo: Umožňuje uživatelům přidání nového vozidla do evidence půjčoven.
Odebrat vozidlo: Uživatelé mohou odebrat existující vozidlo z evidence půjčoven.
Upravit vozidlo: Poskytuje možnost úpravy informací o vozidlech již zaznamenaných v evidenci.
Vypsat auta a jejich stav: Uživatelé mohou získat přehled o všech dostupných vozidlech a jejich aktuálním stavu.
Registrace nového zákazníka: Slouží k zaregistrování nového zákazníka do systému půjčoven.
Upravit zákazníka: Umožňuje uživatelům upravit informace o existujících zákaznících.
Vypsat evidenci zákazníků: Poskytuje uživatelům seznam všech registrovaných zákazníků.
Vypsat historii půjček zákazníků: Uživatelé mohou získat přehled historie půjček pro každého zákazníka.
Půjčit vozidlo: Umožňuje uživatelům půjčit si vozidlo z nabídky dostupných vozidel.
Vrátit vozidlo: Slouží k vrácení půjčeného vozidla zpět do evidence půjčoven.
Uložit vozidla do souboru: Ukládá data o vozidlech do souboru pro budoucí použití.
Načíst vozidla ze souboru: Načítá data o vozidlech ze souboru do evidence půjčoven.
Uložit zákazníky do souboru: Ukládá informace o zákaznících do souboru pro budoucí použití.
Načíst zákazníky ze souboru: Načítá informace o zákaznících ze souboru do evidence půjčoven.
Ukončit program: Ukončuje běh aplikace.

Aplikace "Půjčovna vozidel" se skládá z několika tříd, zde je jejich seznam a popis jejich funkcí:
Třída Auto: Tato třída reprezentuje jedno konkrétní vozidlo. Obsahuje informace jako značka, SPZ, VIN, výrobce, model, rok výroby, cena za den půjčení, stav tachometru a počet míst.
Třída Zakaznik: Třída Zakaznik představuje jednoho zákazníka půjčovny. Obsahuje informace jako jméno, příjmení, datum narození, telefonní číslo a e-mailovou adresu.
Třída Pujcka: Třída Pujcka zaznamenává informace o jedné půjčce, jako je datum půjčení, datum vrácení, půjčené auto a zákazník.
Třída Pujcovna: Hlavní řídící třída aplikace. Obsahuje metody pro správu vozidel, zákazníků a půjček. Třída Pujcovna umožňuje přidávat, upravovat a odstraňovat vozidla a zákazníky, půjčovat a vracet vozidla a ukládat a načítat data ze souborů.
Třída Program: Tato třída obsahuje metodu Main, která je vstupním bodem programu a umožňuje uživatelům interakci s aplikací pomocí konzole.
