namespace Calculator
{
    public class Operation {
        private string Op;
        private int Priority;

        public Operation()
        {
            
        }

        public Operation(string op) 
        {
            Op = op;
		
            if (Op == "NEG" || Op == "ABS" || Op == "*" || Op == "/") 
            {
                Priority = 2;
            }

            else if (op == "(") {
                Priority = -1;
            }

            else {
                Priority = 1;
            }
        }

        public string getOp() {
            return Op;
        }

        public int getPriority() {
            return Priority;
        }
    };
}