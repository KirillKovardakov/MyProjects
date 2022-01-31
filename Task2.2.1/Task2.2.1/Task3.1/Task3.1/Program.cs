using System;
using System.Collections.Generic;
using System.Threading;

namespace task3._1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            WeakestLink();
            TextAnalysis();
            Console.ReadKey();
        }

        public static List<int> InputArr(List<int> array)
        {
            int n = GetConsoleIntValue();
            for (int i = 0; i < n; i++)
            {
                array.Add(i + 1);
            }
            return array;
        }

        public static void Print(List<int> array)
        {
            for (int i = 0; i < array.Count; i++)
            {
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine();
        }

        public static int GetConsoleIntValue()
        {
            string value = Console.ReadLine();
            if (Int32.TryParse(value, out int result))
                return result;
            Console.WriteLine("You must enter a number!");
            return GetConsoleIntValue();
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
        public static void WeakestLink()
        {
            List<int> circleOfHuman = new List<int>();
            Console.WriteLine("Введите N");
            circleOfHuman = InputArr(circleOfHuman);
            Console.WriteLine("Введите, какой по счету человек будет вычеркнут каждый раунд:");
            int x = GetConsoleIntValue();
            while (x > circleOfHuman.Count)
            {
                Console.WriteLine("The number of the person to be crossed out must be less than the number of people!");
                x = GetConsoleIntValue();
            }
            Console.WriteLine($"Сгенерирован круг людей. Начинаем вычеркивать каждого {x} - го.");
            for (int i = x - 1, k = 1; 1 < circleOfHuman.Count; i += x, k++)
            {
                while (i >= circleOfHuman.Count)
                    i -= circleOfHuman.Count;
                Console.WriteLine($"Раунд {k}. Вычеркнут человек {circleOfHuman[i]}. Людей осталось: {circleOfHuman.Count - 1}");
                circleOfHuman.RemoveAt(i);
                --i;
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
            Console.WriteLine("Игра окончена. Невозможно вычеркнуть больше людей.");
        }
        public static void TextAnalysis()
        {
            string text = "In less than a week Cowperwood knew the financial condition of the Messrs. Waterman as well as they did – better – to a dollar. " +
                "He knew how their accounts were distributed; from what section they drew the most business; who sent poor produce and good – the varying prices for " +
                "a year told that. To satisfy himself he ran back over certain accounts in the ledger, verifying his suspicions. Bookkeeping did not interest him " +
                "except as a record, a demonstration of a firm’s life. He knew he would not do this long. Something else would happen; but he saw instantly what the " +
                "grain and commission business was – every detail of it. He saw where, for want of greater activity in offering the goods consigned – quicker " +
                "communication with shippers and buyers, a better working agreement with surrounding commission men—this house, or, rather, its customers, for it " +
                "had nothing, endured severe losses. A man would ship a tow-boat or a car-load of fruit or vegetables against a supposedly rising or stable market; " +
                "but if ten other men did the same thing at the same time, or other commission men were flooded with fruit or vegetables, and there was no way of " +
                "disposing of them within a reasonable time, the price had to fall. Every day was bringing its special consignments. It instantly occurred to him " +
                "that he would be of much more use to the house as an outside man disposing of heavy shipments, but he hesitated to say anything so soon. More than " +
                "likely, things would adjust themselves shortly.";
            Console.WriteLine(text);
            ReadString(ref text);
            text = text.ToLower();
            char[] charSeparators = new char[] { ' ', ',', '.', '!', '?', '-', '+', ':', ';' };
            string[] str = text.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> numberOfWords = new Dictionary<string, int>();
            int max = 0;
            string intMax = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (numberOfWords.ContainsKey(str[i]))
                {
                    numberOfWords[str[i]]++;
                    if (max < numberOfWords[str[i]])
                    {
                        max = numberOfWords[str[i]];
                        intMax = str[i];
                    }
                }
                else numberOfWords.Add(str[i], 1);
            }
            Console.WriteLine($"The word that occurs in the text: \"{intMax}\".");
            if (max > 10) Console.Write("The repetition of this word should be reduced!");
            else Console.Write("Well done author! There are no words that are repeated too many times.");
            Console.WriteLine($" The word is repeated {max} times");
        }

    }
}
