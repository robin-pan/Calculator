namespace Calculator
{
    public class FactOp : UnaryOp
    {
        public FactOp(double operand) : base(operand) { }

        public override double Evaluate()
        {
            return factorial(_operand, 1);
        }

        private double factorial(double n, double acc) 
        {
            return (n == 0) ? acc : factorial(n - 1, acc * n);
        }
    };
}