using System;
using System.Text;
using System.Threading;

namespace Advanced.NET.Debugging.Chapter6
{
    internal class DBWrapper1
    {
        private string connectionString;

        public DBWrapper1(string conStr)
        {
            this.connectionString = conStr;
        }
    }

    internal class DBWrapper2
    {
        private string connectionString;

        public DBWrapper2(string conStr)
        {
            this.connectionString = conStr;
        }
    }
    
    class Deadlock
    {
        private static DBWrapper1 db1;
        private static DBWrapper2 db2;

        static void Main(string[] args)
        {
            db1 = new DBWrapper1("DBCon1");
            db2 = new DBWrapper2("DBCon2");

            Thread newThread = new Thread(ThreadProc);
            newThread.Start();

            Thread.Sleep(2000);
            lock (db2)
            {
                Console.WriteLine("Updating DB2");
                Thread.Sleep(2000);
                lock (db1)
                {
                    Console.WriteLine("Updating DB1");
                }
            }
        }

        private static void ThreadProc()
        {
            Console.WriteLine("Start worker thread");
            lock (db1)
            {
                Console.WriteLine("Updating DB1");
                Thread.Sleep(3000);
                lock (db2)
                {
                    Console.WriteLine("Updating DB2");
                }
            }
            Console.WriteLine("Out");
        }
    }
}
