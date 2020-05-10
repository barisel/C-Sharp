using System;
using System.Collections.Generic;
using System.Reflection;

namespace ReflectionTest.CreatingInstance
{
    public class ActivatorManager
    {
        // Parametresiz constructer için nesnenin örneğini oluşturalım.
        public static void CreateInstance<T>()
        {
            Type type = typeof(T);
            object result = Activator.CreateInstance(type);
        }

        // Parametreli constructer için;
        public static void CreateInstanceWithConst<T>()
        {
            Type type = typeof(T);
            object result = Activator.CreateInstance(type, new object[] { 10 });
        }

        // List için generic bir instanse oluşturduk.
        public static IEnumerable<T> CreateInstanceGenericList<T>()
        {
            Type openType = typeof(List<>);
            Type[] types = { typeof(T) };
            Type target = openType.MakeGenericType(types);
            List<T> result = (List<T>)Activator.CreateInstance(target);
            return result;
        }

        // Newlenebilir generic bir instance oluşturduk.
        public static T GetInstance<T>() where T : new() {
            T instance = new T(); 
            return instance; 
        }

        // .GetConstructor methodu ile constructorında string olanı arıyoruz. 
        public static T GetInstanceConst<T>() {
            ConstructorInfo c = typeof(T).GetConstructor(new[] { typeof(string) });
            // String değeri yok ise burda hata vericektir.
            if (c == null) 
                throw new InvalidOperationException(string.Format("A constructor for type '{0}' was not found.", typeof(T))); 
            T instance = (T)c.Invoke(new object[] { "test" });
            return instance;
        }

        // Burada ise generic constructor inject ettik.
        public static T GetInstanceWithGenericConstructer<T,TCon>(TCon genericConstructer) {
            ConstructorInfo c = typeof(T).GetConstructor(new[] { typeof(TCon) });
            // String değeri yok ise burda hata vericektir.
            if (c == null)
                throw new InvalidOperationException(string.Format("A constructor for type '{0}' was not found.", typeof(T)));
            T instance = (T)c.Invoke(new object[] { genericConstructer });
            return instance;
        }
    }
}