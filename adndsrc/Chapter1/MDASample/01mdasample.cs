using System;
using System.Threading;

namespace Advanced.NET.Debugging.Chapter2
{
    class Program 
    {
        public static void Main(string[] args) 
        {
            Thread t = new Thread(delegate() 
            {
                while (true) 
                { 
                    Thread.Sleep(500); 
                }
            });

            t.Start();
            t.Abort();
            Console.WriteLine("Done");
        }
    }
}
