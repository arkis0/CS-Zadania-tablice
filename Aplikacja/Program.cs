/*
class Program
{
    static void Main()
    {
        Console.WriteLine("Podaj wagę w kilogramach:");
        double waga = double.Parse(Console.ReadLine());
        Console.WriteLine("Podaj wzrost w metrach:");
        double wzrost = double.Parse(Console.ReadLine());
        Console.WriteLine($"Twoje BMI to: {obliczBMI(waga, wzrost):F2}");

    }
    static double obliczBMI(double waga, double wzrost)
    {
        return waga / Math.Pow(wzrost, 2);
    }

    static void Main()
    {
        Console.WriteLine("Podaj rok: ");
        int rok = int.Parse(Console.ReadLine());
        Console.WriteLine(kiedyWielkanoc(rok));
    }
    static string kiedyWielkanoc(int rok)
    {
        int A = 0;
        int B = 0;
        if (rok < 1582)
        {
            A = 15;
            B = 6;
        }
        else if (rok > 1583 && rok < 1699)
        {
            A = 22;
            B = 2;
        }
        else if (rok > 1700 && rok < 1799)
        {
            A = 23;
            B = 3;
        }
        else if (rok > 1800 && rok < 1899)
        {
            A = 23;
            B = 4;
        }
        else if (rok > 1900 && rok < 2099)
        {
            A = 24;
            B = 5;
        }
        else if (rok > 2100 && rok < 2199)
        {
            A = 24;
            B = 6;
        }
        else if (rok > 2200 && rok < 2299)
        {
            A = 25;
            B = 0;
        }
        else if (rok > 2300 && rok < 2399)
        {
            A = 26;
            B = 1;
        }
        else if (rok > 2400 && rok < 2499)
        {
            A = 25;
            B = 1;
        }
        int a = rok % 19;
        int b = rok % 4;
        int c = rok % 7;
        int d = (a * 19 + A) % 30;
        int e = ((2 * b) + (4 * c) + (6 * d) + B) % 7;
        int wielkanoc = (22 + d + e);
        if (wielkanoc > 31)
        {
            wielkanoc = wielkanoc - 31;
            return $"{wielkanoc} kwietnia";
        }
        else
        {
            return $"{wielkanoc} marca";
        }
    }
}
*/
using System;

class Program
{
    public enum SortType
    {
        ASC,
        DESC
    }
    static void Main()
    {
        int[,] tablica = new int[10,10];
        wypelnijTablice(ref tablica);
        wyswietlTablice(tablica);
        Console.WriteLine($"Suma przekątnych: {sumaPrzekatnych(tablica)}");
        najwNajmElementTablicy(tablica);
        Console.WriteLine($"Średnia wartość elementów w tablicy to: { sredniaTablicy(tablica)}");
        sredniaTablicy(tablica);
        Console.WriteLine($"Ilość liczb 3 w tablicy: {ileLiczb3(tablica)}");
        SortujTablice(tablica, SortType.DESC);
        wyswietlTablice(tablica);

        int[,] wypelnijTablice(ref int[,] tablica)
        {
            var random = new Random();  
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    tablica[i, j] = random.Next(1, 49);
                }
            }

            return tablica;
        }
        void wyswietlTablice(int[,] tablica)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.Write("[");
                for (int j = 0; j < 10; j++)
                {
                    Console.Write($" {tablica[i, j]} ");
                    
                }
                Console.WriteLine("]");
            }

        }
        int sumaPrzekatnych(int[,] tablica)
        {
            int suma = 0;
            for (int i = 0; i < 10; i++)
            {
                suma += tablica[i, i];
                suma += tablica[i, 9 - i];
            }
            return suma;
        }
        int najwNajmElementTablicy( int[,] tablica)
        {
            int najmniejszy = 50;
            int najwiekszy = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (tablica[i, j] < najmniejszy)
                    {
                        najmniejszy = tablica[i, j];
                    }
                    if (tablica[i, j] > najwiekszy)
                    {
                        najwiekszy = tablica[i, j];
                    }
                    
                }
            }
            Console.WriteLine($"Min: {najmniejszy}");
            Console.WriteLine($"Max: {najwiekszy}");
            return 0;
        }
        int sredniaTablicy(int[,] tablica)
        {
            int suma = 0;
            int srednia = 0;
            for (int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    suma += tablica[i, j];
                }   
            }
            srednia = suma / tablica.Length;
            return srednia;
        }
        int ileLiczb3(int[,] tablica)
        {
            int iloscLiczb3 = 0;
            for (int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    if (tablica[i, j] == 3)
                    {
                        iloscLiczb3++;
                    }
                }   
            }
            return iloscLiczb3;
        }

    //Dowolnym sposobem posortuj elementy tablicy.Zdefiniuj typ SortType o wartościach ASC, DESC. Prześlij do funkcji parametr typu SortType z domyślną wartością ASC(rosnąco).Elementy tablicy należy sortować wierszami.
        static void SortujTablice(int[,] tablica, SortType sortType = SortType.ASC)
        {
            if (sortType == SortType.ASC)
            {
                while (true)
                {
                     int validPositions = 0;
                    for (int i = 0; i < tablica.GetLength(0); i++)
                    {
                        for (int j = 0; j < tablica.GetLength(1) - 1; j++)
                        {
                            if (tablica[i, j] > tablica[i, j + 1])
                            {
                                int temp = tablica[i, j];
                                tablica[i, j] = tablica[i, j + 1];
                                tablica[i, j + 1] = temp;
                            }
                            else
                            {
                                validPositions++;
                            }
                        }
                    }
                    if (validPositions >= tablica.GetLength(0) * (tablica.GetLength(1) - 1))
                    {
                        break;
                    }
                }
            }
            else if (sortType == SortType.DESC)
            {
                while (true)
                {
                    int validPositions = 0;
                    for (int i = 0; i < tablica.GetLength(0); i++)
                    {
                        for (int j = 0; j < tablica.GetLength(1) - 1; j++)
                        {
                            if (tablica[i, j] < tablica[i, j + 1])
                            {
                                int temp = tablica[i, j];
                                tablica[i, j] = tablica[i, j + 1];
                                tablica[i, j + 1] = temp;
                            }
                            else
                            {
                                validPositions++;
                            }
                        }
                    }
                    if (validPositions >= tablica.GetLength(0) * (tablica.GetLength(1) - 1))
                    {
                        break;
                    }
                }
            }
        }
    }
}