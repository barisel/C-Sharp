using System;
using System.Collections.Generic;

namespace ReflectionTest.CreatingInstance
{
    public class UserManager {
        public string Name { get; set; }
        public int Age { get; set; }
        public Family Family { get; set; }

        public UserManager() {

        }

        public UserManager(Family family) {
            Family = family;
        }

        public UserManager(int age) {
            Age = age;
        }

        public UserManager(string name) {
            Name = name;
        }

        public void Add(string name, string department) {
            Console.WriteLine($"{name} added.");
        }
    }

    public class Family {
        public string FatherName { get; set; }
        public string MotherName { get; set; }
    }
}