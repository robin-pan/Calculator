using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Calculator
{
    public partial class Form1 : Form
    {
        string input = "";
        
        public void numClick(object sender, EventArgs e)
        {
            if (result.Text == "0")
            {
                result.Clear();
            }

            if (equation.Text == "0")
            {
                equation.Clear();
            }

            Button b = (Button)sender;
            result.Text += b.Text;
            equation.Text += b.Text;

            input += b.Text;
        }

        private void operatorClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            result.Clear();
            result.Text += "0";

            equation.Text += b.Text;

            input += (" " + b.Text + " ");
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AllocConsole();
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void equation_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            input += " ";
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (result.Text.Length <= 1)
            {
                result.Text = "0";
            }

            if (equation.Text.Length <= 1)
            {
                equation.Text = "0";
            }

            else
            {
                result.Text = result.Text.Substring(0, result.Text.Length - 1);
                equation.Text = equation.Text.Substring(0, equation.Text.Length - 1);
            }

            if (input.Length == 1)
            {
                input = "";
            }

            else if (input.Length > 1)
            {
                input = input.Substring(0, equation.Text.Length - 1);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            result.Text = "0";
            equation.Text = "0";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Console.WriteLine(result.Text.Length);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Console.WriteLine(equation.Text.Length);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Console.WriteLine(input.Length);
        }
    }
}
