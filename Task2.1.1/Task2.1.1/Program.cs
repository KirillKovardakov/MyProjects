using System;
using MyString;

namespace Program
{

    class Program
    {
        static void Main(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            Console.WriteLine("Input your string, please:");
            CharArray str = new CharArray(Console.ReadLine());
            str += "plus string";
            str.PrintArray();
            CharArray str2 = new CharArray(str + "a");
            Console.WriteLine(str.CompareTo(str2));
            Console.WriteLine(str > str2);
            Console.ReadKey();
        }
    }
}