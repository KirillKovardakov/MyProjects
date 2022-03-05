using System;
using System.Collections.Generic;
using System.Text;

namespace SuperString
{
    public static class StringExtensions
    {
        public static string WhatLanguage(this string str)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < str.Length; i++)
            {
                if (list.Count >= 2) return "Mixed";
                if (str[i] >= 'А' && str[i] <= 'я' || str[i] == 'ё' || str[i] == 'Ё')
                {
                    if (list.Count == 0) list.Add(1);
                    if (list.Count == 1)
                        if (list[0] != 1) list.Add(1); //Russian
                }
                else if (str[i] >= 'A' && str[i] <= 'Z' || str[i] >= 'a' && str[i] <= 'z')
                {
                    if (list.Count == 0) list.Add(2); //English
                    if (list.Count == 1)
                        if (list[0] != 2) list.Add(2);
                }
                else if (str[i] >= '0' && str[i] <= '9')
                {
                    if (list.Count == 0) list.Add(3);
                    if (list.Count == 1)
                        if (list[0] != 3) list.Add(3); //Number
                }
                else return "Mixed";
            }
            if (list.Count == 0) return "I can't determine!";
            if (list[0] == 1)
            {
                return "Russian";
            }
            else if (list[0] == 2)
            {
                return "English";
            }
            else if (list[0] == 3)
            {
                return "Number";
            }
            else return "Mixed";
        }
    }
}
