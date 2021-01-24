using System;
using System.Text;

namespace Advanced.NET.Debugging.Chapter2
{
    class TypeSample
    {
        TypeSample(int x, int y, int z)
        {
            coordinates.x = x;
            coordinates.y = y;
            coordinates.z = z;
        }

        private struct Coordinates
        {
            public int x;
            public int y;
            public int z;
        }

        private Coordinates coordinates;

        public void AddCoordinates()
        {
            int hashCode = GetHashCode();
            lock (this)
            {
                Coordinates tempCoord;
                tempCoord.x = coordinates.x + 100;
                tempCoord.y = coordinates.y + 50;
                tempCoord.z = coordinates.z + 100;

                System.Console.WriteLine("x={0}, y={1}, z={2}", tempCoord.x, tempCoord.y, tempCoord.z);
            }
        }

        static void Main(string[] args)
        {
            TypeSample sample = new TypeSample(10,5,10);
            sample.AddCoordinates();
        }
    }
}
