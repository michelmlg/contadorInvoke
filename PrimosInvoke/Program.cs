using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Primos
{
    class Program
    {
        public static class Globals
        {
            public static int numPrimos { get; set; }
            public static DateTime total { get; set; }
            public static int flag;


        }

        public static bool isPrimo(int x)
        {
            int f = x / 2 + 1;
            for (int i = 2; i < f; ++i)
                if (x % i == 0) return false;
            return true;
        }
        public static void calculaPrimos(int x, int y)
        {
            DateTime inicio, fim;
            int k = 0;

            inicio = DateTime.Now;
            for (int i = x; i < y; ++i)
                if (isPrimo(i))
                {

                    ++k;
                }
            Globals.numPrimos += k;

            Globals.flag++;
            Console.WriteLine(Globals.flag);
            Console.WriteLine(Globals.numPrimos);



            fim = DateTime.Now;

            Console.WriteLine("Foram encontrados " + k + " numeros primos.");
            Console.WriteLine("Tempo = " + (fim - inicio));
        }
        public static void total()
        {
            if (Globals.flag == 3)
            {
                Console.WriteLine("Total de Primos (mineiro médio): " + Globals.numPrimos);
            }
        }

        static void Main(string[] args)
        {
            DateTime Inicio,fim;
           
            Inicio = DateTime.Now;
            Parallel.Invoke(
              () =>
              {
                  Console.WriteLine("Iniciando Processo1");
                   calculaPrimos(0, 200000);
                  Console.WriteLine("Finalizando Processo1");
              },
              () =>
              {
                  Console.WriteLine("Iniciando Processo2");
                  calculaPrimos(200001, 400000);
                 
                  Console.WriteLine("Finalizando Processo2");
              },
              () =>
              {
                  Console.WriteLine("Iniciando Processo3");
                  calculaPrimos(400001, 600000);
                  
                  Console.WriteLine("Finalizando Processo3");
              }
           );
            fim = DateTime.Now;


            total();

            Console.WriteLine("O total de tempo foi: " + (fim - Inicio));
            Console.ReadKey();

        }

    }
}