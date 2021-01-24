using System;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;
using Microsoft.WindowsErrorReporting.Services.Data.API;

namespace Advanced.NET.Debugging.Chapter8
{
    class WerConsole
    {
        static void Main(string[] args)
        {
            WerConsole s = new WerConsole();
            s.Run();
        }

        public void Run()
        {
            int eventId;
            string product, file, cabLoc, userName, password;
            Login login;

            Console.Write("Enter user name: ");
            userName = Console.ReadLine();

            Console.Write("Enter password: ");
            password = Console.ReadLine();

            Console.WriteLine("Login into WER...");
            login=WerLogin(userName, password);
            Console.WriteLine("Login succeeded");

            Console.Write("Enter Product: ");
            product=Console.ReadLine();

            Console.Write("Enter File: ");
            file=Console.ReadLine();
            
            Console.Write("Enter Event ID: ");
            eventId=Int32.Parse(Console.ReadLine());

            Console.Write("Enter Location to store CABs: ");
            cabLoc = Console.ReadLine();
            if (Directory.Exists(cabLoc) == false)
            {
                Directory.CreateDirectory(cabLoc);
            }

            Event e=GetEvent(product, file, eventId, ref login);
            Console.WriteLine("Event successfully retrieved");
            Console.WriteLine("Event ID: " + e.ID);
            Console.WriteLine("Event Total Hits: " + e.TotalHits.ToString());
            Console.WriteLine("Storing CABs...");
            foreach (Cab c in e.GetCabs(ref login))
            {
                try
                {
                    c.SaveCab(cabLoc, true, ref login);
                }
                catch (Exception)
                {
                }
            }
            Console.WriteLine("CABs stored to: " + cabLoc);
        }

        public Login WerLogin(string userName, string password)
        {
            Login login = new Login(userName, password);
            login.Validate();
            return login;
        }

        public Event GetEvent(string pr, 
                              string fi, 
                              int eventId, 
                              ref Login login)
        {
            foreach (Product p in Product.GetProducts(ref login))
            {
                if (p.Name == pr)
                {
                    ApplicationFileCollection ac = 
                              p.GetApplicationFiles(ref login);
                    foreach (ApplicationFile file in ac)
                    {
                        if (file.Name == fi)
                        {
                            EventPageReader epr=file.GetEvents();
                            while (epr.Read(ref login) == true)
                            {
                                EventReader er = epr.Events;
                                while (er.Read() == true)
                                {
                                    Event e = er.Event;
                                    return e;
                                }
                            }
                        }
                    }
                }
            }
            throw new Exception("Event Not Found");
        }
    }
}