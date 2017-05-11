namespace SortingForm
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.minVal = new System.Windows.Forms.NumericUpDown();
            this.maxVal = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.input = new System.Windows.Forms.TextBox();
            this.output = new System.Windows.Forms.TextBox();
            this.sort = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.isRandom = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.arraySize = new System.Windows.Forms.NumericUpDown();
            this.customizeArray = new System.Windows.Forms.GroupBox();
            this.showArray = new System.Windows.Forms.Button();
            this.sortList = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.minVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arraySize)).BeginInit();
            this.customizeArray.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(332, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input array";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Range of values (inclusive):";
            // 
            // minVal
            // 
            this.minVal.Location = new System.Drawing.Point(306, 38);
            this.minVal.Name = "minVal";
            this.minVal.Size = new System.Drawing.Size(63, 22);
            this.minVal.TabIndex = 2;
            this.minVal.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // maxVal
            // 
            this.maxVal.Location = new System.Drawing.Point(486, 40);
            this.maxVal.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.maxVal.Name = "maxVal";
            this.maxVal.Size = new System.Drawing.Size(63, 22);
            this.maxVal.TabIndex = 3;
            this.maxVal.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(252, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Min";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(429, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Max";
            // 
            // input
            // 
            this.input.Location = new System.Drawing.Point(12, 56);
            this.input.Multiline = true;
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(723, 60);
            this.input.TabIndex = 6;
            this.input.TextChanged += new System.EventHandler(this.input_TextChanged);
            // 
            // output
            // 
            this.output.Location = new System.Drawing.Point(12, 168);
            this.output.Multiline = true;
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(723, 58);
            this.output.TabIndex = 7;
            // 
            // sort
            // 
            this.sort.Location = new System.Drawing.Point(307, 420);
            this.sort.Name = "sort";
            this.sort.Size = new System.Drawing.Size(157, 42);
            this.sort.TabIndex = 8;
            this.sort.Text = "Sort";
            this.sort.UseVisualStyleBackColor = true;
            this.sort.Click += new System.EventHandler(this.Sort_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(346, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Output";
            // 
            // isRandom
            // 
            this.isRandom.AutoSize = true;
            this.isRandom.Checked = true;
            this.isRandom.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isRandom.Location = new System.Drawing.Point(393, 242);
            this.isRandom.Name = "isRandom";
            this.isRandom.Size = new System.Drawing.Size(153, 21);
            this.isRandom.TabIndex = 10;
            this.isRandom.Text = "Make random array";
            this.isRandom.UseVisualStyleBackColor = true;
            this.isRandom.CheckedChanged += new System.EventHandler(this.isRandom_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Size:";
            // 
            // arraySize
            // 
            this.arraySize.Location = new System.Drawing.Point(67, 86);
            this.arraySize.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.arraySize.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.arraySize.Name = "arraySize";
            this.arraySize.Size = new System.Drawing.Size(120, 22);
            this.arraySize.TabIndex = 12;
            this.arraySize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // customizeArray
            // 
            this.customizeArray.Controls.Add(this.showArray);
            this.customizeArray.Controls.Add(this.arraySize);
            this.customizeArray.Controls.Add(this.label6);
            this.customizeArray.Controls.Add(this.label2);
            this.customizeArray.Controls.Add(this.minVal);
            this.customizeArray.Controls.Add(this.maxVal);
            this.customizeArray.Controls.Add(this.label3);
            this.customizeArray.Controls.Add(this.label4);
            this.customizeArray.Location = new System.Drawing.Point(12, 275);
            this.customizeArray.Name = "customizeArray";
            this.customizeArray.Size = new System.Drawing.Size(723, 125);
            this.customizeArray.TabIndex = 13;
            this.customizeArray.TabStop = false;
            this.customizeArray.Text = "Customize array";
            // 
            // showArray
            // 
            this.showArray.Location = new System.Drawing.Point(444, 86);
            this.showArray.Name = "showArray";
            this.showArray.Size = new System.Drawing.Size(75, 23);
            this.showArray.TabIndex = 13;
            this.showArray.Text = "Show";
            this.showArray.UseVisualStyleBackColor = true;
            this.showArray.Click += new System.EventHandler(this.showArray_Click);
            // 
            // sortList
            // 
            this.sortList.FormattingEnabled = true;
            this.sortList.ItemHeight = 16;
            this.sortList.Items.AddRange(new object[] {
            "bubble",
            "insertion",
            "heap ",
            "merge",
            "quick",
            "counting",
            "radix"});
            this.sortList.Location = new System.Drawing.Point(180, 233);
            this.sortList.Name = "sortList";
            this.sortList.Size = new System.Drawing.Size(170, 36);
            this.sortList.TabIndex = 14;
            // 
            // Form1
            // 
            this.AcceptButton = this.sort;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 487);
            this.Controls.Add(this.sortList);
            this.Controls.Add(this.isRandom);
            this.Controls.Add(this.customizeArray);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.sort);
            this.Controls.Add(this.output);
            this.Controls.Add(this.input);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Sorting arrays";
            ((System.ComponentModel.ISupportInitialize)(this.minVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arraySize)).EndInit();
            this.customizeArray.ResumeLayout(false);
            this.customizeArray.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown minVal;
        private System.Windows.Forms.NumericUpDown maxVal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox input;
        private System.Windows.Forms.TextBox output;
        private System.Windows.Forms.Button sort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox isRandom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown arraySize;
        private System.Windows.Forms.GroupBox customizeArray;
        private System.Windows.Forms.Button showArray;
        private System.Windows.Forms.ListBox sortList;
    }
}

