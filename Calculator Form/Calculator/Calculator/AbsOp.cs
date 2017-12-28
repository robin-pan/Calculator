namespace Calculator
{
    public class AbsOp : UnaryOp {
        public AbsOp(double operand) : base(operand) { }

        public override double Evaluate()
        {
            if (_operand < 0) return 0 - _operand;
            
            return _operand;
        }
    };
}