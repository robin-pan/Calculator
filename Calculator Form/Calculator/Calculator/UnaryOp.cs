namespace Calculator
{
    public abstract class UnaryOp : Expression {
        protected double _operand;

        protected UnaryOp(double operand) {
            _operand = operand;
        }
    };
}