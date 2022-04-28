using System;
using System.Collections.Generic;
using System.Text;

namespace Version8
{
    public static class NullableReferenceTypes
    {
        public static void Test()
        {
            var person = new Person("a", "b", null);
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public Person(string first, string last, string middle) =>
            (FirstName, LastName, MiddleName) = (first, last, middle);
        public string FullName =>
            $"{FirstName} {MiddleName[0]} {LastName}";
    }
}
