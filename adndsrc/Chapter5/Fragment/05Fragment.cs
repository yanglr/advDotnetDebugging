using System;
using System.Text;
using System.Runtime.InteropServices;

namespace Advanced.NET.Debugging.Chapter5
{
    class Fragment
    {
        static void Main(string[] args)
        {
            Fragment f = new Fragment();
            f.Run(args);
        }

        public void Run(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("05Fragment.exe <alloc. size> <max mem in MB>");
                return;
            }

            int size = Int32.Parse(args[0]);
            int maxmem = Int32.Parse(args[1]);
            byte[][] nonPinned = null;
            byte[][] pinned = null;
            GCHandle[] pinnedHandles = null;

            int numAllocs = maxmem * 1000000 / size;

            pinnedHandles = new GCHandle[numAllocs];

            pinned = new byte[numAllocs / 2][];
            nonPinned = new byte[numAllocs / 2][];

            for (int i = 0; i < numAllocs / 2; i++)
            {
                nonPinned[i] = new byte[size];
                pinned[i] = new byte[size];
                pinnedHandles[i] =
            GCHandle.Alloc(pinned[i], GCHandleType.Pinned);
            }

            Console.WriteLine("Press any key to GC & promo to gen1");
            Console.ReadKey();

            GC.Collect();

            Console.WriteLine("Press any key to GC  & promo to gen2");
            Console.ReadKey();

            GC.Collect();

            Console.WriteLine("Press any key to GC(free non pinned");
            Console.ReadKey();

            for (int i = 0; i < numAllocs / 2; i++)
            {
                nonPinned[i] = null;
            }

            GC.Collect();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
