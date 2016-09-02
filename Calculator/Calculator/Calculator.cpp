#include "stdafx.h"
#include <iostream>
#include <stack>
#include <string>
#include <sstream>
#include "Token.h"

using namespace std;

class Expression;
typedef stack <int> ExpStack;

class Expression {
public:
	virtual int evaluate() = 0;
};

class Const : public Expression {
protected:
	int _value;

	Const(int value) : Expression() {
		_value = value;
	}

public:
	int evaluate() {
		return _value;
	}
};

class BinaryOp : public Expression {
protected:
	int _operand1;
	int _operand2;

	BinaryOp(int operand1, int operand2) : Expression() {
		_operand1 = operand1;
		_operand2 = operand2;
	}
};

class AddOp : public BinaryOp {
public:
	AddOp(int operand1, int operand2) : BinaryOp(operand1, operand2) {}

	int evaluate() {
		return _operand1 + _operand2;
	}
};

class SubOp : public BinaryOp {
public:
	SubOp(int operand1, int operand2) : BinaryOp(operand1, operand2) {}

	int evaluate() {
		return _operand1 - _operand2;
	}
};

class MultOp : public BinaryOp {
public:
	MultOp(int operand1, int operand2) : BinaryOp(operand1, operand2) {}

	int evaluate() {
		return _operand1 * _operand2;
	}
};

// TODO Account for 0
class DivOp : public BinaryOp {
public:
	DivOp(int operand1, int operand2) : BinaryOp(operand1, operand2) {}

	int evaluate() {
		return _operand1 / _operand2;
	}
};

class UnaryOp : public Expression {
protected:
	int _operand;

	UnaryOp(int operand) {
		_operand = operand;
	}
};

class AbsOp : public UnaryOp {
public:
	AbsOp(int operand) : UnaryOp(operand) {}

	int evaluate() {
		if (_operand < 0) return 0 - _operand;
		else return _operand;
	}
};

class NegOp : public UnaryOp {
public:
	NegOp(int operand) : UnaryOp(operand) {
	}

	int evaluate() {
		return -1 * _operand;
	}
};

// Create, evaluate, push
void operate(string input_section, ExpStack &e) {
	Expression* exp;

	if (input_section.compare("NEG") == 0) {
		int operand = e.top();
		e.pop();

		exp = new NegOp(operand);

		e.push(exp->evaluate());

		delete[] exp;
	}
	else if (input_section.compare("ABS") == 0) {
		int operand = e.top();
		e.pop();

		exp = new AbsOp(operand);

		e.push(exp->evaluate());

		delete[] exp;
	}
	else if (input_section.compare("+") == 0) {
		int operand2 = e.top();
		e.pop();

		int operand1 = e.top();
		e.pop();

		exp = new AddOp(operand1, operand2);

		e.push(exp->evaluate());

		delete[] exp;
	}
	else if (input_section.compare("-") == 0) {
		int operand2 = e.top();
		e.pop();

		int operand1 = e.top();
		e.pop();

		exp = new SubOp(operand1, operand2);

		e.push(exp->evaluate());

		delete[] exp;
	}

	else if (input_section.compare("*") == 0) {
		int operand2 = e.top();
		e.pop();

		int operand1 = e.top();
		e.pop();

		exp = new MultOp(operand1, operand2);

		e.push(exp->evaluate());

		delete[] exp;
	}

	else if (input_section.compare("/") == 0) {
		int operand2 = e.top();
		e.pop();

		int operand1 = e.top();
		e.pop();

		exp = new DivOp(operand1, operand2);

		e.push(exp->evaluate());

		delete[] exp;
	}
}

void display_result(ExpStack e) {
	cout << e.top() << endl;
}

int main()
{
	ExpStack exp_stack;

	string input = "";
	getline(cin, input);

	input = format(input);

	int token_count = count_tokens(input);

	for (int i = 1; i <= token_count; i++) {
		string token = nth_token(input, i);

		if (token.compare("NEG") == 0 || token.compare("ABS") == 0 || token.compare("+") == 0 || token.compare("-") == 0 || 
			token.compare("*") == 0 || token.compare("/") == 0) {
			operate(token, exp_stack);
		}

		else {
			exp_stack.push(stoi(token));
		}

	}

	display_result(exp_stack);

	return 0;
}
