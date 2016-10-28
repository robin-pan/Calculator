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
        private static string _input = "";
        private static bool _inputRestricted = false;

        void DisplayResult(Stack<int> e)
        {
            Console.WriteLine(e.Peek());
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

        // Gets called when any of the digits are clicked on
        public void NumClick(object sender, EventArgs e)
        {
            if (_inputRestricted == true) return;
            
            // Removes leading 0 in number entry
            if (result.Text == "0")
            {
                result.Clear();
            }

            // Appends clicked character to number entry string
            Button b = (Button)sender;
            result.Text += b.Text;
        }

        // Gets called when any of the operators are clicked on
        private void OperatorClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            // Adds the data in number entry to equation 
            equation.Text += (result.Text + b.Text);
            _input += (result.Text += " " + b.Text + " ");

            // Reset data entry with 0
            result.Clear();
            result.Text += "0";

            if (_inputRestricted) _inputRestricted = false;
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            // Add space at the end of equation for evaluation
            _input += (result.Text + " ");

            // 

            // 
            Stack<int> expStack = new Stack<int>();

            // Converts from postfix to infix 
            string expPostfix = Calculate.ToPostfix(_input);

            // Split postfix expression into its tokens
            string[] tokens = expPostfix.Split(' ');
            int tokenCount = tokens.Count() - 1;

            // Tokens are processed in expStack
            for (int i = 0; i < tokenCount; i++)
            {
                if (Calculate.IsOperator(tokens[i]))
                {
                    Calculate.Operate(tokens[i], expStack);
                }
                else
                {
                    expStack.Push(Int32.Parse(tokens[i]));
                }
            }

            // Top of expStack is the result
            result.Text = expStack.Peek().ToString();

            // Resets the equation, current result now first entry of subsequent calculations
            equation.Clear();

            _input = result.Text;
            _input += " ";

            // Locks numeric input and delete
            _inputRestricted = true;
        }

        // Removes last character from string in number entry
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (_inputRestricted) return;
            
            if (result.Text.Length <= 1)
            {
                result.Text = "0";
            }
    
            else
            {
                result.Text = result.Text.Substring(0, result.Text.Length - 1);
            }

            _inputRestricted = true;
        }

        // Removes all text from both equation and number entry
        private void buttonClear_Click(object sender, EventArgs e)
        {   
            result.Text = "0";
            equation.Text = "";
            _input = "";

            if (_inputRestricted) _inputRestricted = false;
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
            Console.WriteLine(_input.Length);
            Console.WriteLine(_input);
        }
    }
}
