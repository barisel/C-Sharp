## C# nedir?
C# .net framework üzerinde çok fazla çeşide sahip olan, güçlü, güvenli, tip güvenli ve zarif bir nesne yönelimli programlama dilir.

## .Net framework
Kısaca Microsoft tarafından geliştirilen bir uygulama geliştirme platformu diyebiliriz. 
Uygulamadan kastımız ise bir masaüstü projesinden bir web projesine bir sistem kütüphanesinden donanım kontrole 
kadar çoğu işimizi yapabileceğimiz bir ortamdır. Aynı zamanda kodun makina diline çevirilmesi aşamsındaki,
Tüm işlemlerden sorumludur.

### Common Language Runtime (CLR)
.Net ile çalışan uygulamalarınn yürütülmesinden sorumlu olan ara katmandır.
Farklı dillerde yazılan uygulamaları sorunsuz bir şekilde çalıştırır.


### MSIL(Microsoft İntermediate Language)

Microsoft .Net teknolojisi için bir ara dil görevi üstlenmektedir. 
.Net teknolojisinde ki bütün diller MSIL ile ara bir dile dönüştürüldükten sonra işlemlere devam eder. 
Bunun sebebi ise örneğin herhangi başka bir dil ile yazdığımız kütüphaneleri başka 
bir programlama dilinde veya farklı bir uygulamada kullanabiliriz. En büyük örnek ise DLL’lerdir.
Bizim bu platformumuza ait birkaç olayımız daha var ama detaya daha fazla girmek istemiyorum. 
Merak eden arkadaşlarımız için bunlara extra olarak JIT derleyicilerini CLR’nin yaptığı 
bütün işlerin ayrıntılarını inceleyebilirler.