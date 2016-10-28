using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator
{
    public class Calculate
    {
        // Determines whether token is an operator
        public static bool IsOperator(string token)
        {
            return token == "NEG" || token == "ABS" || token == "+" || token == "-" ||
            token == "*" || token == "/" || token == "(" || token == ")";
        }

        public static int GetOpPriority(string op)
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
        public static string ToPostfix(string expInfix)
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
        public static void Operate(string inputSection, Stack<int> e)
        {
            Expression exp;

            switch (inputSection)
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

    }
}