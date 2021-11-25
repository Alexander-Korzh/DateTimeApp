using System;
using System.Collections;
using System.Collections.Generic;


namespace DateTimeApp
{
    public class UniqueList<T> : ICollection<T>, IEnumerable<T>
    {
        public bool IsReadOnly => false;
        public int Count => list.Count;
        public int Capacity 
        { 
            get => list.Capacity;

            set => list.Capacity = value;
        }

        private List<T> list;
        private HashSet<T> hashSet;

        #region Constructors
        public UniqueList()
        {
            list = new List<T>();

            hashSet = new HashSet<T>();
        }

        public UniqueList(int capacity)
        {
            list = new List<T>(capacity);

            hashSet = new HashSet<T>(capacity * 2);
        }

        #endregion

        #region Methods

        public void Add(T item)
        {
            if (!hashSet.Contains(item))
            {
                list.Add(item);

                hashSet.Add(item);
            }
        }


        // Я знаю достаточно алгоритмов сортировки, включая встроенный list.Sort(),
        // но парни из майкрософт знают лучше
        public void Sort() => list.Sort();

        public void Clear() => list.Clear();

        public bool Contains(T item) => hashSet.Contains(item);

        public void CopyTo(T[] array, int arrayIndex) => list.CopyTo(array, arrayIndex);

        public List<T> ToList() => list;

        public bool Remove(T item)
        {
            if (hashSet.Contains(item))
            {
                hashSet.Remove(item);

                list.Remove(item);

                return true;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for ( int i =0; i < Count; i++)
            {
                yield return list[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public virtual T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count) throw new IndexOutOfRangeException();
                return list[index];
            }
            set
            {
                if (index < 0 || index >= Count) throw new IndexOutOfRangeException();
                list[index] = value;
            }
        }

        #endregion

    }
}
