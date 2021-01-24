using System;
using System.Text;
using System.Runtime.Remoting;

namespace Advanced.NET.Debugging.Chapter5
{
    class Name
    {
        private string first;
        private string last;

        public string First { get { return first; } }
        public string Last { get { return last; } }

        public Name(string f, string l)
        {
            first = f; last = l;
        }
    }

    class Gen
    {
        static void Main(string[] args)
        {
            Name n1 = new Name("Mario", "Hewardt");
            Name n2 = new Name("Gemma", "Hewardt");

            Console.WriteLine("Allocated objects"); 

            Console.WriteLine("Press any key to invoke GC");
            Console.ReadKey();

            n1 = null;
            GC.Collect();

            Console.WriteLine("Press any key to invoke GC");
            Console.ReadKey();

            GC.Collect();
            
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
