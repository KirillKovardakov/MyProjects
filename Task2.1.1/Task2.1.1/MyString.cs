using System;

namespace MyString
{
    public class MyString
    {
        private string Str{get;set;}
        public MyString(string str)
        {
            Str = str;
        }
        private void ChangeToCharArray(string str)
        {
            char[] c = new char[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                c[i] =str[i] ;
            }
        }
    }
}
