using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Threading;

namespace Advanced.NET.Debugging.Chapter7
{
    class PInvoke
    {
        public delegate void Callback(int result);

        public static void Main()
        {
            Callback c = new Callback(MyCallback);

            AsyncProcess(c);

            // Do additional work
            
            c = null;
            GC.Collect();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        
        }

        public static void MyCallback(int result)
        {
            Console.WriteLine("Result= " + result); 
        }

        [DllImport("05Native.dll")]
        private static extern void AsyncProcess(Callback callBack);
    }
}
