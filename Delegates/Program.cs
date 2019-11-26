using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            Print printDel = PrintNumber;
            printDel += PrintMoney;
            printDel += PrintHexadecimal;
            printDel -= PrintMoney;
            PrintHelper(printDel, 3); 
        }

        public delegate void Print(int value);

        public static void PrintHelper(Print delegateFunc, int numToPrint)
        {
            delegateFunc(numToPrint);
        }

        public static void PrintNumber(int num)
        {
            Console.WriteLine($"Nr: {num}");
        }

        public static void PrintMoney(int money)
        {
            Console.WriteLine($"Money: {money}");
        }

        public static void PrintHexadecimal(int dec)
        {
            Console.WriteLine($"Hexadecimal: {dec}");
        }


    }



}
