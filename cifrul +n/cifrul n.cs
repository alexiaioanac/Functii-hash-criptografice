using System;
using System.Collections.Generic;
using System.Text;

namespace cifrul_n
{
    internal static class cifrul_n
    {
        
        private static string alphabet = "abcdefghijklmnopqrstuvwxyz";

        public static string Encrypt(string plain, int n)
        {
            if (string.IsNullOrWhiteSpace(plain)) return plain;
            StringBuilder sb = new StringBuilder();

            foreach (char c in plain)
            {
                if (char.IsLetter(c))
                {
                    char lowC = char.ToLower(c);
                    int currentIndex = alphabet.IndexOf(lowC);
                    int newIndex = (currentIndex + n) % 26;
                    char processed = alphabet[newIndex];
                    sb.Append(char.IsUpper(c) ? char.ToUpper(processed) : processed);
                }
                else sb.Append(c); 
            }
            return sb.ToString();
        }

        public static string Decrypt(string cipher, int n)
        {
            return Encrypt(cipher, (26 - n) % 26);
        }

        public static string BruteForce(string cipher)
        {
            StringBuilder results = new StringBuilder();
            for (int n = 0; n < 26; n++)
            {
                string attempt = Decrypt(cipher, n);
                results.AppendLine($"Cheia n={n}: {attempt}");
            }
            return results.ToString();
        }
    }
}
