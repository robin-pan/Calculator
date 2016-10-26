namespace Calculator
{
    public class SubOp : BinaryOp
    {
        public SubOp(int operand1, int operand2) : base(operand1, operand2) {}

        public override int Evaluate()
        {
            return Operand1 - Operand2;
        }
    };
}