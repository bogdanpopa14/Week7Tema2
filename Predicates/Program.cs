using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> isUpper = IsUpperCase;

            bool result = isUpper("hello world!!");

            Console.WriteLine(result);

            //predicates anonymous method
            Predicate<string> isUpper2 = delegate (string s) { return s.Equals(s.ToUpper()); };

            //predicate lambda
            Predicate<string> isUpper3 = s => s.Equals(s.ToUpper());
        }

        static bool IsUpperCase(string str)
        {
            return str.Equals(str.ToUpper());
        }
    }
}
