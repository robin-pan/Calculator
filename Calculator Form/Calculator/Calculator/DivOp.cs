namespace Calculator
{
    // TODO Account for 0
    public class DivOp : BinaryOp {
        public DivOp(int operand1, int operand2) : base(operand1, operand2) {}

        public override int Evaluate()
        {
            return Operand1 / Operand2;
        }
    };
}