namespace Calculator
{
    public class DivOp : BinaryOp {
        public DivOp(double operand1, double operand2) : base(operand1, operand2) {}

        public override double Evaluate()
        {
            return Operand1 / Operand2;
        }
    };
}