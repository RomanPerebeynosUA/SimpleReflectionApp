using CsvWirter;
using SomeDll;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionApp
{ 
    class Program
    {
        static async Task Main(string[] args)
        {
            string path = @"D:\temp\test\PropertiesInfo.csv";
            List<Person> personList = new List<Person>()
            {
                new Person
                {
                    Name = "Bob",
                    Age = 18,
                    Mail = "someBob@mail.com"
                },
                      new Person
                {
                    Name = "Alisa",
                    Age = 20,
                    Mail = "someAlisa@mail.com"
                },
            };

           
 
           await personList.WritePropertiesToCsv(path);
            

           // await CsvWiterSimple<Person>.WriteToCsvFile(personList, path);
            Console.ReadKey();

            //List<Type> listTypes = new List<Type>();
            //listTypes.Add(Type.GetType("SomeDll.Company, SomeDll", true, true));
            //listTypes.Add(Type.GetType("SomeDll.Person, SomeDll", true, true));
            //await WriteListPropertiesToCsv(listTypes, path);
            //Console.WriteLine("Writing done");
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
