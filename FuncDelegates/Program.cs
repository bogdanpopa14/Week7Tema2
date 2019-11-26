using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int> add = Sum;
            Func<int, int, int> add3 = delegate (int a, int b) { return a + b; };
            Func<int, int, int> add2 = (x, y) => x + y;
            int result = add(10, 10);

            Console.WriteLine(result);
        }



        static int Sum(int x, int y)
        {
            return x + y;
        }
    }
}
