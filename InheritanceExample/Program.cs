using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******Inheritance Example**************");
            Person[] persons = new Person[] {
                new Student
                {
                    Name = "Student Name"
                } ,new Person
                {
                    Name = "Person Name"
                }, new Customer
                {
                    Name = "Customer Name"
                }     // Person classı tek başına bir anlam ifade eder abstract ve interface gibi değildir o yüzden instance ' ı oluşturulabilir.
            };

            foreach (var person in persons)
            {
                Console.WriteLine(person.Name);
            }
            Console.WriteLine("******Inheritance Example**************");
            Console.ReadLine();
        }
    }

    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class Customer : Person        
    {
        public string City { get; set; }
    }

    class Student : Person
    {
        public int Grade { get; set; }
    }

    /* Bir sınıfın bir ana sınıfı olur interface de birden fazla sınıftan implemente edilebiliyordu fakat inheritance da bir tane sınıf implement edilebilir
     * class Student : Person, Person2  kullanımı yanlıştır.
     */
}
