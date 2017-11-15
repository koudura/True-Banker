using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericSort
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] unsorted = { "hasho", "mada", "ikuze", "tobi", "ichibi", ""};
            
            GSort<string> sort = new GSort<string>(unsorted);
            sort.Sort();
            foreach (var i in unsorted)
            {
                Console.WriteLine(i);
            }

            int[] iun = { 13,2,1,3,7,10};
            GSort<int> isort = new GSort<int>(iun);
            isort.Sort();
            foreach (var i in iun)
            {
                Console.WriteLine(i);
            }

            Console.ReadLine();
        }
    }



    /// <summary>
    /// A generic class to sort items
    /// </summary>
    /// <typeparam name="T">Any type that implements the <see cref="IComparable{T}"/> interface</typeparam>
    class GSort<T> where T : IComparable<T>
    {
        // The internal representation of the array
        private T[] array;

        

        /// <summary>
        /// Initializes a new instance of the <see cref="GSort{T}"/> class.
        /// </summary>
        /// <param name="array">The array.</param>
        public GSort(T[] array)
        {
            this.array = array;

        }

        

        /// <summary>
        /// Performs the sort.
        /// </summary>
        public void Sort ()
        {
            int i, j, n = array.Length;
            for ( i = 1; i < n; i++)
            {
                T item = array[i];
                int ins = 0;
                for ( j = i - 1; j >= 0 && ins != 1; )
                {
                    if (item.CompareTo(array[j]) < 0)
                    {
                        array[j + 1] = array[j];
                        j--;
                        array[j + 1] = item;
                    }
                    else
                    {
                        ins = 1;
                    }
                }
            }

        }

      

    }
}
