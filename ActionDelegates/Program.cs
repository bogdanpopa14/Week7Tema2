using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<int> printActionDel = ConsolePrint;
            //sau
            Action<int> printActionDel2 = new Action<int>(ConsolePrint);
            //sau metoda anonima
            Action<int> printActionDel3 = delegate (int i)
            {
                Console.WriteLine(i);
            };
            //sau lambda
            Action<int> printActionDel4 = i => Console.WriteLine(i);

        }

        static void ConsolePrint(int i)
        {
            Console.WriteLine(i);
        }

    }
}
