using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraWStatki
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Plansza planszaGracza1 = new Plansza();
            Plansza planszaGracza2 = new Plansza();

            Gra gra = new Gra();
            gra.Graj(planszaGracza1, planszaGracza2);

            Console.WriteLine("Koniec gry!");
        }
    }
}
