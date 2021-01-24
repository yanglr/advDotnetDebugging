using System;
using System.Text;

namespace Advanced.NET.Debugging.Chapter2
{
    class ExcSample
    {
        void Func(int a)
        {
            if(a==0)
            {
                throw new ArgumentException();
            }
        }

        static void Main(string[] args)
        {
            ExcSample sample = new ExcSample();

            try
            {
                sample.Func(0);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Exception encountered {0}", e);
            }
        }
    }
}
