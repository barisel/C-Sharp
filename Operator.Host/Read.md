# Operators

## Overloadable Operators (Aşırı yüklenebilir operatörler)
Bu operatörler ile referans tiplerimizi de aşağıdaki örnekteki gibi toplayabiliriz.
> Static olmak zorundadırlar ve  +, -, /, * operatörleri için kullanılabilir.

```c#
	class Program {
		static void Main(string[] args) {
			Complex a = new Complex() { Real = 1, Imaginary = 2 }; 
			Complex b = new Complex() { Real = 4, Imaginary = 8 }; 
			Complex c = a + b; // output 5 , 10
		}
	}

	public struct Complex { 
		public double Real { get; set; } 
		public double Imaginary { get; set; }

		public static Complex operator +(Complex c1, Complex c2) { 
			return new Complex { 
				Real = c1.Real + c2.Real, 
				Imaginary = c1.Imaginary + c2.Imaginary 
			}; 
		}
	}

```

## Overloading equality operator ( Aşırı yüklenme eşitlik operatörü)

operator == ifadesi ile objelerimiz için eşitlik kontrolü yapabiliriz.
Aynı zamanda IEquatable ile de eşitlik kontrolü yapabiliyoruz.
Hash değerini de unique bir referans alan üzerinden gerçekleştirmeliyiz. Bu nedenle bunu ezdik.
Eğer referans türü olan bir alan üzerinden gerçekleştirmezsek hash değerleri farklı olacaktır.
Bu yapı genelde dictionary deki key değeri için kullanılır. Oluşturulan aynı değer türleri için tekrardan değer eklenemez.

```c#
	class Student : IEquatable<Student> {
        public string Name { get; set; }

        public bool Equals(Student other) {
            if (ReferenceEquals(other, null))
                return false;
            if (ReferenceEquals(other, this))
                return true; 
            return string.Equals(Name, other.Name);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) 
                return false; 
            if (ReferenceEquals(this, obj)) 
                return true;
            return Equals(obj as Student);
        }

        public override int GetHashCode() { 
            return Name?.GetHashCode() ?? 0; 
        }

        public static bool operator ==(Student left, Student right) {
            return Equals(left, right);
        }

        public static bool operator !=(Student left, Student right) {
            return !Equals(left, right);
        }
    }

```