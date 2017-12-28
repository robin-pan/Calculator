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
        private static bool _decimalClicked = false;
        private static bool _syntaxError = false;

        // Determines whether token is an operator
        private static bool IsOperator(string token)
        {
            return token == "NEG" || token == "ABS" || token == "+" || token == "-" ||
            token == "*" || token == "/" || token == "(" || token == ")";
        }

        // Returns the priority of op
        private static int GetOpPriority(string op)
        {
            if (op == "NEG" || op == "ABS" || op == "*" || op == "/")
            {
                return 2;
            }

            else if (op == "(")
            {
                return -1;
            }

            else
            {
                return 1;
            }
        }

        // Converts equation from infix to post fix
        private static string ToPostfix(string expInfix)
        {
            string[] tokens = expInfix.Split(' ');
            int tokenCount = tokens.Count() - 1;
            string output = "";

            Stack<string> operators = new Stack<string>();

            for (int i = 0; i < tokenCount; i++)
            {
                if (!IsOperator(tokens[i]))
                {
                    output += tokens[i];
                    output += " ";
                }
                else if (tokens[i] == "(")
                {
                    operators.Push(tokens[i]);
                }
                else if (tokens[i] == ")")
                {
                    while (operators.Peek() != "(")
                    {
                        output += operators.Pop();
                        output += " ";
                    }

                    operators.Pop();
                }
                else if (IsOperator(tokens[i]))
                {
                    while (operators.Count > 0 && GetOpPriority(tokens[i]) <= GetOpPriority(operators.Peek()))
                    {
                        output += operators.Pop();
                        output += " ";
                    }

                    operators.Push(tokens[i]);
                }
            }
            while (operators.Count > 0)
            {
                output += operators.Pop();
                output += " ";
            }

            return output;
        }

        // Create expression, evaluate it, push onto stack
        private static void Operate(string inputSection, Stack<double> e)
        {
            Expression exp;

            switch (inputSection)
            {
                case "NEG":
                    {
                        double operand = e.Pop();

                        exp = new NegOp(operand);

                        e.Push(exp.Evaluate());
                    }
                    break;
                case "ABS":
                    {
                        double operand = e.Pop();

                        exp = new AbsOp(operand);

                        e.Push(exp.Evaluate());
                    }
                    break;
                case "+":
                    {
                        double operand2 = e.Pop();
                        double operand1 = e.Pop();

                        exp = new AddOp(operand1, operand2);

                        e.Push(exp.Evaluate());

                    }
                    break;
                case "-":
                    {
                        double operand2 = e.Pop();
                        double operand1 = e.Pop();

                        exp = new SubOp(operand1, operand2);

                        e.Push(exp.Evaluate());
                    }
                    break;
                case "*":
                    {
                        double operand2 = e.Pop();

                        double operand1 = e.Pop();

                        exp = new MultOp(operand1, operand2);

                        e.Push(exp.Evaluate());
                    }
                    break;
                case "/":
                    {
                        double operand2 = e.Pop();

                        double operand1 = e.Pop();

                        exp = new DivOp(operand1, operand2);

                        e.Push(exp.Evaluate());
                    }
                    break;
            }
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

        // Gets called when any of the digits or decimals are clicked on
        public void NumClick(object sender, EventArgs e)
        {
            if (_inputRestricted == true) return;
            if (_syntaxError == true) return;
            
            Button b = (Button)sender;

            if (_decimalClicked && b.Text == @".") return;

            // Removes leading 0 in number entry
            if (result.Text == @"0" && b.Text != @".") result.Clear();

            // Appends clicked character to number entry 
            result.Text += b.Text;

            if (!_decimalClicked && b.Text == @".") _decimalClicked = true;
        }

        // Gets called when any of the operators are clicked on
        private void OperatorClick(object sender, EventArgs e)
        {
            if (_syntaxError) return;
            
            Button b = (Button)sender;

            // Adds the data in number entry to equation 
            equation.Text += (result.Text + b.Text);
            _input += (result.Text += @" " + b.Text + @" ");

            // Reset data entry with 0
            result.Clear();
            result.Text += @"0";

            _inputRestricted = false;
            _decimalClicked = false;
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            if (_syntaxError) return;
            
            // Add space at the end of equation for evaluation
            _input += (result.Text + " ");

            // 
            if (_input.IndexOf("/ 0", StringComparison.Ordinal) != -1)
            {
                result.Text = @"SYNTAX ERROR";
                equation.Text = "";
                _input = "";

                _syntaxError = true;
                return;
            }

            // 
            Stack<double> expStack = new Stack<double>();

            // Converts from postfix to infix 
            string expPostfix = ToPostfix(_input);

            // Split postfix expression into its tokens
            string[] tokens = expPostfix.Split(' ');
            int tokenCount = tokens.Count() - 1;

            // Tokens are processed in expStack
            for (int i = 0; i < tokenCount; i++)
            {
                if (IsOperator(tokens[i]))
                {
                    Operate(tokens[i], expStack);
                }
                else
                {
                    expStack.Push(double.Parse(tokens[i]));
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
            _decimalClicked = false;
        }

        // Removes last character from string in number entry
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (_inputRestricted) return;
            if (_syntaxError) return;

            if (result.Text[result.Text.Length - 1] == '.') _decimalClicked = false; 
            if (result != null) result.Text = result.Text.Length <= 1 ? @"0" : result.Text.Substring(0, result.Text.Length - 1);
        }

        // Removes all text from both equation and number entry
        private void buttonClear_Click(object sender, EventArgs e)
        {
            if (result != null) result.Text = @"0";
            if (equation != null) equation.Text = "";
            _input = "";

            if (_inputRestricted) _inputRestricted = false;
            if (_syntaxError) _syntaxError = false;
            _decimalClicked = false;
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
