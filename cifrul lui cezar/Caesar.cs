using System;
using System.Collections.Generic;
using System.Text;

namespace cifrul_lui_cezar
{
    internal static class Caesar
    {
        private static int key = 3;
        private static int mod = 26;

        private static Dictionary<char, char> cipherMap = new Dictionary<char, char>();
        private static Dictionary<char, char> decipherMap = new Dictionary<char, char>();

        static Caesar()
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            for (int i = 0; i < mod; i++)
            {
                char original = alphabet[i];
                char encrypted = alphabet[(i + key) % mod];

                cipherMap.Add(original, encrypted);
                decipherMap.Add(encrypted, original);
            }
        }

        public static string Encrypt(string plain)
        {
            if (string.IsNullOrWhiteSpace(plain)) return plain;
            StringBuilder sb = new StringBuilder();

            foreach (char c in plain)
            {
                char lowC = char.ToLower(c);
                if (cipherMap.ContainsKey(lowC))
                {
                    char mapped = cipherMap[lowC];
                    sb.Append(char.IsUpper(c) ? char.ToUpper(mapped) : mapped);
                }
                else
                {
                    sb.Append(c); 
                }
            }
            return sb.ToString();
        }

        public static string Decrypt(string cipher)
        {
            if (string.IsNullOrWhiteSpace(cipher)) return cipher;
            StringBuilder sb = new StringBuilder();

            foreach (char c in cipher)
            {
                char lowC = char.ToLower(c);
                if (decipherMap.ContainsKey(lowC))
                {
                    char mapped = decipherMap[lowC];
                    sb.Append(char.IsUpper(c) ? char.ToUpper(mapped) : mapped);
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

       
            public static string BruteForce(string cipher)
        {
            StringBuilder results = new StringBuilder();
            string alphabet = "abcdefghijklmnopqrstuvwxyz";

            for (int k = 1; k < 26; k++)
            {
                StringBuilder attempt = new StringBuilder();
                foreach (char c in cipher)
                {
                    if (char.IsLetter(c))
                    {
                        char lowC = char.ToLower(c);
                        int currentIndex = alphabet.IndexOf(lowC);
                        int newIndex = (currentIndex - k + 26) % 26;
                        char processed = alphabet[newIndex];
                        attempt.Append(char.IsUpper(c) ? char.ToUpper(processed) : processed);
                    }
                    else
                    {
                        attempt.Append(c);
                    }
                }
                results.AppendLine($"Cheie {k}: {attempt}");
            }
            return results.ToString();
        }
    
    }
}
