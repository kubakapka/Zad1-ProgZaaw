using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.IO;
using System.Xml.Serialization;

namespace Zadanie1
{

    class Program
    {
        public enum Menu
        {
            Dodaj = 1,
            Edytuj,
            Usun,
            Szukaj,
            Przegladaj,
            Koniec
        };

        public static void Main(string[] args)
        {
            List<Data> accounts = new List<Data>();

            Intro intro = new Intro();
            


            
            bool loopBreak = true;
            while (loopBreak)
            {
                intro.ShowMenu();
                Menu menu = 0;
                
                Enum.TryParse(Console.ReadLine(), out menu);


                switch (menu)
                {

                    case Menu.Dodaj:
                    {
                        int end = 1;


                        Data data = new Data();

                        do
                        {
                            Console.WriteLine("Podaj imie:");
                            data.Imie = Console.ReadLine();
                            Console.WriteLine("Podaj nazwisko:");
                            data.Nazwisko = Console.ReadLine();
                            Console.WriteLine("Podaj wiek:");
                            data.Wiek = int.Parse(Console.ReadLine());
                            Console.WriteLine("Podaj plec:");
                            data.Plec = Console.ReadLine();
                            Console.WriteLine("Podaj adres:");
                            data.Adres = Console.ReadLine();
                            accounts.Add(new Data()
                            {
                                Adres = data.Adres, Imie = data.Imie, Nazwisko = data.Nazwisko, Plec = data.Plec,
                                Wiek = data.Wiek
                            });
                            Console.WriteLine("Wpisz 0 żeby kontynuować, inna liczba - zakończ");
                            end = int.Parse(Console.ReadLine());
                        } while (end == 0);

                        if (accounts.Count > 0)
                        {
                            using (StreamWriter writer = new StreamWriter("file.txt"))
                            {
                                XmlSerializer serializer = new XmlSerializer(typeof(List<Data>));
                                serializer.Serialize(writer, accounts);
                            }
                        }

                        
                        break;
                    }
                    case Menu.Edytuj:
                    {
                        
                        break;
                    }


                    case Menu.Usun:
                    {
                        
                        
                        break;
                    }

                    case Menu.Szukaj:
                    {
                        //NIEDOKONCZONE
                        
                        Console.Write("Wyszukaj: ");
                        var find = Console.ReadLine();
                        bool found = false;
                        if (found)
                        {
                            accounts.Find(x => x.Imie.Contains(find));
                            
                        }
                        else 
                        accounts.Find(x => x.Nazwisko.Contains(find));
                        accounts.Find(x => x.Plec.Contains(find));
                        accounts.Find(x => x.Adres.Contains(find));
                        break;
                    }

                    case Menu.Przegladaj:
                    {
                        using (StreamReader writer = new StreamReader("file.txt"))
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(List<Data>));
                            var listFromFile = serializer.Deserialize(writer);
                            accounts.AddRange(listFromFile);
                            
                        }
                        foreach (Data aData in accounts)
                        {
                            Console.WriteLine("Nr. {0} " + aData.GetFullName());
                        }

                        
                        break;
                    }
                    case Menu.Koniec:
                    {
                        loopBreak = false;
                        break;
                    }
                }
            }
            

            Console.ReadKey();
        }


    }
}