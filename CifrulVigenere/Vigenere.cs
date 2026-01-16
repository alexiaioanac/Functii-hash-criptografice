using System;
using System.Collections.Generic;
using System.Text;

namespace CifrulVigenere
{
    internal static class Vigenere
    {
        private static string original = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private static string[] alfabete = {
            "FRQSPYMHNJOELKDVAGXTIWBUZC", 
            "SWZCINJTELAFQUMKPXDOVBRGHY", 
            "CITYWLNZEVOMQGUPJFXBRAHSKD"  
        };

        public static string Encrypt(string plain)
        {
            if (string.IsNullOrWhiteSpace(plain)) return plain;
            StringBuilder sb = new StringBuilder();
            plain = plain.ToUpper();

            int indexAlfabet = 0;
            foreach (char c in plain)
            {
                int pozitie = original.IndexOf(c);
                if (pozitie != -1)
                {
                    string alfabetCurent = alfabete[indexAlfabet % 3];
                    sb.Append(alfabetCurent[pozitie]);
                    indexAlfabet++; 
                }
                else sb.Append(c);
            }
            return sb.ToString();
        }

        public static string Decrypt(string cipher)
        {
            if (string.IsNullOrWhiteSpace(cipher)) return cipher;
            StringBuilder sb = new StringBuilder();
            cipher = cipher.ToUpper();

            int indexAlfabet = 0;
            foreach (char c in cipher)
            {
                string alfabetCurent = alfabete[indexAlfabet % 3];
                int pozitieInAlfabetCurent = alfabetCurent.IndexOf(c);

                if (pozitieInAlfabetCurent != -1)
                {
                    sb.Append(original[pozitieInAlfabetCurent]);
                    indexAlfabet++;
                }
                else sb.Append(c);
            }
            return sb.ToString();
        }
    }
}
