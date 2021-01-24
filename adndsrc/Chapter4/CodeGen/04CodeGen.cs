using System;
using System.Text;
using System.Reflection.Emit;

namespace Advanced.NET.Debugging.Chapter4
{
    class CodeGen
    {
        private delegate int Add(int a, int b);

        public static void Main()
        {
            Type[] args={typeof(int), typeof(int)};
            DynamicMethod dyn = new 
                DynamicMethod("Add", 
                              typeof(int), 
                              new Type[] { typeof(int), typeof(int) }, 
                              typeof(CodeGen), 
                              true);
            ILGenerator gen = dyn.GetILGenerator();
            gen.Emit(OpCodes.Ldarg_1);
            gen.Emit(OpCodes.Ldarg_2);
            gen.Emit(OpCodes.Add);
            gen.Emit(OpCodes.Ret);

            Add a= (Add) dyn.CreateDelegate(typeof(Add));
            Console.WriteLine("Press any key to invoke Add method");
            Console.ReadKey();
            int ret = a(1, 2);
            Console.WriteLine("1+2={0}", ret);
        }
    }
}
