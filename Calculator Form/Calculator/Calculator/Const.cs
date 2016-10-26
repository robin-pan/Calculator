namespace Calculator
{
    class Const : Expression {
        protected int _value;

        protected Const(int value) : base() {
            _value = value;
        }

        public override int Evaluate() {
            return _value;
        }
    };
}