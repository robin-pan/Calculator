namespace Calculator
{
    public class AbsOp : UnaryOp {
        public AbsOp(int operand) : base(operand) {}

        public override int Evaluate()
        {
            if (_operand < 0) return 0 - _operand;
            
            return _operand;
        }
    };
}