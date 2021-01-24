using System;
using System.Text;
using System.Threading;

namespace Advanced.NET.Debugging.Chapter6
{
    class Simple
    {
        static void Main(string[] args)
        {
            Simple s = new Simple();
            s.Run();
        }

        public void Run()
        {
            this.GetHashCode();

            Console.WriteLine("Press any key to acquire lock");
            Console.ReadLine();
            Monitor.Enter(this);
            Console.WriteLine("Press any key to release lock");
            Console.ReadLine();
            Monitor.Exit(this);
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }
    }
}
