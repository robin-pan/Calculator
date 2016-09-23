namespace Calculator
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.buttonEquals = new System.Windows.Forms.Button();
            this.result = new System.Windows.Forms.TextBox();
            this.buttonDivide = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonSubtract = new System.Windows.Forms.Button();
            this.buttonMultiply = new System.Windows.Forms.Button();
            this.button0 = new System.Windows.Forms.Button();
            this.buttonDecimal = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.equation = new System.Windows.Forms.TextBox();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(316, 442);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 65);
            this.button1.TabIndex = 2;
            this.button1.TabStop = false;
            this.button1.Text = "1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.numClick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(392, 442);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(66, 65);
            this.button2.TabIndex = 1;
            this.button2.TabStop = false;
            this.button2.Text = "2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.numClick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(468, 442);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(66, 65);
            this.button3.TabIndex = 2;
            this.button3.TabStop = false;
            this.button3.Text = "3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.numClick);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(316, 366);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(66, 65);
            this.button4.TabIndex = 3;
            this.button4.TabStop = false;
            this.button4.Text = "4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.numClick);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(392, 366);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(66, 65);
            this.button5.TabIndex = 4;
            this.button5.TabStop = false;
            this.button5.Text = "5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.numClick);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(468, 366);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(66, 65);
            this.button6.TabIndex = 5;
            this.button6.TabStop = false;
            this.button6.Text = "6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.numClick);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(316, 293);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(66, 65);
            this.button7.TabIndex = 6;
            this.button7.TabStop = false;
            this.button7.Text = "7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.numClick);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(392, 293);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(66, 65);
            this.button8.TabIndex = 7;
            this.button8.TabStop = false;
            this.button8.Text = "8";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.numClick);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(468, 293);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(66, 65);
            this.button9.TabIndex = 8;
            this.button9.TabStop = false;
            this.button9.Text = "9";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.numClick);
            // 
            // buttonEquals
            // 
            this.buttonEquals.Location = new System.Drawing.Point(544, 442);
            this.buttonEquals.Name = "buttonEquals";
            this.buttonEquals.Size = new System.Drawing.Size(66, 138);
            this.buttonEquals.TabIndex = 9;
            this.buttonEquals.TabStop = false;
            this.buttonEquals.Text = "=";
            this.buttonEquals.UseVisualStyleBackColor = true;
            this.buttonEquals.Click += new System.EventHandler(this.buttonEquals_Click);
            // 
            // result
            // 
            this.result.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.result.Location = new System.Drawing.Point(28, 33);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(582, 68);
            this.result.TabIndex = 1;
            this.result.TabStop = false;
            this.result.Text = "0";
            this.result.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.result.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // buttonDivide
            // 
            this.buttonDivide.Location = new System.Drawing.Point(240, 515);
            this.buttonDivide.Name = "buttonDivide";
            this.buttonDivide.Size = new System.Drawing.Size(66, 65);
            this.buttonDivide.TabIndex = 16;
            this.buttonDivide.TabStop = false;
            this.buttonDivide.Text = "/";
            this.buttonDivide.UseVisualStyleBackColor = true;
            this.buttonDivide.Click += new System.EventHandler(this.operatorClick);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(240, 293);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(66, 65);
            this.buttonAdd.TabIndex = 15;
            this.buttonAdd.TabStop = false;
            this.buttonAdd.Text = "+";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.operatorClick);
            // 
            // buttonSubtract
            // 
            this.buttonSubtract.Location = new System.Drawing.Point(240, 366);
            this.buttonSubtract.Name = "buttonSubtract";
            this.buttonSubtract.Size = new System.Drawing.Size(66, 65);
            this.buttonSubtract.TabIndex = 14;
            this.buttonSubtract.TabStop = false;
            this.buttonSubtract.Text = "-";
            this.buttonSubtract.UseVisualStyleBackColor = true;
            this.buttonSubtract.Click += new System.EventHandler(this.operatorClick);
            // 
            // buttonMultiply
            // 
            this.buttonMultiply.Location = new System.Drawing.Point(240, 442);
            this.buttonMultiply.Name = "buttonMultiply";
            this.buttonMultiply.Size = new System.Drawing.Size(66, 65);
            this.buttonMultiply.TabIndex = 13;
            this.buttonMultiply.TabStop = false;
            this.buttonMultiply.Text = "*";
            this.buttonMultiply.UseVisualStyleBackColor = true;
            this.buttonMultiply.Click += new System.EventHandler(this.operatorClick);
            // 
            // button0
            // 
            this.button0.Location = new System.Drawing.Point(316, 515);
            this.button0.Name = "button0";
            this.button0.Size = new System.Drawing.Size(142, 65);
            this.button0.TabIndex = 17;
            this.button0.TabStop = false;
            this.button0.Text = "0";
            this.button0.UseVisualStyleBackColor = true;
            this.button0.Click += new System.EventHandler(this.numClick);
            // 
            // buttonDecimal
            // 
            this.buttonDecimal.Location = new System.Drawing.Point(468, 515);
            this.buttonDecimal.Name = "buttonDecimal";
            this.buttonDecimal.Size = new System.Drawing.Size(66, 65);
            this.buttonDecimal.TabIndex = 18;
            this.buttonDecimal.TabStop = false;
            this.buttonDecimal.Text = ".";
            this.buttonDecimal.UseVisualStyleBackColor = true;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(544, 366);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(66, 65);
            this.buttonClear.TabIndex = 19;
            this.buttonClear.TabStop = false;
            this.buttonClear.Text = "C";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // equation
            // 
            this.equation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.equation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.equation.Location = new System.Drawing.Point(28, 12);
            this.equation.Name = "equation";
            this.equation.Size = new System.Drawing.Size(582, 19);
            this.equation.TabIndex = 21;
            this.equation.TabStop = false;
            this.equation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.equation.TextChanged += new System.EventHandler(this.equation_TextChanged_1);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(125, 173);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(66, 65);
            this.button10.TabIndex = 22;
            this.button10.TabStop = false;
            this.button10.Text = "RESULTLEN";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(240, 173);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(66, 65);
            this.button11.TabIndex = 23;
            this.button11.TabStop = false;
            this.button11.Text = "EQUATIONLEN";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(344, 173);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(66, 65);
            this.button12.TabIndex = 24;
            this.button12.TabStop = false;
            this.button12.Text = "INPUTLEN";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(544, 293);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(66, 65);
            this.buttonDelete.TabIndex = 20;
            this.buttonDelete.TabStop = false;
            this.buttonDelete.Text = "Del";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 616);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.equation);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonDecimal);
            this.Controls.Add(this.button0);
            this.Controls.Add(this.buttonDivide);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonSubtract);
            this.Controls.Add(this.buttonMultiply);
            this.Controls.Add(this.result);
            this.Controls.Add(this.buttonEquals);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Robin\'s Calculator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button0;
        private System.Windows.Forms.TextBox result;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonSubtract;
        private System.Windows.Forms.Button buttonMultiply;
        private System.Windows.Forms.Button buttonDivide;
        private System.Windows.Forms.Button buttonEquals;
        private System.Windows.Forms.Button buttonDecimal;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.TextBox equation;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button buttonDelete;

    }
}

