using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using COMInterop;

namespace Advanced.NET.Debugging.Chapter7
{
    class COMInteropSample
    {
        [STAThread]
        static void Main(string[] args)
        {
            int result;
            BasicMathClass s = new BasicMathClass();
            s.Add(1, 2, out result);
            Console.WriteLine("Result= " + result);
        }
    }
}
