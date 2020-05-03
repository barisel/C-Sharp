## unsafe
Kodumuzun Compile Time da patlamamasını sağlar. Ancak bu yüzden runtime da patlayabiliriz.
Ancak bu sayede c++ c daki pointerları kullanabilir ve bellek yönetimi bellek sorgulama işlemlerini yapabiliriz.
Değer tipli bir structın boyutunu da öğrenebiliriz.

unsafe {
    size = sizeof(Struct);
}

unsafe class Sınıf {
     unsafe char *ptr;
}