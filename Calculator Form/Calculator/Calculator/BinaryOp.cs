namespace Calculator
{
    public abstract class BinaryOp : Expression {
        protected double Operand1;
        protected double Operand2;

        protected BinaryOp(double operand1, double operand2) : base()
        {
            Operand1 = operand1;
            Operand2 = operand2;
        }
    };
}