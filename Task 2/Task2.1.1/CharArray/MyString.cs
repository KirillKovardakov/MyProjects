using System;
 using System.Text;

namespace Char_Array
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
        private char[] ToCharArray(string str)
        {
            char[] MyArray = new char[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                MyArray[i] = str[i];
            }
            return MyArray;
        }

        public int this[int i]
        {
            get
            {
                return MyArray[i];
            }
            set
            {
                MyArray[i] = (char)value;
            }
        }
        public void PrintArray()
        {
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
                return false;
            }
            CharArray charArrayObj = obj as CharArray;
            if (charArrayObj == null)
            {
                return false;
            }
            return Equals(charArrayObj);
        }

        public override int GetHashCode()
        {
            return this.MyArray.GetHashCode();
        }
        public int CompareTo(CharArray myString)
        {
            if (myString == null) return 1;

            CharArray otherArray = myString;
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
            return str1.Equals(str2);
        }
        public static bool operator !=(CharArray str1, CharArray str2)
        {
            return !str1.Equals(str2);
        }
        public override string ToString()
        {
            StringBuilder str = new StringBuilder(MyArray.Length);
            for (int i = 0; i < this.MyArray.Length; i++)
            {
                str[i] = this.MyArray[i];
            }
            return str.ToString();
        }
    }
}
