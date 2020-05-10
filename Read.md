# Reflection (Yansıma)

## Vieving Type İnformation ( Tip bilgilerini görüntüleme )

> mscorlib kütüphanesine bağlı tüm assembly leri getirir.
```c#
	Assembly a = typeof(object).Module.Assembly;
```


> Yüklemek istediğimiz assembly ismini veririz.
```c#
	Assembly b = Assembly.LoadFrom(@"C:\Users\barisel\Desktop\Documents\Training\DotNetCoreWebApi\Northwind\Northwind.DataAccess\bin\Debug\netstandard2.0\Northwind.Entities.dll");
```

## Reflection method işlemleri

> Public ve static olan bir methodu çağırmak.

```c#
	var method = typeof(Program).GetMethod("HelloWord");
	method.Invoke(null, null);
```

> Private ve statik bir methodu çağırmak.
```c#
	MethodInfo method = typeof(Program).GetMethod("HelloWord", BindingFlags.NonPublic | BindingFlags.Static);
	method.Invoke(null, null);
```

> Statik olmayan bir public methodu çağırmak. Instance ile

```c#
	MethodInfo method = typeof(ReflectionTestClass).GetMethod("HelloWord");
	ReflectionTestClass program = new ReflectionTestClass();
	method.Invoke(program, null);
```

> Instance ile private bir method çağırmak.
```c#
	MethodInfo method = typeof(ReflectionTestClass)
		.GetMethod("HelloWord", BindingFlags.NonPublic
		| BindingFlags.Instance);

	ReflectionTestClass instance = new ReflectionTestClass();
	method.Invoke(instance, null);
```

> Parametre alan bir methodu çağırmak.
```c#
	MethodInfo method = typeof(TestClass).GetMethod("HelloWord");
	object[] arg = new object[] { "Baris" };
	TestClass testClass = new TestClass();
	method.Invoke(testClass, arg);
```

> Birden fazla parametre alan fonksiyonu çağırmak.
```c#
	Type type = typeof(TestClass);
	object[] valueArgs = new object[] { 10, "Barış" };
	string[] nameArgs = new string[] { "age", "name" };
	TestClass test = new TestClass();
	type.InvokeMember(
		"HelloWord",
		BindingFlags.InvokeMethod,
		null,
		test,
		valueArgs,
		null,
		null,
		nameArgs
		);
```

> Bir sınıf içerisindeki elemanları getirme.

```c#
	var members = typeof(object).GetMembers(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
    foreach (var member in members) {
        bool inherited = member.DeclaringType.Equals(typeof(object).Name);
        Console.WriteLine($"{member.Name} is a {member.MemberType}, " + $"it has {(inherited ? "" : "not")} been inherited.");
    }


## Creating an instance of a Type (Bir tipin nesne örneğini oluşturma)


```
```c#
```
```c#
```