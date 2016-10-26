namespace Calculator
{
    public class AddOp : BinaryOp {
        public AddOp(int operand1, int operand2) : base(operand1, operand2) {}

        public override int Evaluate()
        {
            return Operand1 + Operand2;
        }
    };
}