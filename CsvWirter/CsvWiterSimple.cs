using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CsvWirter
{
    public static class CsvWiterSimple<T>
    {
        public static async Task WriteToCsvFile(IEnumerable<T> list, string path)
        {
            StringBuilder sb = new StringBuilder();
            int count = 0;
            Type t = typeof(T);
            foreach (T item in list)
            {
                foreach (PropertyInfo prop in t.GetRuntimeProperties())
                {
                    if (count < 1)
                    {
                        Console.WriteLine(prop);
                        sb.Append($"{prop};");
                    }
                }
                sb.AppendLine();
                foreach (PropertyInfo prop in t.GetRuntimeProperties())
                {
                    Console.WriteLine(prop.GetValue(item));
                    sb.Append($"{prop.GetValue(item)};");
                }
                count++;
            }
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
