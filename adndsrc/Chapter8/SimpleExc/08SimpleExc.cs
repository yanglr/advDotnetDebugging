using System;
using System.Text;
using System.Runtime.InteropServices;

namespace Advanced.NET.Debugging.Chapter8
{
    class SimpleExc
    {
        static void Main(string[] args)
        {
            SimpleExc s = new SimpleExc();
            s.Run();
        }

        public void Run()
        {
            Console.WriteLine("Press any key to start");
    		Console.ReadKey();

            ProcessData(null);
        }

        public void ProcessData(string data)
        {
            if (data == null)
            {
                throw new ArgumentException("Argument NULL");
            }
            string s = "Hello: " + data;
        }

    }
}