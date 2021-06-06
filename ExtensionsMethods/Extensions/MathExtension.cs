using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionsMethods.Extensions
{
    public static class MathExtension
    {

        //public static string RecommendedUsername(this string Name, string userName)
        //{
        //    List<User> user = new List<User>()
        //    {
        //        new User(){userName="mustafa" },
        //        new User(){userName="mustafa1" },
        //        new User(){userName="mustafa2" }, //Örneğin veritabanımızda kayıtlı bulunan userName'ler
        //        new User(){userName="mustafa3" },
        //        new User(){userName="mustafa4" }

        //    };
        //    string name = userName;
        //    Random random = new Random();
        //    foreach (var item in user)
        //    {
        //        // Kullanıcı tarafından girilen userName ve DB'de bulunan userName'ler karşılaştırılıyor ve aynısı bulunuyorsa alternatif bir userName oluşturuyor.
        //        //bulunmuyor ise Db'ye kaydediyor.
        //        if (name == item.userName)
        //        {
        //            string randomNumber = random.Next(1, 10).ToString();
        //            name = name + randomNumber;
        //        }

        //    }
        //    Console.Write("Veri Tabanında Bulunan Kullancı Adları: ");
        //    foreach (var item in user)
        //    {
        //        Console.Write(item.userName + " ");
        //    }
        //    user.Add(new User()
        //    {
        //        userName = name
        //    });

        //    return name;
        //}


        public static string encryptionMethod(this string Text, string text, int encryption)
        {
            string encryptionText = "";
            char[] characters = text.ToCharArray();  
            foreach (char character in characters)   
            {
                if (character == ' ')
                {
                    encryptionText += " ";          
                    continue;
                }
                else if (Char.IsUpper(character))
                {
                    encryptionText += Convert.ToChar(((character - 65 + encryption) % 26 + 65)).ToString();
                }
                else
                {
                    encryptionText += Convert.ToChar(((character - 97 + encryption) % 26 + 97)).ToString();
                }

            }
            return encryptionText;
        }
        public static string decryptionMethod(this string text, string encryptedtext, int encryption)
        {
            int a;
            int calc;

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
                    calc = a.AsciiCalculate(character, 65 - encryption);
                    decryptiontext += Convert.ToChar((calc % 26) + 65).ToString();
                }
                else
                {
                    calc = a.AsciiCalculate(character, 97 - encryption);
                    decryptiontext += Convert.ToChar((calc % 26) + 97).ToString();
                }
            }
            return decryptiontext;

        }
        public static int AsciiCalculate(this int Calc, char character, int c, int encryption)
        {
            int asciiCalculate = (character - c - encryption);
            if (asciiCalculate < 0)
            {
                asciiCalculate += 26;
            }
            return asciiCalculate;
        }

    }
}
