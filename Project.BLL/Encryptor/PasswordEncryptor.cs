using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sifrelemeler.Models
{
    public static class PasswordEncryptor
    {
        const string sabitString = "DOUBLEH"; // Eklemek istediğiniz string
        static int[] eklenecekIndexler = { 0, 3, 5, 7, 9, 12,14 }; // Eklenilecek indeksler

        /// <summary>
        /// Bir metni Base64 formatında kodlar, ters çevirir ve belirtilen indekslere özel string ekler.
        /// </summary>
        /// <param name="input">Kodlanacak metin.</param>
        /// <returns>Özel indeks eklenmiş ve ters çevrilmiş Base64 kodlu metin.</returns>
        public static string Encode(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new Exception("Girdi boş olamaz.");

            // Base64 encode
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            string base64Encoded = Convert.ToBase64String(inputBytes);

            // Base64 string ters çevir
            string reversedBase64 = IfadeyiTersCevir(base64Encoded);

            // Ters çevrilmiş stringe belirtilen indekslere sabitString'i ekle
            StringBuilder modifiedString = new StringBuilder(reversedBase64);
            for (int i = 0; i < eklenecekIndexler.Length; i++)
            {
                int index = eklenecekIndexler[i];
                if (index <= modifiedString.Length)
                {
                    modifiedString.Insert(index, sabitString[i]);
                }
            }

            return modifiedString.ToString();
        }

        /// <summary>
        /// Özel indekslere eklenmiş ve ters çevrilmiş Base64 formatındaki bir metni çözer.
        /// </summary>
        /// <param name="encodedInput">Şifrelenmiş metin.</param>
        /// <returns>Orijinal metin.</returns>
        public static string Decode(string encodedInput)
        {
            if (string.IsNullOrEmpty(encodedInput))
                throw new Exception("Girdi boş olamaz.");

            // Belirtilen indekslerden sabitString karakterlerini çıkar
            StringBuilder cleanedString = new StringBuilder(encodedInput);
            for (int i = eklenecekIndexler.Length - 1; i >= 0; i--) // Ters sırada işlem yap
            {
                int index = eklenecekIndexler[i];
                if (index < cleanedString.Length)
                {
                    cleanedString.Remove(index, 1);
                }
            }

            // Ters çevir
            string reversedBase64 = cleanedString.ToString();
            string base64Original = IfadeyiTersCevir(reversedBase64);

            // Base64 çöz
            byte[] decodedBytes = Convert.FromBase64String(base64Original);
            return Encoding.UTF8.GetString(decodedBytes);
        }

        /// <summary>
        /// Bir metni ters çevirir.
        /// </summary>
        /// <param name="input">Ters çevrilecek metin.</param>
        /// <returns>Ters çevrilmiş metin.</returns>
        private static string IfadeyiTersCevir(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

    }
}
