using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace History
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter positive number 1: ");
            int number1 = Int32.Parse(Console.ReadLine());
            Console.Write("Enter positive number 2: ");
            int number2 = Int32.Parse(Console.ReadLine());
         
            float res = Divide(number1, number2);
            Console.WriteLine("Result: {0}", res);
        }

        public static float Divide(int num1, int num2)
        {
            int number1 = num1; int number2 = num2; 
            if (number1 < 0) number1 = 0;
            if (number2 < 0) number2 = 0;
            return number1 / number2;
        }
    }
}
