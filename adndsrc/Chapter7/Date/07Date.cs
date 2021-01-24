using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Threading;

namespace Advanced.NET.Debugging.Chapter7
{
    class PDate
    {
        public static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Please specify number of iterations");
                return;
            }

            int it = Int32.Parse(args[0]);

            StringBuilder date=new StringBuilder(100);
            for (int i = 0; i < it; i++)
            {
                GetDate(date);
            }

            GC.Collect();
            Console.WriteLine("Press any key to exit");
            Console.Read();
        }

        [DllImport("05Native.dll", CharSet = CharSet.Unicode)]
        private static extern void GetDate(StringBuilder date);
    }
}
