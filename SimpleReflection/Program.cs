
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SimpleReflection
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // in this project 

            //Type SomeDllType = Type.GetType("SimpleReflection.Entity.User", false, true);

            //Console.WriteLine(SomeDllType);

            //foreach(PropertyInfo prop in SomeDllType.GetProperties())
            //{
            //    Console.WriteLine(prop);
            //}



            // in ReflectionApp project
            //Assembly asm = Assembly.LoadFrom("ReflectionApp.dll");

            //Console.WriteLine(asm.FullName);

            //Type[] types = asm.GetTypes();
            //Type type = asm.GetType();
            //foreach (Type t in types)
            //{
            //    Console.WriteLine(t);
            //}
            //foreach (PropertyInfo prop in type.GetRuntimeProperties())
            //{
            //    Console.WriteLine(prop);
            //}

            Assembly asm = Assembly.LoadFrom("SomeDll.dll");
            string path = @"C:\Users\rperebeinos\source\repos\SimpleReflectionApp\SimpleReflection\bin\Debug\netcoreapp3.1\PropertiesInfo.txt";
            Console.WriteLine(asm.FullName);
            Type[] types = asm.GetTypes();
            foreach (Type t in types)
            {
                Console.WriteLine(t);
            }
            Type type = types.Where(t => t.FullName == "SomeDll.Person").FirstOrDefault();
            
            StringBuilder sb = new StringBuilder("Properties of Person:");
            foreach (PropertyInfo prop in type.GetRuntimeProperties())
            {
               Console.WriteLine(prop);
                sb.Append($"\n{prop}");
            }
            await Write(path, sb.ToString());
            Console.WriteLine("Writing done");
            Console.ReadKey();
        }

        async static Task Write(string patth, string text)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(patth, false, System.Text.Encoding.Default))
                {
                    await sw.WriteLineAsync(text);
                }
               
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
