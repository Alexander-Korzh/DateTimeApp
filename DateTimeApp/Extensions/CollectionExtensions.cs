using System;
using System.Collections.Generic;


namespace DateTimeApp
{
    public static class CollectionExtensions
    {
        public static ICollection<T> CreateRandom<T>(this ICollection<T> collection, int length, Func<T> Randomaizer)
        {
            for (int i = 0; i < length; i++)

                collection.Add(Randomaizer.Invoke());

            return collection;
        }

        public static void Print<T>(this ICollection<T> collection)
        {
            foreach (T item in collection) Console.WriteLine("\t\t"+ item + "\n");
        }
    }
}
