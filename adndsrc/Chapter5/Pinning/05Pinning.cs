using System;
using System.Text;
using System.Runtime.InteropServices;

namespace Advanced.NET.Debugging.Chapter5
{
    class Pinning
    {
        static void Main(string[] args)
        {
            Pinning p = new Pinning();
            p.Run();
        }

        public void Run()
        {
            SByte[] b1 = null;
            SByte[] b2 = null;
            SByte[] b3 = null; 

            Console.WriteLine("Press any key to alloc");
            Console.ReadKey();

            b1 = new SByte[100]; 
            b2 = new SByte[200];
            b3 = new SByte[300]; 

            GCHandle h1 = GCHandle.Alloc(b1, GCHandleType.Pinned);
            GCHandle h2 = GCHandle.Alloc(b2, GCHandleType.Pinned);
            GCHandle h3 = GCHandle.Alloc(b3, GCHandleType.Pinned);

            Console.WriteLine("Press any key to GC");
            Console.ReadKey();

            GC.Collect();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            h1.Free(); h2.Free(); h3.Free();
        }

    }
}