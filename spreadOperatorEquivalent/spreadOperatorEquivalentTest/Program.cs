using System;
using spreadOperatorEquivalent;
namespace spreadOperatorEquivalentTest
{

    /// <summary>
    /// Tests with private fields and filling different attributes
    /// </summary>
    class Program
    {
        public class Person
        {
            public int? age { get; set; }
            public string name { get; set; }

            public Person(int? age,  string name)
            {
                this.age = age;
                this.name = name;
            }
            public Person()
            {

            }
        }
        static void Main(string[] args)
        {

            // TEST 1
            // First object has values, second is null
            //output name: George age: 10
            Person person1 = new Person(10, "George");
            Person person2 = new Person();
            person1 = SpreadEquivalent.spread<Person>(person1, person2);
            Console.WriteLine("name: {0}, age: {1}",person1.name, person1.age);

            // TEST 2
            // First object is null, second is full
            //output name: George age: 10
            Person person3 = new Person();
            Person person4 = new Person(10, "George"); 
            person3 = SpreadEquivalent.spread(person3, person4);
            Console.WriteLine("name: {0}, age: {1}", person3.name, person3.age);

            // TEST 3
            // First object is full, second is only one atributte full
            //output name: George age: 20
            Person person5 = new Person(10, "George");
            Person person6 = new Person(20, null); 
            person5 = SpreadEquivalent.spread(person5, person6);
            Console.WriteLine("name: {0}, age: {1}", person5.name, person5.age);


            // TEST 4
            // First object has only one attribute initialized, second is null
            //output name: George age: no output
            Person person7 = new Person(null, "George");
            Person person8 = new Person(null, null);
            person7 = SpreadEquivalent.spread(person7, person8);
            Console.WriteLine("name: {0}, age: {1}", person7.name, person7.age);

            // TEST 5
            // Both are full
            //output name: Mathew age: 25
            Person person9 = new Person(10, "George");
            Person person10 = new Person(25, "Mathew");
            person9 = SpreadEquivalent.spread<Person>(person9, person10);
            Console.WriteLine("name: {0}, age: {1}", person9.name, person9.age);

            Console.ReadLine();

        }

      
    }
}
