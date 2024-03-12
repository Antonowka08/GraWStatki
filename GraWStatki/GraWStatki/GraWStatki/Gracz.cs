using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraWStatki
{
    internal class Gracz
    {
        public Plansza Plansza { get; set; }

        public Gracz(Plansza plansza)
        {
            Plansza = plansza;
        }

        public void RozmiescStatki()
        {
            for (int i = 1; i <= 10; i++)
            {
                int dlugosc = 1;

                if (i > 9)
                {
                    dlugosc = 4;
                }
                else if (i > 7)
                {
                    dlugosc = 3;
                }
                else if (i > 4)
                {
                    dlugosc = 2;
                }

                Statek statek = new Statek(dlugosc);
                Plansza.RozmiescStatek(statek);
            }
        }
    }
}
