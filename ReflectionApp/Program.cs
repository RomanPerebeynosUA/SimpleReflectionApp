using System;

namespace ReflectionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User("Roman", 20, "some@mail.com");
            user.Display();
            Type myType = user.GetType();
            Console.WriteLine(myType);
            Console.ReadKey();

        }
    }
    class User
    {
        public string Name { get; set; }

        public short Age { get; set; }

        public string Mail { get; set; }

        public User(string n, short a, string m)
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
