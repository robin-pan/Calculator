namespace Calculator
{
    public abstract class BinaryOp : Expression {
        protected int Operand1;
        protected int Operand2;

        protected BinaryOp(int operand1, int operand2) : base() {
            Operand1 = operand1;
            Operand2 = operand2;
        }
    };
}