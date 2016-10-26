namespace Calculator
{
    public abstract class UnaryOp : Expression {
        protected int _operand;

        protected UnaryOp(int operand) {
            _operand = operand;
        }
    };
}