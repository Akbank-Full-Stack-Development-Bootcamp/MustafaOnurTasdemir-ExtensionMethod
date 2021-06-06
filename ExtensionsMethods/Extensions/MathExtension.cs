using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionsMethods.Extensions
{
    public static class MathExtension
    {

        public static string RecommendedUsername(this string Name, string userName)
        {
            List<User> user = new List<User>()
            {
                new User(){userName="mustafa" },
                new User(){userName="mustafa1" },
                new User(){userName="mustafa2" }, //Örneğin veritabanımızda kayıtlı bulunan userName'ler
                new User(){userName="mustafa3" },
                new User(){userName="mustafa4" }

            };
            string name = userName;
            Random random = new Random();
            foreach (var item in user)
            {
                // Kullanıcı tarafından girilen userName ve DB'de bulunan userName'ler karşılaştırılıyor ve aynısı bulunuyorsa alternatif bir userName oluşturuyor.
                //bulunmuyor ise Db'ye kaydediyor.
                if (name == item.userName)
                {
                    string randomNumber = random.Next(1, 10).ToString();
                    name = name + randomNumber;
                }

            }
            Console.Write("Veri Tabanında Bulunan Kullancı Adları: ");
            foreach (var item in user)
            {
                Console.Write(item.userName + " ");
            }
            user.Add(new User()
            {
                userName = name
            });

            return name;
        }


        public static string encryptionMethod(this string Text, string text, int encryption)
        {
            string encryptionText = "";
            char[] characters = text.ToCharArray(); 
            //Kullanıcıdan alınan metin, karakterlerine ayrılıyor ve tek tek içerisinde geziliyor.
            foreach (char character in characters)   
            {
                if (character == ' ')
                {
                    //Karakter ' '(boşluk) ise şifrelenmiş metin olarak  olusturulan stringe " " olarak eklenir.
                    encryptionText += " ";          
                }
                else if (Char.IsUpper(character))
                {

                    //Karakterimiz buyuk harflerden olusmussa bu islem yapılır. Ascii tablosunda degerlere göre, kullanıcı 2 birim oteleyerek sifrelemek isterse,
                    //'C' degeri 'E' degeri olur.
                    encryptionText += Convert.ToChar(((character - 65 + encryption) % 26 + 65)).ToString();
                }
                else
                {
                    //Karakterimiz kucuk harflerden olusmussa bu islem yapılır. Ascii tablosunda degerlere göre, kullanıcı 2 birim oteleyerek sifrelemek isterse,
                    //'c' degeri 'e' degeri olur.
                    encryptionText += Convert.ToChar(((character - 97 + encryption) % 26 + 97)).ToString();
                }

            }
            return encryptionText;
        }
        public static string decryptionMethod(this string text, string encryptedtext, int encryption)
        {
            int a=0;
            int calculate;
            string decryptiontext = "";
            char[] characters = encryptedtext.ToCharArray();
            foreach (var character in characters)
            {
                if (character == ' ')
                {
                    decryptiontext += " ";
                    continue;
                }
                else if (char.IsUpper(character))
                { 
                    calculate = a.AsciiCalculate(character, 65 , encryption);
                    decryptiontext += Convert.ToChar((calculate % 26) + 65).ToString();
                }
                else
                {
                    calculate = a.AsciiCalculate(character, 97,encryption);
                    decryptiontext += Convert.ToChar((calculate % 26) + 97).ToString();
                }
            }
            return decryptiontext;

        }
        public static int AsciiCalculate(this int Calc, char character, int c, int encryption)
        {
            //Sifrelenmis metni cozmek istedigimiz ise encryption degeri, yani otelemek istenilen degeri cıkarttıgımız, metnin orjinalini elde ederiz.
            // AsciiCalculate fonksiyonunda aynı islem yapılmıs, bir yeri degistirilmistir. islem negatif dondugunde mod alma islemi uygulandıgında negatif deger donuyor
            //Bu da alfabe degerleri dısında farklı degerlere ulasıyor, hata yaratıyor.
            int asciiCalculate = (character - c - encryption);
            if (asciiCalculate < 0)
            {
                asciiCalculate += 26;
            }
            return asciiCalculate;
        }

    }
}
