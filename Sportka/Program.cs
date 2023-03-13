using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Sportka
{
    internal class Program
    {
        static int NactiCislo(int i, int[] zadanaCisla)
        {
            Console.WriteLine($"Zadej {i + 1}. číslo: ");
            int cislo;
            while (!int.TryParse(Console.ReadLine(), out cislo) || cislo<1 || cislo>49 || zadanaCisla.Contains(cislo))
            {
                Console.WriteLine("Špatně zadané číslo.");
                Console.WriteLine($"Zadej {i + 1}. číslo: ");
            }
            return cislo;
        }

        static void Main(string[] args)
        {
            int[] zadanaCisla = new int[6];
            int[] vylosovanaCisla = new int[7];
            int[] shodnaCisla = new int[6];
            int vylosovaneCislo = 0;
            int shoda = 0;

            Console.WriteLine("Vítej ve hře Sportka! Tipni si šest čísel mezi 1 a 49 včetně.");

            for (int i = 0; i < 6; i++){
                zadanaCisla[i] = NactiCislo(i, zadanaCisla);
            }
       
            Random rnd = new Random();
            for (int i = 0; i < 7; i++)
            {
                while (vylosovanaCisla.Contains(vylosovaneCislo)) {
                    vylosovaneCislo = rnd.Next(1, 50);
                }
                vylosovanaCisla[i] = vylosovaneCislo;
            }

            Console.WriteLine("Počítač vylosoval čísla:");
            for (int i = 0; i < vylosovanaCisla.Length; i++)
            {
                Console.Write(vylosovanaCisla[i] + "  ");
            }

            for (int i = 0; i < zadanaCisla.Length; i++)
            {
                if (vylosovanaCisla.Contains(zadanaCisla[i]))
                {
                    shodnaCisla[shoda] = zadanaCisla[i];
                    shoda++;
                }
            }

            Console.WriteLine("");
            Console.WriteLine("Počet uhodnutých čísel: " + shoda);
            if (shoda == 1)
            {
                Console.WriteLine("Uhodl jsi číslo: " + shodnaCisla[0]);
            }

            else if (shoda > 1)
            {
                Console.WriteLine("Uhodl jsi čísla:");
                for (int i = 0; i < shodnaCisla.Length; i++)
                {
                    if (shodnaCisla[i] == 0)
                    {
                        break;
                    }
                    Console.Write(shodnaCisla[i] + "  ");
                }
            }
            
            Console.WriteLine("");

            if (shoda > 3)
            {
                Console.WriteLine("Vyhrál jsi!");
            }
            else Console.WriteLine("Prohrál jsi!");
            Console.ReadLine();
        }
    }
}
