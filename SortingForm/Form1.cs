using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;

namespace SortingForm
{
    public partial class Form1 : Form
    {
        const int
        bubble = 0, insertion = 1, heap = 2,
        merge = 3, quick = 4, 
        counting = 5, radix = 6;

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

            Sorting s = new Sorting(array);

            Stopwatch sw = new Stopwatch();
            sw.Start();

            switch (sortList.SelectedIndex)
            {
                case bubble: s.BubbleSort(); break;
                case insertion: s.InsertionSort(); break;
                case heap: s.HeapSort(); break;
                case merge: s.MergeSort(); break;
                case quick: s.QuickSort(); break;
                case counting: s.CountingSort(); break;
                case radix: s.RadixSort(); break;
                default: break;
            }
            sw.Stop();

            foreach (int i in array) output.Text += i + " ";
            timeOutput.Show();
            timeOutput.Text = "Sorting time: " + sw.Elapsed;
        }

        private void showArray_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int size, min, max;

            size = (int)arraySize.Value;
            min = (int)minVal.Value;
            max = (int)maxVal.Value+1;

            input.Text = "";

            for (int i = 0; i < size; ++i)
                input.Text += rnd.Next(min, max) + " ";
        }
    }
}
