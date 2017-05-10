using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortingForm
{
    public partial class Form1 : Form
    {
        const int
        bubble = 0, insertion = 1, heap = 2,
        merge = 3, mergerec = 4, quick = 5, 
        counting = 6, bucket = 7, radix = 8;

        bool isInputChange = false;

        public Form1()
        {
            InitializeComponent();
            sortList.SetSelected(bubble, true);
        }

        private void input_TextChanged(object sender, EventArgs e)
        {
            isInputChange = true;
        }

        private void isRandom_CheckedChanged(object sender, EventArgs e)
        {
            if (isRandom.Checked) customizeArray.Show();
            else customizeArray.Hide();
        }

        private void Sort_Click(object sender, EventArgs e)
        {
            if (input.Text == "" || !isInputChange)
            {
                output.Text = "Nothing to sort";
                return;
            }
            if (!isInputChange) return;

            string[] str = input.Text.Split(' ');
            string x = "";
            Stack<int> stack = new Stack<int>();
            output.Text = "";

            int number;

            foreach (char ch in (input.Text + " "))
            {
                if (Int32.TryParse(ch.ToString(), out number)) x += ch;
                else if (x != "")
                {
                    stack.Push(Int32.Parse(x));
                    x = "";
                }
            }

            int[] values = new int[stack.Count];

            while (stack.Count > 0) values[stack.Count - 1] = stack.Pop();

            int index = 0;
            int[] array = new int[values.Length];
            foreach (int v in values) array[index++] = v;

            //if (sortList.SelectedIndex == bubble) new Sorting(array).BubbleSort();

            Sorting s = new Sorting(array);

            switch (sortList.SelectedIndex)
            {
                case bubble: s.BubbleSort(); break;
                case insertion: s.InsertionSort(); break;
                case heap: s.HeapSort(); break;
                case merge: s.MergeSortNonRecursive(); break;
                case mergerec: s.MergeSort(); break;
                case quick: s.QuickSort(); break;
                case counting: s.CountingSort(); break;
                case bucket: s.BucketSort(); break;
                case radix: s.RadixSort(); break;
                default: break;
            }

            foreach (int i in array) output.Text += i + " ";
        }

        private void showArray_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int size, min, max;

            size = (int)arraySize.Value;
            min = (int)minVal.Value;
            max = (int)maxVal.Value;

            input.Text = "";

            for (int i = 0; i < size; ++i)
                input.Text += rnd.Next(min, max) + " ";
        }
    }
}
