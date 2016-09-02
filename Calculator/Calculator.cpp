#include "stdafx.h"
#include <iostream>
#include <stack>
#include <string>
#include <sstream>

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
	NegOp(int operand) : UnaryOp(operand) {}

	int evaluate() {
		return 0 - _operand;
	}
};

string format(string input) {
	cout << "format() called" << endl;

	return "";
}

void next_expression() {
	cout << "next_expression() called" << endl;
}

// Must be formatted first
int count_expressions(string input) {
	cout << "int count_expressions() called" << endl;
	return 5;
}

// Count starts from 1
string nth_expression(string input, int n) {
	cout << "int nth_expression() called" << endl;
	return "";
}

// Create, evaluate, push
void operate(string input_section, ExpStack &e) {
	Expression* exp;

	if (input_section.compare("NEG")) {
		int operand = e.top();
		e.pop();

		exp = new NegOp(operand);

		e.push(exp->evaluate());
	}
	else if (input_section.compare("ABS")) {
		int operand = e.top();
		e.pop();

		exp = new AbsOp(operand);

		e.push(exp->evaluate());
	}
	else if (input_section.compare("+")) {
		int operand2 = e.top();
		e.pop();

		int operand1 = e.top();
		e.pop();

		exp = new AddOp(operand1, operand2);

		e.push(exp->evaluate());
	}
	else if (input_section.compare("-")) {
		int operand2 = e.top();
		e.pop();

		int operand1 = e.top();
		e.pop();

		exp = new SubOp(operand1, operand2);

		e.push(exp->evaluate());
	}

	else if (input_section.compare("*")) {
		int operand2 = e.top();
		e.pop();

		int operand1 = e.top();
		e.pop();

		exp = new MultOp(operand1, operand2);

		e.push(exp->evaluate());
	}

	else if (input_section.compare("/")) {
		int operand2 = e.top();
		e.pop();

		int operand1 = e.top();
		e.pop();

		exp = new DivOp(operand1, operand2);

		e.push(exp->evaluate());
	}
}

void display_result(ExpStack e) {
	cout << e.top() << endl;
}

int main()
{
	ExpStack exp_stack;

	string input = "";
	cin >> input;

	input = format(input);
	int expr_count = count_expressions(input);

	for (int i = 1; i <= expr_count; i++) {
		string token = nth_expression(input, i);

		if (token.compare("NEG") || token.compare("ABS") || token.compare("+") || token.compare("-") || token.compare("*") || token.compare("/")) {
			operate(token, exp_stack);
		}
		else {
			exp_stack.push(stoi(input));
		}
	}

	display_result(exp_stack);

	return 0;
}
