#include "To_Postfix.h"

class Operation {
private:
	string _op;
	int _priority;
public:
	Operation() {

	}

	Operation(string op) {
		_op = op;
		
		if (op.compare("NEG") == 0 || op.compare("ABS") == 0 || op.compare("*") == 0 || op.compare("/") == 0) {
			_priority = 2;
		}

		else if (op.compare("(") == 0) {
			_priority = -1;
		}

		else {
			_priority = 1;
		}
	}

	string getOp() {
		return _op;
	}

	int getPriority() {
		return _priority;
	}
};

bool isOperator(string token) {
	return (token.compare("NEG") == 0 || token.compare("ABS") == 0 || token.compare("+") == 0 || token.compare("-") == 0 ||
		token.compare("*") == 0 || token.compare("/") == 0);
}

string toPostfix(string exp_infix) {
	stack <Operation *> operations;
	queue <string> output;

	int token_count = count_tokens(exp_infix);

	for (int i = 1; i <= token_count; i++) {
		string token = nth_token(exp_infix, i);

		if (isOperator(token)) {
			Operation* o = new Operation(token);

			while (!operations.empty() && operations.top()->getPriority() > o->getPriority()) {
				output.push(operations.top()->getOp());
				delete operations.top();
				operations.pop();
			}

			operations.push(o);
		}

		else if (token.compare("(") == 0) {

			Operation* o = new Operation(token);
			operations.push(o);
		}

		else if (token.compare(")") == 0) {

			while (operations.top()->getOp().compare("(") != 0) {
				output.push(operations.top()->getOp());
				delete operations.top();
				operations.pop();
			}

			delete operations.top();
			operations.pop();
		}

		else {
			output.push(token);
		}
	}

	while (!operations.empty()) {
		output.push(operations.top()->getOp());
		delete operations.top();
		operations.pop();
	}

	return queueToString(output);
}

string queueToString(queue <string> &output) {
	string str = "";

	while (!output.empty()) {
		str.append(output.front());
		str.append(" ");
		output.pop();
	}

	return str;
}