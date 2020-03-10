using System;
using System.Collections.Generic;
using System.Text;

namespace SomeDll
{
  public  class Person
    {
        public string Name { get; set; }

        public short Age { get; set; }

        public string Mail { get; set; }

        public Person(string n, short a, string m)
        {
            Name = n;
            Age = a;
            Mail = m;
        }
        public void Display()
        {
            Console.WriteLine($"Name: {Name} Age: {Age} Mail: {Mail}");
        }
    }
}
