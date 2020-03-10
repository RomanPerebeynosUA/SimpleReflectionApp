using System;
using System.Collections.Generic;
using System.Text;

namespace SomeDll
{
   public class Company
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }

        public Company(string n, string a, string p, string m)
        {
            Name = n;
            Address = a;
            Phone = p;
            Mail = m;
        }
        public void Display()
        {
            Console.WriteLine($"Name: {Name} Address: {Address}  " +
                $"Phone: {Phone} Mail: {Mail}");
        }
    }
}
