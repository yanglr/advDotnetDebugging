using System;
using System.Text;

namespace Advanced.NET.Debugging.Chapter3
{
    class Breakpoint
    {
        static void Main(string[] args)
        {
            //
            // Calling instance function once
            //
            Console.WriteLine("Press any key (1st instance function)");
            Console.ReadKey();
            Breakpoint bp = new Breakpoint();
            bp.AddAndPrint(10, 5);

            //
            // Calling instance function twice
            //
            Console.WriteLine("Press any key (2nd instance function)");
            Console.ReadKey();
            bp = new Breakpoint();
            bp.AddAndPrint(100, 50);


            //
            // Calling static function
            //
            Console.WriteLine("Press any key (static function)");
            Console.ReadKey();
            AddAndPrintStatic(20, 15);
        }

        public void AddAndPrint(int a, int b)
        {
            int res = a + b;
            Console.WriteLine("Adding {0}+{1}={2}", a, b, res);
        }

        public static void AddAndPrintStatic(int a, int b)
        {
            int res = a + b;
            Console.WriteLine("Adding {0}+{1}={2}", a, b, res);
        }
    }
}
