using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraWStatki
{
    internal class Plansza
    {
        private char[,] _plansza = new char[10, 10];

        public Plansza()
        {
            InicjalizujPlansze();
        }

        public void InicjalizujPlansze()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    _plansza[i, j] = '.';
                }
            }
        }

        public void RysujPlansze()
        {
            Console.WriteLine("  A B C D E F G H I J");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(i + 1 + " ");
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(_plansza[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void RysujPlanszeOdkryta()
        {
            Console.WriteLine("  A B C D E F G H I J");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(i + 1 + " ");
                for (int j = 0; j < 10; j++)
                {
                    if (_plansza[i, j] == 'X' || _plansza[i, j] == 'O')
                    {
                        Console.Write(_plansza[i, j] + " ");
                    }
                    else
                    {
                        Console.Write(". ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void RozmiescStatek(Statek statek)
        {
            RozmiescStatekRecznie(_plansza, statek.Rozmiar);
        }

        public bool CzyKoniecGry()
        {
            foreach (var pole in _plansza)
            {
                if (pole == 'S')
                {
                    return false;
                }
            }
            return true;
        }

        public void WykonajRuch(Plansza planszaPrzeciwnika)
        {
            bool poprawnyRuch = false;
            int x = 0, y = 0;

            while (!poprawnyRuch)
            {
                Console.Write("Podaj współrzędne pola (np. A5): ");
                string wspolrzedne = Console.ReadLine().ToUpper();

                if ((wspolrzedne.Length == 2 && wspolrzedne[0] >= 'A' && wspolrzedne[0] <= 'J' &&
                    wspolrzedne[1] >= '1' && wspolrzedne[1] <= '9') || (wspolrzedne.Length == 3 &&
                    wspolrzedne[0] >= 'A' && wspolrzedne[0] <= 'J' && wspolrzedne[1] == '1' && wspolrzedne[2] == '0'))
                {
                    if (wspolrzedne.Length == 3)
                    {
                        x = 9;
                    }
                    else
                    {
                        x = wspolrzedne[1] - '1';
                    }
                    y = wspolrzedne[0] - 'A';

                    if (_plansza[x, y] == '.' || _plansza[x, y] == 'S')
                    {
                        poprawnyRuch = true;
                    }
                    else
                    {
                        Console.WriteLine("To pole zostało już trafione!");
                    }
                }
                else
                {
                    Console.WriteLine("Niepoprawne współrzędne. Podaj je ponownie.");
                }
            }

            if (_plansza[x, y] == 'S')
            {
                _plansza[x, y] = 'X';
                Console.WriteLine("Trafiony zatopiony!");
                planszaPrzeciwnika.Traf(x, y);
            }
            else
            {
                _plansza[x, y] = 'O';
                Console.WriteLine("Pudło!");
            }
        }

        private void Traf(int x, int y)
        {
            if (_plansza[x, y] == 'S')
            {
                _plansza[x, y] = 'X';
            }
        }

        private static void RozmiescStatekRecznie(char[,] plansza, int rozmiar)
        {
            Console.WriteLine($"Rozmieść statek o długości {rozmiar}:");
            for (int i = 0; i < rozmiar; i++)
            {
                bool poprawneWspolrzedne = false;
                int x = 0, y = 0;

                while (!poprawneWspolrzedne)
                {
                    Console.Write($"Podaj współrzędne pola {i + 1} (np. A5): ");
                    string wspolrzedne = Console.ReadLine().ToUpper();

                    if ((wspolrzedne.Length == 2 && wspolrzedne[0] >= 'A' && wspolrzedne[0] <= 'J' &&
                    wspolrzedne[1] >= '1' && wspolrzedne[1] <= '9') || (wspolrzedne.Length == 3 &&
                    wspolrzedne[0] >= 'A' && wspolrzedne[0] <= 'J' && wspolrzedne[1] == '1' && wspolrzedne[2] == '0'))
                    {
                        if (wspolrzedne.Length == 3)
                        {
                            x = 9;
                        }
                        else
                        {
                            x = wspolrzedne[1] - '1';
                        }
                        y = wspolrzedne[0] - 'A';

                        if (plansza[x, y] == '.')
                        {
                            poprawneWspolrzedne = true;
                        }
                        else
                        {
                            Console.WriteLine("Na tym polu jest już statek!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Niepoprawne współrzędne. Podaj je ponownie.");
                    }
                }

                plansza[x, y] = 'S';
            }
            Console.WriteLine();
        }
    }
}
