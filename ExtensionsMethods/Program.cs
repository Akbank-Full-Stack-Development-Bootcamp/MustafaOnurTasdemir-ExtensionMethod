using ExtensionsMethods.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtensionsMethods
{
    class Program
    {
        private static string userName;

        static void Main(string[] args)
        {
            Console.WriteLine("*******Kullanıcı Adı Önerme******");
            //Önerilen kullanıcı adı : Kullanıcı tarafından girilen ama örneğin veritabanında kayıtlı olan userName'e alternatif olarak bir öneride bulunmak.

            Console.Write("Kullanıcı Tarafından Girilen Kullanıcı Adı: ");
            string userName = Console.ReadLine();
            string availableUsername = userName.RecommendedUsername(userName);
            Console.WriteLine(" ");
            Console.WriteLine("Önerilen Kullanıcı Adı: " + availableUsername);

            Console.WriteLine("");

            Console.WriteLine("**********Sezar Şifreleme Yöntemi*******");
            // Sezar Şifreleme : kullanıcı tarafından girilen metin ve anahtar vardır. Bu anahtara göre metin şifrelenir.
            //Anahtar değeri kadar metinde bulunan harfler ötelenir. Örneğin anahtar değerimiz 2, 'a' harfi 'c' olacaktır.

            Console.Write("lütfen türkçe karakter olmayan bir metin giriniz: ");
            string text = Console.ReadLine();

            Console.Write("şifreleme yöntemi: ");
            int encryption = Convert.ToInt32(Console.ReadLine());

            string encryptedtext = text.encryptionMethod(text, encryption);
            Console.WriteLine("sezar şifrelemesi uygulanmış metin:" + encryptedtext);

            string decryptedtext = text.decryptionMethod(encryptedtext, encryption);
            Console.WriteLine("şifrelenmiş metnin çözülmüş hali:" + decryptedtext);


        }
    }
    
}
