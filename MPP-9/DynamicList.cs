using System;
using System.Collections;
using System.Collections.Generic;

namespace MPP_9
{
    public class DynamicList<T> : IEnumerable<T>
    {
        private T[] Items { get; set; }
        public int Count { get; private set; }
        public int Capacity { get; private set; }
        private double LoadFactor { get; }

        public DynamicList(int initialCapacity, double loadFactor)
        {
            Items = new T[initialCapacity];
            Capacity = initialCapacity;
            LoadFactor = loadFactor;
        }

        public void Add(T t)
        {
            Items[Count++] = t;
            if (!((double) Count / Capacity > LoadFactor)) return;
            Capacity = (int) (Capacity * 1.5);
            T[] temp = Items;
            Items = new T[Capacity];
            Array.Copy(temp, Items, temp.Length);
        }

        public bool Remove(T t)
        {
            for (var i = 0; i < Items.Length; i++)
            {
                var e = Items[i];
                if (!t.Equals(e)) continue;
                Array.Copy(Items, i + 1, Items, i, Items.Length - i - 1);
                Count--;
                return true;
            }

            return false;
        }

        public bool RemoveAt(int index)
        {
            if (index > Items.Length || index < 0)
            {
                return false;
            }

            Array.Copy(Items, index + 1, Items, index, Items.Length - index - 1);
            Count--;
            return true;
        }

        public void Clear()
        {
            Items = new T[Capacity];
            Count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return Items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            var s = "[";
            for (var i = 0; i < Count; i++)
            {
                T t = Items[i];
                s += t + ", ";
            }

            if (Count > 0)
            {
                s = s.Substring(0, s.Length - 2);
            }

            s += "]";
            return s;
        }
    }
}