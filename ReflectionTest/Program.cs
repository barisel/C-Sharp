using ReflectionTest.CreatingInstance;
using System;
using System.Reflection;

namespace ReflectionTest
{
    class Program
    {
        static void Main(string[] args) {
            ActivatorManager.CreateInstance<UserManager>();
            ActivatorManager.CreateInstanceWithConst<UserManager>();
            var userList = ActivatorManager.CreateInstanceGenericList<UserManager>();
            var user = ActivatorManager.GetInstance<UserManager>();
            var user2 = ActivatorManager.GetInstanceConst<UserManager>();

            // GetInstanceWithGenericConstructer
            Family family = new Family { FatherName = "zafer", MotherName = "ayse" };
            var user3 = ActivatorManager.GetInstanceWithGenericConstructer<UserManager, Family>(family);

            // 
            var factory = new GenericFactory<string, UserManager>(); 
            factory.Register("key", typeof(Family));
            UserManager newInstance = factory.Create("key", family);
        }
    }
}
