using System;
using System.Collections.Generic;
using System.Text;

namespace Cifrul_Playfair
{
    internal static class Playfair
    {
        private static char[,] matrice = new char[5, 5];

        public static void GenereazaMatrice(string cheie)
        {
            string alfabet = "ABCDEFGHIKLMNOPQRSTUVWXYZ"; 
            string combinat = (cheie.ToUpper() + alfabet).Replace("J", "I");
            string final = "";

            foreach (char c in combinat)
                if (!final.Contains(c)) final += c;

            int k = 0;
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    matrice[i, j] = final[k++];
        }

        public static string Proceseaza(string text, bool criptare)
        {
            text = text.ToUpper().Replace("J", "I").Replace(" ", "");
            if (text.Length % 2 != 0) text += "X"; 

            StringBuilder rezultat = new StringBuilder();
            for (int i = 0; i < text.Length; i += 2)
            {
                char a = text[i];
                char b = text[i + 1];
                if (a == b) { b = 'X'; i--; } 

                int r1 = 0, c1 = 0, r2 = 0, c2 = 0;
                GasestePozitie(a, ref r1, ref c1);
                GasestePozitie(b, ref r2, ref c2);

                if (r1 == r2) 
                {
                    int d = criptare ? 1 : 4;
                    rezultat.Append(matrice[r1, (c1 + d) % 5]);
                    rezultat.Append(matrice[r2, (c2 + d) % 5]);
                }
                else if (c1 == c2) 
                {
                    int d = criptare ? 1 : 4;
                    rezultat.Append(matrice[(r1 + d) % 5, c1]);
                    rezultat.Append(matrice[(r2 + d) % 5, c2]);
                }
                else 
                {
                    rezultat.Append(matrice[r1, c2]);
                    rezultat.Append(matrice[r2, c1]);
                }
            }
            return rezultat.ToString();
        }

        private static void GasestePozitie(char c, ref int r, ref int col)
        {
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    if (matrice[i, j] == c) { r = i; col = j; }
        }
    }
}
