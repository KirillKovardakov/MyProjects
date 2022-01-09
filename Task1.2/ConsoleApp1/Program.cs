using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Averages();
            Doubler();
            LowerCase();
            Validator();
            Console.ReadKey(true);
        }

        public static void ReadString(ref string str)
        {
            Console.WriteLine("Would you like to enter your own string? Y/N:");
            if (Console.ReadLine().ToLower() == "y")
            {
                Console.WriteLine("Enter:");
                str = Console.ReadLine();
            }
        }
        public static void Averages()
        {
            //string str = "Викентий хорошо отметил  день рождения:  покушал пиццу, посмотрел кино, пообщался со студентами в чате";
            string str = "        Викентий    хорошо     отметил  день           рождения:  покуша,,,,,л пиццу, по...,,смотрел ки\\но, пооб.щался со сту..,дентами в чате";
            Console.WriteLine($"1.2.1 Averages\n\rOur original string: {str}");
            ReadString(ref str);
            int sumLetters = 0;
            int sumWords = 0;
            if (char.IsLetterOrDigit(str[^1])) sumWords++;
            for (int i = 0; i < str.Length; ++i)
            {
                if (char.IsLetterOrDigit(str[i]) && i < str.Length)
                {
                    sumLetters++;
                }
                if (char.IsSeparator(str[i]) && i < str.Length - 1 && sumLetters != 0)
                {
                    sumWords++;
                    while (char.IsSeparator(str[i]) && i < str.Length - 1) ++i;
                    --i;
                }
            }
            Console.WriteLine($"Average word length is {sumLetters / sumWords}");       //Displaying a number rounded to an integer 
        }
        public static string RemoveDuplicate(string str)         //Removing duplicate letters in second word
        {
            for (int i = 0; i < str.Length; i++)
            {
                for (int j = i + 1; j < str.Length; j++)
                {
                    if (str[i] == str[j])
                    {
                        str = str.Remove(j, 1);
                        j--;
                    }
                }
            }
            return str;
        }
        public static void Doubler()
        {
            string firstString = "написать программу, которая удваивает в первой введённой строке все символы, принадлежащие второй введённой строке.";

            string secondString = "описание";
            StringBuilder output = new StringBuilder("");
            Console.WriteLine($"\n\r1.2.2 Doubler\n\rOur original string: {firstString}\n\rour second string: {secondString}");
            Console.WriteLine("For first string:");
            ReadString(ref firstString);
            Console.WriteLine("For second string:");
            ReadString(ref secondString);
            secondString = RemoveDuplicate(secondString);
            for (int i = 0; i < firstString.Length; i++)
            {
                output.Append(firstString[i]);
                for (int j = 0; j < secondString.Length; j++)
                {
                    if (firstString[i] == secondString[j])
                    {
                        output.Append(firstString[i]);
                    }
                }
            }
            Console.WriteLine(output);
        }
        public static void LowerCase()
        {
            string strOriginal = "Антон хорошо начал утро: послушал Стинга, выпил кофе и посмотрел Звёздные Войны";
            Console.WriteLine($"\n\r1.2.3.1* Lowercase\n\rOur original string: {strOriginal}");
            ReadString(ref strOriginal);
            char[] charSeparators = new char[] { ' ', ',', ';', ':', '\'', '\"', '(', ')', '.', '?', '!', '-' };
            string[] str = strOriginal.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
            int counter = 0;
            foreach (var sub in str)
            {
                if (char.IsLower(sub[0]))
                    counter++;
            }
            Console.WriteLine($"Number of words starting with a lowercase letter: {counter}");
        }
        public static void Validator()
        {
            string strOriginal = " я плохо учил русский язык. забываю начинать предложения с заглавной. хорошо, что можно написать программу!";

            Console.WriteLine($"\n\r1.2.4 Validator\n\rOur original string: {strOriginal}");
            ReadString(ref strOriginal);
            char[] charSeparators = new char[] { ' ' };
            string[] str = strOriginal.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
            string tempString = str[0]; //Я не придумал ничего лучшего для обхода режима(только чтение) в изменении подиндексного значения
            char lastCharOfPastString = '.';//Сохраняю предыдущую строку чтобы смотреть есть ли . или ?, или !
            // Возможно, можно как-то настроить этот режим, но я не знаю пока что как :с
            for (int i = 0; i < str.Length; i++)// foreach не использовал, потому что нельзя изменять подстроку...
            {
                tempString = str[i];
                if (lastCharOfPastString == '.' || lastCharOfPastString == '?' || lastCharOfPastString == '!')
                {
                    tempString = char.ToUpper(tempString[0]) + tempString.Remove(0,1);
                }
                lastCharOfPastString = tempString[^1];
                Console.Write($"{tempString} ");
            }
            // StringBuilder str = new StringBuilder
            // ("я плохо учил русский язык. забываю начинать предложения с заглавной. хорошо, что можно написать программу!");
            // Console.WriteLine($"\n\r1.2.4 Validator\n\rOur original string: {str}");
            // for (int i = 0; i < str.Length; i++)
            // {
            //     if (!char.IsWhiteSpace(str[i]))
            //     {
            //         str[i] = char.ToUpper(str[i]);
            //         break;
            //     }
            // }

            // for (int i = 1; i < str.Length; i++)
            // {
            //     if (char.IsLower(str[i]) &&
            //         (((str[i - 2] == '.') || (str[i - 2] == '!') || (str[i - 2] == '?')) && str[i - 1] == ' ') ||
            //         ((str[i - 1] == '.') || (str[i - 1] == '!') || (str[i - 1] == '?')))
            //     {
            //         str[i] = char.ToUpper(str[i]);
            //     }
            // }
            // Console.WriteLine(str);
        }
    }
}