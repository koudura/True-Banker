using System;
using System.Collections;
using System.Collections.Generic;

namespace Generic_Sorter
{
    class Program {
        /// <summary>
        /// Mains the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args) {
            ArrayList lister = new ArrayList {
                1,
                "john",
                45,
                "peace",
                'w',
                "qatar",
                4
            };
            int[] test = {2,5,7,4,1,9,9,3,0,1,6,12};
            Sorter<int> arrange = new Sorter<int>(test);
            arrange.Sort();
            foreach (var va in test) {
                Console.WriteLine(va);
            }

            Console.WriteLine("\nusing icomparer......");
            int[] test2 = { 5, 8, 7, 4, 1, 9, 19, 4, 0, 1, 2, 14,0, 7,21,12,3};
            Sort<int> sorter2 = new Sort<int>(test2, arrange);
            sorter2.HeapSort(0, test2.Length);
            foreach (var va in test2)
            {
                Console.WriteLine(va);
            }


            Console.ReadLine();
        }
    }




    public class Sorter<T> : IComparer<T> where T : IComparable{

        private T[] array;

        private ArrayList arrList;
        public ArrayList ArrList { get { return this.arrList; } }
        /// <summary>
        /// Initializes a new instance of the <see cref="Sorter{T}"/> class.
        /// </summary>
        /// <param name="_array">The array.</param>
        public Sorter(T[] _array) {
            array = _array;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Sorter{T}"/> class.
        /// </summary>
        /// <param name="_arrlist">The arrlist.</param>
        Sorter(ArrayList _arrlist) {
            arrList = _arrlist;
        }
        /// <summary>
        /// Sorts the array
        /// </summary>
        public void Sort() {
            int i, j, n = array.Length;

            for (i = 1; i < n; i++) {
                T obj = array[i];
                bool insert = false;
                for (j = i - 1; j >= 0 && !insert; ) {
                    if (obj.CompareTo(array[j]) < 0) {
                        array[j + 1] = array[j];
                        j--;
                        array[j + 1] = obj;
                        continue;
                    }
                    insert = true;
                }
            }
        }

        public int Compare(T x, T y)
        {
            return x.CompareTo(y);
        }
    }
}
