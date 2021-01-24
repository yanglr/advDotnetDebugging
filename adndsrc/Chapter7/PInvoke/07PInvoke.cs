using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;

namespace Advanced.NET.Debugging.Chapter7
{
    class PInvoke
    {
        private const int TableSize = 50;

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public class Node
        {
            public string First;
            public string Last;
            public string Social;
            public UInt32 Age;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class Table
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = TableSize)]
            public IntPtr[] Nodes;

            public IntPtr Aux;
        }

        static void Main(string[] args)
        {
            PInvoke p = new PInvoke();
            p.Run();
        }

        public void Run()
        {
            Node[] nodes = new Node[TableSize];
            nodes[0] = new Node();
            nodes[0].First = "First Name 1";
            nodes[0].Last = "Last Name 1";
            nodes[0].Social = "Social 1";
            nodes[0].Age = 30;

            nodes[1] = new Node();
            nodes[1].First = "First Name 2";
            nodes[1].Last = "Last Name 2";
            nodes[1].Social = "Social 2";
            nodes[1].Age = 31;

            nodes[2] = new Node();
            nodes[2].First = "First Name 3";
            nodes[2].Last = "Last Name 3";
            nodes[2].Social = "Social 3";
            nodes[2].Age = 32;

            Table t = new Table();
            t.Aux = IntPtr.Zero;

            t.Nodes = new IntPtr[TableSize];
            for (int i = 0; i < TableSize && nodes[i] != null; i++)
            {
                int nodeSize = Marshal.SizeOf(typeof(Node));
                t.Nodes[i] = Marshal.AllocHGlobal(nodeSize);
                Marshal.StructureToPtr(nodes[i], t.Nodes[i], false);
            }

            int tableSize = Marshal.SizeOf(typeof(Table));
            IntPtr pTable = Marshal.AllocHGlobal(tableSize);
            Marshal.StructureToPtr(t, pTable, false);

            Myfunc(pTable); 
        }

        [DllImport("05Native.dll")]
        private static extern void Myfunc(IntPtr ptr);
    }
}
