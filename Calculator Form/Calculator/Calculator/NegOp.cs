namespace Calculator
{
    public class NegOp : UnaryOp {
        public NegOp(double operand) : base(operand) {
        }

        public override double Evaluate()
        {
            return -1 * _operand;
        }
    };
}