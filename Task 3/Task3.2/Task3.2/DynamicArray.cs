using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DynamicArray
{
    public class DynamicArray<T> : IEnumerable<T>
    {
        public T[] Mass { get; set; } = new T[8];
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
            CapacityTest();
            Mass[Count - 1] = temp;
        }
        public void AddRange(IEnumerable<T> temp)
        {
            FactorCapacity(temp);
            foreach (var item in temp)
            {
                Count++;
                Mass[Count - 1] = item;
            }
        }
        private void CapacityTest()
        {
            if (Count > Mass.Length)
            {
                this.Mass = DoubleCapacity();
            }
        }
        private T[] DoubleCapacity()
        {
            var newMass = new T[Mass.Length * 2];
            for (int i = 0; i < Mass.Length; i++)
            {
                newMass[i] = Mass[i];
            }
            return newMass;
        }
        private void FactorCapacity(IEnumerable<T> temp)
        {
            int countAddArray = 0;
            foreach (var item in temp)
            {
                countAddArray++;
            }
            int factor = 1;
            while (countAddArray + Count > factor * Mass.Length) factor *= 2;
            var newMass = new T[Mass.Length * factor];
            for (int i = 0; i < Mass.Length; i++)
            {
                newMass[i] = Mass[i];
            }
            Mass = newMass;
        }
        public bool Insert(int position, T value)
        {
            if (position < 0 || position >= Count) throw new ArgumentOutOfRangeException();
            ++Count;
            CapacityTest();
            for (int i = Count - 1; i > position; i--) //сдвиг элементов вправа
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
