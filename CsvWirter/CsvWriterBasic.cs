using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CsvWirter
{
    public static class  CsvWriterBasic
    {
        public static async Task WritePropertiesToCsv<T>(this IEnumerable<T> list, string path)
        {
            StringBuilder sb = new StringBuilder();
            Type t = typeof(T);
            var properties = t.GetRuntimeProperties();
          
            //header
            foreach (PropertyInfo prop in properties)
            {

                Console.WriteLine(prop);
                sb.Append($"{prop};");

            }
            //body
            foreach (T item in list)
            {
                sb.AppendLine();
                foreach (PropertyInfo prop in properties)
                {
                    Console.WriteLine(prop.GetValue(item));
                    sb.Append($"{prop.GetValue(item)};");
                }
            }
            //Writing to csvFile
            try
            {
                using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                {
                    await sw.WriteLineAsync(sb);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
