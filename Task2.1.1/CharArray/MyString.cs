using System;

namespace MyString
{
    public class CharArray : IEquatable<CharArray>, IComparable<CharArray>
    {

        public char[] MyArray { get; set; }
        public CharArray() { }
        public CharArray(string str)
        {
            MyArray = ToCharArray(str);
        }
        private CharArray(char[] c)
        {
            MyArray = c;
        }
        public CharArray(CharArray str)
        {
            MyArray = str.MyArray;
        }
        internal char[] ToCharArray(string str)
        {
            char[] MyArray = new char[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                MyArray[i] = str[i];
            }
            return MyArray;
        }

        internal int this[int i]
        {
            get
            {
                if (i < 0 || i >= MyArray.Length)
                {
                    Console.WriteLine("Индекс {0} выходит за границы массива", i);
                    return 0;
                }
                return MyArray[i];
            }
            set
            {
                if (i < 0 || i >= MyArray.Length)
                {
                    Console.WriteLine("Индекс {0} выходит за границы массива", i);
                }
                else
                {
                    if (value >= 0 && value <= 100)
                    {
                        MyArray[i] = (char)value;
                    }
                    else
                    {
                        Console.WriteLine("Присваивается недопустимое значение {0}", value);
                    }
                }
            }
        }
        internal void PrintArray()
        {
            Console.WriteLine("Your Char array: ");
            for (int i = 0; i < MyArray.Length; i++)
            {
                Console.Write(MyArray[i]);
            }
            Console.WriteLine();
        }



        public static CharArray operator +(CharArray object1, CharArray object2)
            => new CharArray(object1.ToString() + object2.ToString());
        public static implicit operator CharArray(string obj) => new CharArray(obj);
        public static implicit operator CharArray(char[] obj) => new CharArray(obj);

        public bool Equals(CharArray other)
        {
            if (other == null)
                return false;

            if (this.MyArray == other.MyArray)
                return true;
            else
                return false;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                Console.WriteLine("String is empty!");
                return false;
            }
            CharArray charArrayObj = obj as CharArray;
            if (charArrayObj == null)
            {
                Console.WriteLine("String is empty!");
                return false;
            }
            else
                return Equals(charArrayObj);
        }

        public override int GetHashCode()
        {
            return this.MyArray.GetHashCode();
        }
        public int CompareTo(CharArray myString)
        {
            if (myString == null) return 1;

            CharArray otherArray = myString as CharArray;
            if (otherArray != null)
            {
                if (this.MyArray.Length > otherArray.Length()) return 1;
                else if (this.MyArray.Length < otherArray.Length()) return -1;
                else
                {
                    for (int i = 0; i < this.MyArray.Length; i++)
                    {
                        if (this.MyArray[i] > otherArray[i]) return 1;
                        else if (this.MyArray[i] < otherArray[i]) return -1;
                    }
                    return 0;
                }
            }
            //return this.MyArray.ToString().CompareTo(otherArray.MyArray);
            else
                throw new ArgumentException("Object is not a CharArray");
        }
        // Define the is greater than operator.
        public static bool operator >(CharArray operand1, CharArray operand2)
        {
            return operand1.CompareTo(operand2) > 0;
        }

        // Define the is less than operator.
        public static bool operator <(CharArray operand1, CharArray operand2)
        {
            return operand1.CompareTo(operand2) < 0;
        }

        // Define the is greater than or equal to operator.
        public static bool operator >=(CharArray operand1, CharArray operand2)
        {
            return operand1.CompareTo(operand2) >= 0;
        }

        // Define the is less than or equal to operator.
        public static bool operator <=(CharArray operand1, CharArray operand2)
        {
            return operand1.CompareTo(operand2) <= 0;
        }
        public static bool operator ==(CharArray str1, CharArray str2)
        {
            if (((object)str1) == null || ((object)str2) == null)
                return Object.Equals(str1, str2);

            return str1.Equals(str2);
        }
        public static bool operator !=(CharArray str1, CharArray str2)
        {
            if (((object)str1) == null || ((object)str2) == null)
                return !Object.Equals(str1, str2);

            return !str1.Equals(str2);
        }
        internal int Length()
        {
            string temp = MyArray.ToString();
            return temp.Length;
        }
        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < this.MyArray.Length; i++)
            {
                str += this.MyArray[i];
            }
            return str;
        }
    }
}
