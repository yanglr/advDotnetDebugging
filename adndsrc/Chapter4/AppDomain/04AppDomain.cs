using System;
using System.Text;
using System.Runtime.Remoting;

namespace Advanced.NET.Debugging.Chapter4
{
    [Serializable]
    class Entity
    {
        public int a;
    }

    [Serializable]
    class EntityUtil
    {
        public void Dump(Entity t)
        {
            Console.WriteLine(t.a);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
        }
        
        public void Run()
        {
            while (true)
            {
                Console.WriteLine("1. Run in default app domain");
                Console.WriteLine("2. Run in dedicated app domain");
                Console.WriteLine("Q. To quit");
                Console.Write("> ");
                ConsoleKeyInfo k=Console.ReadKey();
                Console.WriteLine();

                if (k.KeyChar == '1')
                {
                    RunInDefault();
                }
                else if (k.KeyChar == '2')
                {
                    RunInDedicated();
                }
                else if (k.KeyChar == 'q' || k.KeyChar == 'Q')
                    break;
            }

        }

        public AppDomain CreateDomain()
        {
            AppDomainSetup domaininfo = new AppDomainSetup();
            domaininfo.ApplicationBase = "C:\\Windows\\System32";
            return AppDomain.CreateDomain("MyDomain", null, domaininfo);

        }

        public void RunInDefault()
        {
            EntityUtil t2 = new EntityUtil();

            Entity t = new Entity();
            t.a = 10;

            t2.Dump(t);
        }

        public void RunInDedicated()
        {
            AppDomain domain = CreateDomain();
            ObjectHandle h = domain.CreateInstance(
                                  "04AppDomain", 
                                  "Advanced.NET.Debugging.Chapter4.EntityUtil");
            EntityUtil t2 = (EntityUtil)h.Unwrap();

            Entity t = new Entity();
            t.a = 10;

            t2.Dump(t);
        }
    }
}
