using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Management;

namespace Advanced.NET.Debugging.Chapter5
{
    class Wmi
    {
        private ManagementClass obj;
        private byte[] data;

        public Wmi(byte[] data)
        {
            this.data = data;
        }

        public void ProcessData()
        {
            obj = new ManagementClass("Win32_Environment");
            obj.Get();
            
            //
            // Use data member reference
            //
        }
                
        ~Wmi()
        {
            //
            // Clean up any native resources
            //
        }
    }

    class Worker
    {
        public Worker()
        {
            Init();
        }

        public void ProcessData(byte[] data)
        {
            Process(data);
        }

        ~Worker()
        {
            UnInit();
        }

        [DllImport("05Native.dll")]
        static extern void Init(); 
        
        [DllImport("05Native.dll")]
        static extern void UnInit();

        [DllImport("05Native.dll")]
        static extern void Process(byte[] data); 
    }

    class OOMFin
    {
        private Worker worker; 

        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("05OOMFin.exe <num iterations>");
                return;
            }

            OOMFin o = new OOMFin();
            o.Run(Int32.Parse(args[0]));
        }

        public void Run(int iterations)
        {
            Initialize();

            for (int i = 0; i < iterations; i++)
            {
                byte[] b = new byte[10000];
                Wmi w = new Wmi(b);
                w.ProcessData();
            }

            GC.Collect();
           
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        private void Initialize()
        {
            byte[] b = new byte[100];

            worker = new Worker();
            worker.ProcessData(b);

            worker = null;
            GC.Collect();
        }
    }
}