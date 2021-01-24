using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;

namespace Advanced.NET.Debugging.Chapter7
{
    class BeepSample
    {
        static void Main(string[] args)
        {
            Beep(1000, 2000);
        }

        [DllImport("kernel32.dll", SetLastError=true)]
        private static extern bool Beep(uint freq, uint dur);
    }
}
