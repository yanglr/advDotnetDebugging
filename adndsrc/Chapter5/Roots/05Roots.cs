using System;
using System.Text;
using System.Threading;

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

    class Roots
    {
        public static Name CompleteName = new Name ("First", "Last");

        private Thread thread;
        private bool shouldExit;

        static void Main(string[] args)
        {
            Roots r = new Roots();
            r.Run();
        }

        public void Run()
        {
            shouldExit = false;

            Name n1 = CompleteName;

            thread = new Thread(this.Worker);
            thread.Start(n1);

            Thread.Sleep(1000);

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            shouldExit = true;

        }

        public void Worker(Object o)
        {
            Name n1 = (Name)o;
            Console.WriteLine("Thread started {0}, {1}", 
                              n1.First, 
                              n1.Last);

            while (true)
            {
                // Do work
                Thread.Sleep(500);
                if (shouldExit)
                    break;
            }
        }
    }
}