using System;
using System.Collections.Generic;
using System.Text;

namespace SuperArray
{
    public static class Int32ArrayExtensions 
    {
        public static int Summ(this IEnumerable<int> array)
        {
            int sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }

            return sum;
        }
        public static int AverageValue(this IEnumerable<int> array)
        {
            int sum = 0;
            int number = 0;
            foreach (var item in array)
            {
                sum += item;
                number++;
            }

            return sum / number;
        }
        public static int MaxRepeatedElement(this IEnumerable<int> array)
        {
            List<int> list = new List<int>();
            foreach (var item in array)
            {
                list.Add(item);
            }

            return Max(list);
        }
        private static int Max(List<int> array)
        {
            int intMax = 0;
            int max = 0;
            for (int i = 0; i < array.Count; i++)
            {
                int tempMax = 0;
                for (int j = i; j < array.Count; j++)
                {
                    if (array[j] == array[i])
                    {
                        tempMax++;
                    }
                }
                if (tempMax > max)
                {
                    intMax = array[i];
                    max = tempMax;
                }
            }
            return intMax;
        }
    }
}
