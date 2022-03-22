using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace DynamicArray
{
    public class DynamicArray<T> : IEnumerable<T>
    {
        private T[] Mass { get; set; } = new T[8];
        private int Count { get; set; } = 0;
        public DynamicArray()
        {

        }
        public DynamicArray(int n)
        {
            Mass = new T[n];
        }
        public DynamicArray(IEnumerable<T> tempArray)
        {
            FactorCapacity(tempArray);
            foreach (var item in tempArray)
            {
                if (item != null) Mass[Count] = item;
                Count++;
            }
        }
        public void Add(T temp)
        {
            Count++;
            EnsureCapacity();
            Mass[Count - 1] = temp;
        }
        public void AddRange(IEnumerable<T> temp)
        {
            FactorCapacity(temp);
            var tempMass = temp.ToArray();
            Array.Copy(tempMass, 0,  Mass, Count, tempMass.Length);
            Count += tempMass.Length;
        }
        private void EnsureCapacity()
        {
            if (Count > Mass.Length)
            {
                this.Mass = DoubleCapacity();
            }
        }
        private T[] DoubleCapacity()
        {
            var newMass = new T[Mass.Length * 2];
            Array.Copy(Mass, newMass, Mass.Length);
            return newMass;
            
        }
        private void FactorCapacity(IEnumerable<T> temp)
        {
            var newTemp = temp.ToArray();
            var newMass = new T[(newTemp.Length + Mass.Length) + 2];
            Array.Copy(Mass, newMass, Mass.Length);
            Mass = newMass;
        }
        public bool Insert(int position, T value)
        {
            if (position < 0 || position >= Count) throw new ArgumentOutOfRangeException();
            ++Count;
            EnsureCapacity();
            for (int i = Count - 1; i > position; i--) 
            {
                Mass[i] = Mass[i - 1];
            }

            Mass[position] = value;
            return true;
        }
        public bool Remove(int position)
        {
            if (position < 0 || position >= Count) return false;
            for (int i = position; i < Count- 1; i++)
            {
                Mass[i] = Mass[i + 1];
            }
            --Count;
            return true;
        }
        public int Length() => Count;
        public int Capacity() => Mass.Length;

        public DynamicArray<T> GetEnumerator()
        {
            return new DynamicArray<T>(Mass);
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return ((IEnumerable<T>)Mass).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Mass.GetEnumerator();
        }
        public T this[int i]
        {
            get
            {
                if (i < 0 || i >= Count) throw new ArgumentOutOfRangeException();
                return Mass[i];
            }
            set
            {
                if (i < 0 || i >= Count) throw new ArgumentOutOfRangeException();
                Mass[i] = (T)value;
            }
        }
    }
}
