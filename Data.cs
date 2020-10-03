using System;

namespace Zadanie1
{
    public class Data
    {
        public string Imie;
        public string Nazwisko;
        public int Wiek;
        public string Plec;
        public string Adres;

        public void Reading(string imie, string nazwisko, int wiek, string plec, string adres)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Wiek = wiek;
            Plec = plec;
            Adres = adres;
        }

        public string GetFullName()
        {
            string fullName = string.Format("{0} {1} {2} {3} {4}", Imie, Nazwisko, Wiek, Plec, Adres);

            return fullName;
        }
        
    }
}