// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //createUser();
            //createPerson("John", 20);
            //createPerson("Bill", 21);
            GC.Collect();
           ;
            Person user = new Person();
            Person person  = new Person("John", 20);
            person.Print();
            Person person2 = new Person("Bill", 21);
            person2.Print();
            Console.ReadLine();
            var anInstanceofMyClass = new Program();
            anInstanceofMyClass.A(person);
            anInstanceofMyClass.B();
        }
        /*public static void createPerson(string name, int age)
        {
            Person person  = new Person();
            person.Name = name;
            person.Age = age;
            person.Print();

        }
        public static void createUser()
        {
            Person user = new Person();
        }*/
        public async void A (Person person)
        {

            using (FileStream fs = new FileStream(@"C:\FILE\user.json", FileMode.OpenOrCreate))
            {
                // Person tom = new Person("Tom", 37);
                await JsonSerializer.SerializeAsync<Person>(fs, person);
                Console.WriteLine("Data has been saved to file");
            }
        }
        public async void B ()
        {
            using (FileStream fs1 = new FileStream(@"C:\FILE\user2.json", FileMode.OpenOrCreate))
            {
                Person? person = await JsonSerializer.DeserializeAsync<Person>(fs1);
                //Console.WriteLine($"Name: {person?.Name}  Age: {person?.Age}");
                //createPerson(person?.Name, (int)(person?.Age));
                Person person3 = new Person(person.Name, person.Age);
                person3.Print();
            }
        }
    }


    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person()
        {
            Console.WriteLine("User created");
        }
        public Person(string N, int A)
        {
            Name = N;
            Age = A;
        }
        public void Print()
        {
            Console.WriteLine($"Name: {Name}  Age: {Age}");
        }
        ~Person()
        {
            Console.WriteLine("User deleted");
        }

    }
    
}


