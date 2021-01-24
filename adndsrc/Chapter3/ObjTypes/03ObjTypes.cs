using System;
using System.Text;

namespace Advanced.NET.Debugging.Chapter3
{
    public class ObjTypes
    {
        public struct Coordinate
        {
            public int xCord;
            public int yCord;
            public int zCord;

            public Coordinate(int x, int y, int z)
            {
                xCord = x;
                yCord = y;
                zCord = z;
            }
        }

        private Coordinate coordinate;

        int[] intArray = new int[] { 1, 2, 3, 4, 5 };
        string[] strArray = new string[] {"Welcome", 
                                          "to",
                                          "Advanced",
                                          ".NET",
                                          "Debugging"};

        static void Main(string[] args)
        {
            Coordinate point= new Coordinate(100, 100, 100);
            Console.WriteLine("Press any key to continue (AddCoordinate)");
            Console.ReadKey();
            ObjTypes ob = new ObjTypes();
            ob.AddCoordinate(point);

            Console.WriteLine("Press any key to continue (Arrays)");
            Console.ReadKey();
            ob.PrintArrays();
            
            Console.WriteLine("Press any key to continue (Generics)");
            Console.ReadKey();
            Comparer<int> c = new Comparer<int>();
            Console.WriteLine("Greater {0}", c.GreaterThan(5, 10));

            Console.WriteLine("Press any key to continue (Exception)");
            Console.ReadKey();
            ob.ThrowException(null);
        }

        public void AddCoordinate(Coordinate coord)
        {
            coordinate.xCord += coord.xCord;
            coordinate.yCord += coord.yCord;
            coordinate.zCord += coord.zCord;

            Console.WriteLine("x:{0}, y:{1}, z:{2}",
                              coordinate.xCord,
                              coordinate.yCord,
                              coordinate.xCord);
        }

        public void PrintArrays()
        {
            foreach (int i in intArray)
            {
                Console.WriteLine("Int: {0}", i);
            }
            foreach (string s in strArray)
            {
                Console.WriteLine("Str: {0}", s);
            }
        }

        public void ThrowException(ObjTypes obj)
        {
            if (obj == null)
            {
                throw new System.ArgumentException("Obj cannot be null");
            }
        }
    }

    public class Comparer<T> where T: IComparable
    {
        public T GreaterThan(T d, T d2)
        {
            int ret = d.CompareTo(d2);
            if (ret > 0)
                return d;
            else
                return d2;
        }

        public T LessThan(T d, T d2)
        {
            int ret = d.CompareTo(d2);
            if (ret < 0)
                return d;
            else
                return d2;
        }
    }
}
