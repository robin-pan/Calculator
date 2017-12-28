namespace Calculator
{
    class Const : Expression {
        protected double _value;

        protected Const(double value) : base() {
            _value = value;
        }

        public override double Evaluate() {
            return _value;
        }
    };
}