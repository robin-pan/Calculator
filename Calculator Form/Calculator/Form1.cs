using System;
using System.Collections;
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
        private static Hashtable states = new Hashtable()
        {
            {"AOND", new State("AOND", false)},
            {"AON", new State("AON", true)},
            {"PC", new State("PC", false)}
        };

        // Transitions to new state based on input
        private bool Transition(string input)
        {
            switch (_currentState._name)
            {
                case "AOND":
                    {
                        if (input == "num") _currentState = (State)states["AOND"];
                        else if (input == "dec") _currentState = (State)states["AON"];
                        else if (input == "del num") _currentState = (State)states["AOND"];
                        else if (input == "op") _currentState = (State)states["AOND"];
                        else if (input == "eq") _currentState = (State)states["PC"];
                        else return false;
                    }
                    break;
                case "AON":
                    {
                        if (input == "num") _currentState = (State)states["AON"];
                        else if (input == "del num") _currentState = (State)states["AON"];
                        else if (input == "del dec") _currentState = (State)states["AOND"];
                        else if (input == "op") _currentState = (State)states["AOND"];
                        else if (input == "eq") _currentState = (State)states["PC"];
                        else return false;
                    }
                    break;
                case "PC":
                    {
                        _input = "";
                        
                        if (input == "num")
                        {
                            _currentState = (State)states["AOND"];
                            result.Text = @"0";
                        }
                        else if (input == "dec")
                        {
                            _currentState = (State)states["AON"];
                            result.Text = @"0";
                        }
                        else if (input == "op")
                        {
                            _currentState = (State)states["AOND"];
                        }
                        else if (input == "eq")
                        {
                            _currentState = (State)states["PC"];
                        }
                        else if (input == "del num" || input == "del dec")
                        {
                            _currentState = (State)states["AOND"];
                            result.Text = @"0";
                        }
                        else return false;
                    }
                    break;
                }

                return true;
        }

        private static State _currentState = (State)states["AOND"];
        private static string _input = "";
        
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

        // Takes string expression and simplifies to single number
        private static String Evaluate(String input)
        {
            Stack<double> expStack = new Stack<double>();

            // Converts from postfix to infix 
            string expPostfix = ToPostfix(input);

            // Split postfix expression into its tokens
            string[] tokens = expPostfix.Split(' ');
            int tokenCount = tokens.Count() - 1;

            // Tokens are processed in expStack
            for (int i = 0; i < tokenCount; i++)
            {
                if (IsOperator(tokens[i])) Operate(tokens[i], expStack);
                else expStack.Push(double.Parse(tokens[i]));
            }

            // Top of expStack is the result
            return expStack.Peek().ToString();
        }

        // Create expression, evaluate it, push onto stack
        private static void Operate(string inputSection, Stack<double> e)
        {
            Expression exp;

            switch (inputSection)
            {
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

        // Gets called when any of the digits are clicked on
        public void NumClick(object sender, EventArgs e)
        {
            if (!Transition("num")) return;
            
            Button b = (Button)sender;

            // Removes leading 0 in number entry
            if (result.Text == @"0") result.Clear();

            // Appends clicked character to number entry 
            result.Text += b.Text;
        }

        // Gets called when any of the decimal is clicked on
        public void DecimalClick(object sender, EventArgs e)
        {
            if (_currentState._decimalLocked || !Transition("dec")) return;
            
            Button b = (Button)sender;

            // Appends clicked character to number entry 
            result.Text += b.Text;
        }

        public void BracketClick(object sender, EventArgs e)
        {
            if (!Transition("op")) return;

            Button b = (Button)sender;
            
            if (b.Text == "(")
            {
                equation.Text += @"(";
                _input += (@"( ");
            }
            else if (b.Text == ")")
            {
                if (equation.Text.Length > 0 && equation.Text[equation.Text.Length - 1] == ')')
                {
                    equation.Text += @")";
                    _input += @") ";
                }
                else
                {
                    equation.Text += result.Text + @")";
                    _input += result.Text + @" ) ";
                }

                // Reset data entry with 0
                result.Text = @"0";
            }
        }

        // Gets called when any of the binary operators are clicked on
        private void BinaryOperatorClick(object sender, EventArgs e)
        {
            if (!Transition("op")) return;

            Button b = (Button)sender;

            // Adds the data in number entry to equation 
            if (equation.Text.Length > 0 && equation.Text[equation.Text.Length - 1] == ')')
            {
                equation.Text += b.Text;
                _input += b.Text + @" ";
            }
            else
            {
                equation.Text += (result.Text + b.Text);
                _input += (result.Text += @" " + b.Text + @" ");
            }

            // Reset data entry with 0
            result.Text = @"0";
        }

        // Gets called when any of the unary operators are clicked on
        private void UnaryOperatorClick(object sender, EventArgs e)
        {
            if (!Transition("op")) return;

            Button b = (Button)sender;

            if (b.Text == "+/-")
            {
                if (result.Text != "0")
                {
                    if (result.Text[0] == '-') result.Text = result.Text.Substring(1, result.Text.Length - 1);
                    else if (result.Text[0] != '-') result.Text = "-" + result.Text;
                }
            }
            else
            {
                
            }
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {            
            if (!Transition("eq")) return;
            
            // Add space at the end of equation for evaluation
            if (_input.Length == 0 || (_input.Length > 0 && _input[_input.Length - 2] != ')')) _input += (result.Text + " ");

            // Top of expStack is the result
            result.Text = Evaluate(_input).ToString();

            // Resets the equation, current result now first entry of subsequent calculations
            equation.Clear();

            _input = result.Text + " ";
        }

        // Removes last character from string in number entry
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            char lastChar = result.Text[result.Text.Length - 1];

            if (lastChar != '.' && !Transition("del num")) return;
            else if (lastChar == '.' && !Transition("del dec")) return;
            
            if (result != null) result.Text = result.Text.Length <= 1 ? @"0" : result.Text.Substring(0, result.Text.Length - 1);
            if (result.Text == @"-") result.Text = @"0";
        }

        // Removes all text from both equation and number entry
        private void buttonClearEntry_Click(object sender, EventArgs e)
        {
            if (result != null) result.Text = @"0";
        }

        // Removes all text from both equation and number entry
        private void buttonClear_Click(object sender, EventArgs e)
        {
            if (result != null) result.Text = @"0";
            if (equation != null) equation.Text = "";
            _input = "";
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
