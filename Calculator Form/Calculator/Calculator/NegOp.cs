namespace Calculator
{
    public class NegOp : UnaryOp {
        public NegOp(int operand) : base(operand) {
        }

        public override int Evaluate()
        {
            return -1 * _operand;
        }
    };
}