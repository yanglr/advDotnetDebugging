using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Threading;
using System.Management;
using COMInterop;

namespace Advanced.NET.Debugging.Chapter7
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


    class Data
    {
        BasicMathClass data;

        public Data(BasicMathClass data)
        {
            this.data = data;
        }

        ~Data()
        {
            int result;
            data.Add(1, 2, out result);
        }
    }

    class Fin
    {
        private static BasicMathClass s;
        private static Worker worker;

        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("07Fin.exe <num iterations");
                return;
            }

            Thread newThread =
                   new Thread(new ThreadStart(Helper));
            newThread.SetApartmentState(ApartmentState.STA);
            newThread.IsBackground = true;
            newThread.Start();

            Thread.Sleep(2000);
            Data d = new Data(s);
            
            d = null;
            GC.Collect();
            GC.Collect();

            Initialize();

            for (int i = 0; i < Int32.Parse(args[0]); i++)
            {
                byte[] b = new byte[10000];
                Wmi w = new Wmi(b);
                w.ProcessData();
            }

            GC.Collect();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        private static void Initialize()
        {
            byte[] b = new byte[100];

            worker = new Worker();
            worker.ProcessData(b);

            worker = null;
            GC.Collect();
        }

        static void Helper()
        {
            s = new BasicMathClass();
            Thread.Sleep(60000*5);
        }

    }
}
