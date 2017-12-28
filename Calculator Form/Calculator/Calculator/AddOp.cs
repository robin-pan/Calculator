namespace Calculator
{
    public class AddOp : BinaryOp {
        public AddOp(double operand1, double operand2) : base(operand1, operand2) { }

        public override double Evaluate()
        {
            return Operand1 + Operand2;
        }
    };
}