using System;
using System.Reflection;
using System.Text;

namespace Advanced.NET.Debugging.Chapter4
{

    class SimpleType
    {
        private int field1;
        private int field2;

        public int Field1
        {
            get { return field1; }
        }

        public int Field2
        {
            get { return field2; }
        }

        public SimpleType()
        {
            field1 = 10;
            field2 = 5;
        }
    }

    class TypeCast
    {
        static void Main(string[] args)
        {
            Assembly asmLoadFromContext = null;

            Console.WriteLine("Press any key to load into load from context");
            Console.ReadKey();

            asmLoadFromContext = Assembly.LoadFrom("04assembly.dll");

            SimpleType s = (SimpleType)asmLoadFromContext.CreateInstance(
                                "Advanced.NET.Debugging.Chapter4.SimpleType");

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
