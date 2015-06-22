using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DiscriptSimple
{
    public static class DiscriptSimple
    {
        public static string Encription(string CodeMessage, string Key)
        {
            string s = "";
            char[] charKey = Key.ToCharArray();

            char[] somKey = Key.Distinct().ToArray();

            

            if (charKey.Length != somKey.Length)
            {
                throw new System.ArgumentException("Строка имеет одинаковые символы такой ключь не подходит");
            }


            List<string> kodearrey = new List<string>();



            while (CodeMessage.Length % Key.Length != 0)
            {
                CodeMessage += " ";
            }

            int del = CodeMessage.Length /  Key.Length;

            int nDel = 0;

            while (nDel + del <= CodeMessage.Length)
            {
                kodearrey.Add(CodeMessage.Substring(nDel,  del));
                nDel += del;
            }

            char[] charKeySort = Key.ToCharArray();

            Array.Sort<char>(charKeySort);

            List<string> newKodeArrey = new List<string>();

            for (int i = 0; i < kodearrey.Count; i++ )
            {
                newKodeArrey.Add(kodearrey[Array.IndexOf(charKey,charKeySort[i])]);
            }

            List<char> encodingCh = new List<char>();;

            for (int i = 0; i < newKodeArrey[0].Length; i++)
            {
                foreach (string z in newKodeArrey)
                {
                    encodingCh.Add(z[i]);
                }
            }

            foreach (char c in encodingCh) s += c;

            return s;
        }

        public static string Diskription(string KodeString, string Key)
        {
            string s = "";

            char[] charKey = Key.ToCharArray();

            char[] somKey = Key.Distinct().ToArray();



            if (charKey.Length != somKey.Length)
            {
                throw new System.ArgumentException("Строка имеет одинаковые символы такой ключь не подходит");
            }

            if (KodeString.Length % Key.Length != 0)
            {
                throw new System.ArgumentException("Строка не делится без остатка на ключь, этот ключь не от этой строки, инфа 146 % нивру нисколька!!!!!!!");
            }

            int dlin = Key.Length;

            string[] kodeTable = new string[dlin];

            int counter = 0;

            foreach(char t in KodeString)
            {
                if (counter == dlin) counter = 0;
                kodeTable[counter] += t;
                counter++;
            }

            char[] charKeySort = Key.ToCharArray();

            Array.Sort<char>(charKeySort);

            for (int i = 0; i < dlin; i++)
            {
                s += kodeTable[ Array.IndexOf(charKeySort, charKey[i])  ];
            }


            return s;
        }
    }
}
