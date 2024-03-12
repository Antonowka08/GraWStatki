using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraWStatki
{
    internal class Gra
    {
        public void Graj(Plansza planszaGracza1, Plansza planszaGracza2)
        {
            Gracz gracz1 = new Gracz(planszaGracza1);
            Gracz gracz2 = new Gracz(planszaGracza2);

            Console.WriteLine("Gra w Statki - dwóch graczy\n");
            Console.WriteLine("Gracz 1, rozmieść swoje statki:");
            planszaGracza1.RysujPlansze();
            gracz1.RozmiescStatki();

            Console.Clear();

            Console.WriteLine("Gracz 2, rozmieść swoje statki:");
            planszaGracza2.RysujPlansze();
            gracz2.RozmiescStatki();

            Console.Clear();

            Console.WriteLine("Rozpoczynamy grę!");

            while (!planszaGracza1.CzyKoniecGry() && !planszaGracza2.CzyKoniecGry())
            {
                Console.WriteLine("Gracz 1:");
                planszaGracza1.RysujPlansze();
                planszaGracza2.RysujPlanszeOdkryta();
                planszaGracza2.WykonajRuch(planszaGracza1);

                Console.Clear();

                if (planszaGracza2.CzyKoniecGry())
                {
                    Console.WriteLine("Gracz 1 wygrywa!");
                    break;
                }

                Console.WriteLine("Gracz 2:");
                planszaGracza2.RysujPlansze();
                planszaGracza1.RysujPlanszeOdkryta();
                planszaGracza1.WykonajRuch(planszaGracza2);

                Console.Clear();

                if (planszaGracza1.CzyKoniecGry())
                {
                    Console.WriteLine("Gracz 2 wygrywa!");
                    break;
                }
            }
        }
    }
}