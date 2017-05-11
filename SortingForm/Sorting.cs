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
        ///Stabilni, ale pomaly, O(n^2).
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
        ///Stabilni, pro mala pole rychly, O(n^2).
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
                    child++;

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
        ///Nestabilni trideni, v prumernem i nejhorsim pripade ma O(n log n).
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
        /*
        Slevani dvou poli do jednoho
        Nakopirujeme mensi prvek ze dvou do res a kdyz
        jsme na konci jednoho pole, prekopirujeme zbytek
        */
        private void Merge(int[] res, int left, int right)
        {
            int middle = (left + right) / 2;
            int index = left;
            int leftidx = left;
            int rightidx = middle + 1;

            while (leftidx <= middle && rightidx <= right)
            {
                if (array[rightidx] < array[leftidx])
                    res[index] = array[rightidx++];
                else
                    res[index] = array[leftidx++];
                ++index;
            }
            while (leftidx <= middle)
            {
                res[index] = array[leftidx++];
                ++index;
            }
            while (rightidx <= right)
            {
                res[index] = array[rightidx++];
                ++index;
            }
        }

        /*
        Rozdelime pole a pak se rekurzivne zavolame
        pro levou a pravou cast pole 
        Pak se vracime z rekurze a slevame
        casti dohromady a tim je setridime
        */

        ///<summary>
        ///Rychle a stabilni trideni, O(n log n). 
        ///</summary>
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

            Merge(res, left, right);

            for (int i = left; i <= right; ++i)
            {
                array[i] = res[i];
            }
        }

        ///<summary>
        ///Slozitost O(n2), v prumernem pripade O(n log n). 
        ///Zalezi na tom jak se zvoli pivot
        ///</summary> 
        public void QuickSort()
        {
            DoQuickSort(0, array.Length);
        }

        // V teto implementaci Quicksortu se
        // za pivot zvoli vzdy nejlevejsi prvek 
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

        /*
        decim nula - pracuje s celymi cisly
        decim nenula - pracuje jen c ciframi (pro RadixSort)
        */
        private void CountSort(int decim)
        {
            int[] counting;
            int min, max;
            int index;
            min = max = array[0];

            //najdeme minimum a maximum
            if (decim == 0)
            {
                for (int i = 1; i < array.Length; ++i)
                    if (array[i] < min) min = array[i];
                    else if (array[i] > max) max = array[i];

                counting = new int[max - min + 1];
            }
            else counting = new int[10];

            //spocitame vyskyty jednotlivych hodnot
            for (int i = 0; i < array.Length; ++i)
            {
                if (decim == 0) index = array[i] - min;
                else index = (array[i] / decim) % 10;

                ++counting[index];
            }

            //ted chceme mit posledni index kde konci vyskyt hodnoty
            --counting[0];
            if (decim == 0) index = counting.Length;
            else index = 10;

            for (int i = 1; i < index; ++i)
                counting[i] += counting[i - 1];

            //pak jen projdeme od konce pole a vytvorime serazene pole
            int[] res = new int[array.Length];

            for (int i = array.Length - 1; i >= 0; --i)
            {
                if (decim == 0) index = array[i] - min;
                else index = (array[i] / decim) % 10;

                res[counting[index]--] = array[i];
            }

            for (int i = 0; i < array.Length; i++)
                array[i] = res[i];
        }

        ///<summary>
        ///Nejlepsi pro opakujici se hodnoty. 
        ///Slozitost je O(n+m), kde m je delka
        ///pole s indexy
        ///</summary> 
        public void CountingSort()
        {
            CountSort(0);
        }

        /*
        Zavolame CountingSort na jednotlive 
        cifry (od konce) hodnot ulozenych v poli
        - tj. na jednotky, desitky, stovky...
        */

        ///<summary>
        ///Stabilni trideni, slozitost je pro m ciferna cisla O (m * N),
        ///kde N je slozitost vnitrniho trideni.<para/>
        ///Jako vnitrni trideni je vybran CountingSort
        ///</summary> 
        public void RadixSort()
        {
            //najdeme maximum
            int max = array[0];
            for (int i = 1; i < array.Length; ++i)
                if (array[i] > max) max = array[i];

            for (int decim = 1; max / decim > 0; decim *= 10)
                CountSort(decim);
        }
    }
}
