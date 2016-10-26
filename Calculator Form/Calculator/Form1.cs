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
        // Removes excess leading and trailing whitespace
        public static string TokenFormat(string input)
        {
            int input_len = input.Length;

            string formatted_input = "";

            int start = 0;
            int end = input_len - 1;

            for (; start < input_len; start++)
            {
                if (input[start] != ' ') break;
            }

            for (; end >= start; end--)
            {
                if (input[end] != ' ') break;
            }

            for (int i = start; i <= end; i++)
            {
                formatted_input += input[i];
            }

            formatted_input += ' ';

            return formatted_input;
        }

        // Must be formatted first
        public int TokenGetCount(string input)
        {
            int token_count = 0;
            int str_len = input.Length;

            for (int i = 0; i < str_len; i++)
            {
                if (input[i] == ' ')
                {
                    token_count++;
                }
            }

            return token_count;
        }

        // Gets the nth space in input
        int nth_space(string input, int n)
        {
            if (n == 0) return -1;

            int len = input.Length;

            for (int i = 0; i < len; i++)
            {
                if (input[i] == ' ')
                {
                    n--;
                }
                if (n == 0)
                {
                    return i;
                }
            }

            return -1;
        }

        // Gets the nth token in input
        public string nth_token(string input, int n)
        {
            int start = 0;
            int end = 0;

            string sliced_str = "";

            if (n == 1)
            {
                start = 0;
                end = nth_space(input, 1);
            }
            else
            {
                start = nth_space(input, n - 1) + 1;
                end = nth_space(input, n);
            }

            for (int i = start; i < end; i++)
            {
                sliced_str += input[i];
            }

            return sliced_str;
        }

        // Determines whether token is an operator
        bool isOperator(string token)
        {
            return token == "NEG" || token == "ABS" || token == "+" || token == "-" ||
            token == "*" || token == "/";
        }

        string queueToString(Queue<string> output) {
	        string str = "";

	        while (output.Count > 0)
	        {
	            str += output.Dequeue();
		        str += (" ");
	        }

	        return str;
        }

        // Converts equation from infix to post fix
        string toPostfix(string exp_infix) {
	        Stack<Operation> operations = new Stack<Operation>();
            Queue<string> output = new Queue<string>();

	        int token_count = TokenGetCount(exp_infix);

	        for (int i = 1; i <= token_count; i++) {
		        string token = nth_token(exp_infix, i);

		        if (isOperator(token)) {
			        Operation o = new Operation(token);

			        while ((operations.Count > 0) && (operations.Peek().getPriority() > o.getPriority())) {
				        output.Enqueue(operations.Peek().getOp());
				        operations.Pop();
			        }

			        operations.Push(o);
		        }

		        else if (token == "(") {

			        Operation o = new Operation(token);
			        operations.Push(o);
		        }

		        else if (token == ")") {

			        while (operations.Peek().getOp() != "(") {
				        output.Enqueue(operations.Peek().getOp());
				        operations.Pop();
			        }

			        operations.Pop();
		        }

		        else {
			        output.Enqueue(token);
		        }
	        }

	        while (operations.Count > 0) {
		        output.Enqueue(operations.Peek().getOp());
		        operations.Pop();
	        }

            return queueToString(output);
        }

        // Create expression, evaluate it, push onto stack
        public void operate(string input_section, Stack<int> e)
        {
            Expression exp;

            switch (input_section)
            {
                case "NEG":
                    {
                        int operand = e.Pop();

                        exp = new NegOp(operand);

                        e.Push(exp.Evaluate());
                    }
                    break;
                case "ABS":
                    {
                        int operand = e.Pop();

                        exp = new AbsOp(operand);

                        e.Push(exp.Evaluate());
                    }
                    break;
                case "+":
                    {
                        int operand2 = e.Pop();
                        int operand1 = e.Pop();

                        exp = new AddOp(operand1, operand2);

                        e.Push(exp.Evaluate());

                    }
                    break;
                case "-":
                    {
                        int operand2 = e.Pop();
                        int operand1 = e.Pop();

                        exp = new SubOp(operand1, operand2);

                        e.Push(exp.Evaluate());
                    }
                    break;
                case "*":
                    {
                        int operand2 = e.Pop();

                        int operand1 = e.Pop();

                        exp = new MultOp(operand1, operand2);

                        e.Push(exp.Evaluate());
                    }
                    break;
                case "/":
                    {
                        int operand2 = e.Pop();

                        int operand1 = e.Pop();

                        exp = new DivOp(operand1, operand2);

                        e.Push(exp.Evaluate());
                    }
                    break;
            }
        }

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
        
        string input = "";

        // Gets called when any of the digits are clicked on
        public void numClick(object sender, EventArgs e)
        {   
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
        private void operatorClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            // Adds the data in number entry to equation 
            equation.Text += (result.Text + b.Text);
            input += (result.Text += " " + b.Text + " ");

            // Reset data entry with 0
            result.Clear();
            result.Text += "0";
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            input += (result.Text + " ");

            /*Stack<int> exp_stack = new Stack<int>();

            string exp_postfix = toPostfix(input);

            int token_count = TokenGetCount(exp_postfix);

            for (int i = 1; i <= token_count; i++)
            {
                string token = nth_token(exp_postfix, i);

                if (isOperator(token))
                {
                    operate(token, exp_stack);
                }

                else
                {
                    exp_stack.Push(Int32.Parse(token));
                }

            }

            result.Text = exp_stack.Peek().ToString();*/

            Console.WriteLine(toPostfix("1 - 2 + 3 - 4 + 5 "));

            equation.Clear();
        }

        // Removes last character from string in number entry
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (result.Text.Length <= 1)
            {
                result.Text = "0";
            }
    
            else
            {
                result.Text = result.Text.Substring(0, result.Text.Length - 1);
            }
        }

        // Removes all text from both equation and number entry
        private void buttonClear_Click(object sender, EventArgs e)
        {
            result.Text = "0";
            equation.Text = "";
            input = "";
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
            Console.WriteLine(input);
        }
    }
}
