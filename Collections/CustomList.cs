using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Collections
{
    public class CustomList<T> : IEnumerable<T>
    {
        private T[] Items;
        public int Capacity { get; private set; }
        public int Count { get; private set; }
        public T this[int index]
        {
            get
            {
                return Items[index];
            }
            set
            {
                if (index< 0 || index >= Count)
                    throw new IndexOutOfRangeException("index duzgun deyil.");
                Items[index] = value;
            }
        }

        public CustomList()
        {
            Items = Array.Empty<T>();
        }

        public void Add(T item)
        {
            Array.Resize(ref Items, Items.Length + 1);
            Items[^1] = item;
            Count++;
        }

        public T Find(Predicate<T> predicate) => Array.Find(Items, predicate);

        public List<T> FindAll(Predicate<T> predicate) => new List<T>(Array.FindAll(Items, predicate));

        public void Remove(T item)
        {
            int index = Array.IndexOf(Items, item, 0, Count);
            if (index >= 0)
            {
                for (int i = index; i < Count - 1; i++)
                {
                    Items[i] = Items[i + 1];
                }
                Count--;
                Array.Resize(ref Items, Count);
            }
        }


        public int RemoveAll(Predicate<T> predicate)
        {
            T[] newItems = Array.FindAll(Items, item => !predicate(item));
            int removedCount = Count - newItems.Length;
            Array.Copy(newItems, Items, newItems.Length);
            Count = newItems.Length;
            return removedCount;
        }

        public void Reverse()
        {
            for (int i = 0; i < Count / 2; i++)
            {
                T exmp = Items[i];
                Items[i] = Items[Count - i - 1];
                Items[Count - i - 1] = exmp;
            }
        }
        public void Sort()
        {
            T[] newArray = new T[Count];
            Array.Copy(Items, newArray, Count);
            Array.Sort(newArray);
            Array.Copy(newArray, Items, Count);
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
    }
}
