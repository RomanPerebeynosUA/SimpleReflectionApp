using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionApp
{ 
    class Program
    {
        static async Task Main(string[] args)
        {
            string path = @"C:\Users\rperebeinos\source\repos\SimpleReflectionApp\ReflectionApp\bin\Debug\netcoreapp3.1\PropertiesInfo.csv";
            
            List<Type> listTypes = new List<Type>();

            listTypes.Add(Type.GetType("SomeDll.Company, SomeDll", true, true));
            listTypes.Add(Type.GetType("SomeDll.Person, SomeDll", true, true));

            await WriteListPropertiesToCsv(listTypes, path);
            Console.WriteLine("Writing done");
            Console.ReadKey();
        }

        async static Task WriteListPropertiesToCsv(IEnumerable<Type> list , string path)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Type item in list)
            {
                sb.Append($"Properties of {item.Name}");
                foreach (PropertyInfo prop in item.GetRuntimeProperties())
                {
                    Console.WriteLine(prop);
                    sb.Append($"\n{prop}");
                }
                sb.Append("\n");
            }
            try
            {
                using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                {
                    await sw.WriteLineAsync(sb.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
