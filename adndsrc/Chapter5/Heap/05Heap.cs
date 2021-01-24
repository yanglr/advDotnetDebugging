using System;
using System.Text;
using System.Runtime.InteropServices;

namespace Advanced.NET.Debugging.Chapter5
{
    class Heap
    {
        static void Main(string[] args)
        {
            Heap h = new Heap();
            h.Run();
        }

        public void Run()
        {
            byte[] b = new byte[50];
            for (int i = 0; i < 50; i++)
                b[i] = 15;


            Console.WriteLine("Press any key to invoke native method");
            Console.ReadKey();

            InitBuffer(b, 50);
            
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        [DllImport("05Native.dll")]
        static extern void InitBuffer(byte[] buffer, int size); 

    }
}