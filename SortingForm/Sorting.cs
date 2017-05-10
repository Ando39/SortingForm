using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SortingForm
{
    class Sorting
    {
        int[] array;

        public Sorting(int[] array)
        {
            this.array = array;
        }

        /*
        BubbleSort vylepseny:
        1.) Zkracovani trideneho pole (jeden prvek je 
            vzdy jiz na svem miste)
        2.) Kontrola, jestli je uz setrideno - isSwap
        */

        ///<summary>
        ///Stabilni, ale pomaly, O(n^2)
        ///</summary> 
        public void BubbleSort()
        {
            int len = array.Length - 1;
            int pom;
            bool isSwap = true;

            while (isSwap)
            {
                isSwap = false;
                for (int i = 0; i < len; ++i)
                {
                    if (array[i + 1] < array[i])
                    {
                        isSwap = true;
                        pom = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = pom;
                    }
                }
                --len;
            }
        }

        /*
        Rozdelime pole na setridenou a nesetridenou cast
        Pak jen prochazime pole a vkladame prvky na spravne misto
        - tj. "posouvame" setridenou cast pole a delame misto novemu prvku 
        */

        ///<summary>
        ///Stabilni, pro mala pole rychly, O(n^2)
        ///</summary> 
        public void InsertionSort()
        {
            int pom, val;

            for (int i = 1; i < array.Length; ++i)
            {
                pom = array[i];
                val = i - 1;
                while (val >= 0 && pom < array[val]) array[val + 1] = array[val--];
                array[val + 1] = pom;
            }
        }

        private void BubbleUp(int prvek)
        {
            int child = prvek;
            int parent, temp;
            while (child != 0)
            {
                parent = (child - 1) / 2;
                if (array[parent] < array[child])
                {
                    temp = array[parent];
                    array[parent] = array[child];
                    array[child] = temp;
                    child = parent;
                }
                else return;
            }
        }

        private void BubbleDown(int last)
        {
            int parent = 0;
            int child, temp;
            while (parent * 2 + 1 <= last)
            {
                child = parent * 2 + 1;
                if ((child < last) && (array[child] < array[child + 1]))
                    if (array[parent] < array[child])
                    {
                        temp = array[parent];
                        array[parent] = array[child];
                        array[child] = temp;
                        parent = child;
                    }
                    else
                        return;
            }
        }

        private void MakeHeapFromArray()
        {
            for (int i = 1; i < array.Length; ++i)
                BubbleUp(i);
        }

        /*
        Heapsort - z pole vytvorime haldu, pak opakujeme:
        vezmeme prvni prvek prohodime s poslednim, zmensime 
        index last a bude to stejne jako kdyz mazeme prvek 
        z haldy, takze jen opravime haldu pomoci metody BubbleDown
        */

        ///<summary>
        ///Nestabilni trideni, v prumernem i nejhorsim pripade ma O(n log n)
        ///</summary>
        public void HeapSort()
        {
            MakeHeapFromArray();
            int last = array.Length - 1;
            int pom;

            while (last > 0)
            {
                pom = array[0];
                array[0] = array[last];
                array[last] = pom;
                --last;
                BubbleDown(last);
            }
        }

        // vytvoreni noveho pole z casti arr
        private int[] CopyOfRange(int[] arr, int start, int end)
        {
            int len = end - start;
            int[] res = new int[len];
            for (int i = 0; i < len; i++)
            {
                res[i] = arr[start + i];
            }
            return res;
        }

        // slevani dvou poli do jednoho
        // nakopirujeme mensi prvek ze dvou do res a kdyz
        // jsme na konci jednoho pole, prekopirujeme zbytek
        private int[] Merge(int[] arr1, int[] arr2)
        {
            int len1 = arr1.Length;
            int len2 = arr2.Length;
            int len = len1 + len2;
            int a = 0, b = 0;       //pomocne promenne pro pocitani v poli
            int[] res = new int[len];

            for (int i = 0; i < len; ++i)
            {
                if (b < len2 && a < len1)
                {
                    if (arr1[a] > arr2[b]) res[i] = arr2[b++];
                    else res[i] = arr1[a++];
                }
                else if (b < len2) res[i] = arr2[b++];
                else res[i] = arr1[a++];
            }

            return res;
        }
        // rozdelime pole a pak pouzijeme metodu Merge
        // pro levou a pravou cast pole

        ///<summary>
        ///Rychle a stabilni trideni, O(n log n). 
        ///Bez pouziti rekurze.
        ///</summary>
        public void MergeSortNonRecursive()
        {
            int len = array.Length;
            int n = 1;      // pocet srovnani (srovnani podle 1. prvku, 2. prvku atd.)
            int shift;      // posun v poli
            int two_size;   // pocet prvku pro druhe pole
            int[] arr2;
            while (n < len)
            {
                shift = 0;
                while (shift < len)
                {
                    if (shift + n >= len) break;
                    if (shift + n * 2 > len) two_size = len - (shift + n);
                    else two_size = n;
                    int[] leftarr = CopyOfRange(array, shift, shift + n);
                    int[] rightarr = CopyOfRange(array, shift + n, shift + n + two_size);
                    arr2 = Merge(leftarr, rightarr);
                    for (int i = 0; i < n + two_size; ++i)
                        array[shift + i] = arr2[i];
                    shift += n * 2;
                }
                n = n * 2;
            }
        }

        public void MergeSort()
        {
            MakeMerge(new int[array.Length], 0, array.Length - 1);
        }

        private void MakeMerge(int[] res, int left, int right)
        {
            if (left == right) return;
            int middle = (left + right) / 2;
            MakeMerge(res, left, middle);
            MakeMerge(res, middle + 1, right);

            int[] leftarr = CopyOfRange(array, left, middle);
            int[] rightarr = CopyOfRange(array, middle + 1, right);

            Merge(leftarr, rightarr);

            for (int i = left; i <= right; ++i)
            {
                array[i] = res[i];
            }
        }

        public void QuickSort()
        {
            DoQuickSort(0, array.Length);
        }

        // za pivota volime nejlevejsi prvek 
        private void DoQuickSort(int left, int right)
        {
            int pom;

            if (left < right)
            {
                int pivot = left;
                for (int i = left + 1; i < right; i++)
                {
                    if (array[i] < array[left])
                    {
                        pom = array[++pivot];
                        array[pivot] = array[i];
                        array[i] = pom;
                    }
                }
                pom = array[pivot];
                array[pivot] = array[left];
                array[left] = pom;
                DoQuickSort(left, pivot);
                DoQuickSort(pivot + 1, right);
            }
        }

        public void CountingSort()
        {
            //najdeme minimum a maximum
            int min, max;
            min = max = array[0];
            for (int i = 1; i < array.Length; ++i)
                if (array[i] < min) min = array[i];
                else if (array[i] > max) max = array[i];

            //spocitame vyskyty jednotlivych hodnot
            int[] counting = new int[max - min + 1];
            for (int i = 0; i < array.Length - 1; ++i)
                ++counting[array[i] - min];

            //ted chceme mit posledni index kde konci vyskyt hodnoty
            counting[0] -= 1;
            for (int i = 1; i < counting.Length; ++i)
                counting[i] += counting[i - 1];

            foreach (int i in counting) Console.Write("{0} ", i);
            Console.WriteLine();

            //pak jen projdeme od konce pole a vytvorime serazene pole
            for (int i = array.Length - 1; i >= 0; --i)
            {
                int index = counting[array[i] - min] - 1;
                Console.WriteLine(index);
                //array[index] = array[i];
            }
        }

        public void BucketSort()
        {

        }

        public void RadixSort()
        {

        }
    }
}
