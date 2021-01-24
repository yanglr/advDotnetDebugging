using System;
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
}
