#include "stdafx.h"
#include <iostream>
#include <stack>
#include <string>
#include <sstream>

using namespace std;

class Expression;
typedef stack <Expression*> ExpStack;

class Expression {
public:
	virtual bool evaluate(ExpStack exp_vals) = 0;
};

class Const_Op : public Expression {
private:
	int _value;

public:
	Const_Op(int value) {
		_value = value;
	}

	int get_value() {
		return _value;
	}

	bool evaluate(ExpStack exp_vals) {

		return true;
	}
};

class Binary_Op : public Expression {
private:
	int _operand1;
	int _operand2;
public:
	Binary_Op(int operand1, int operand2) {
		_operand1 = operand1;
		_operand2 = operand2;
	}

	bool evaluate(ExpStack exp_vals) {
		return true;
	}
};

class Unary_Op : public Expression {
private:
	int _operand;
public:
	Unary_Op(int operand) {
		_operand = operand;
	}

	bool evaluate(ExpStack exp_vals) {
		return true;
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

Expression* int_to_expression(int i) {
	cout << "int_to_expression() called" << endl;
	Expression * e;
	return e;
}

Expression* string_to_expression(string input_section) {
	if (input_section.compare("NEG")) true;
	else if (input_section.compare("ABS")) true;
	else if (input_section.compare("+")) true;
	else if (input_section.compare("-")) true;
	else if (input_section.compare("*")) true;
	else if (input_section.compare("/")) true;
		
	Expression* e;

	return e;
}

void display_result(ExpStack e) {
	cout << e.top()->evaluate(e) << endl;
}

int main()
{
	ExpStack exp_stack;
	
	string input = "";
	cin >> input;

	input = format(input);
	int expr_count = count_expressions(input);

	for (int i = 1; i <= expr_count; i++) {
		string input_section = nth_expression(input, i);

		if (input_section.compare("NEG") || input_section.compare("ABS") || input_section.compare("+") || input_section.compare("-") || input_section.compare("*") || input_section.compare("/")) {
			string_to_expression(input_section)->evaluate(exp_stack);
		}
		else {
			exp_stack.push(int_to_expression(stoi(input)));
		}
	}

	display_result(exp_stack);

	return 0;
}

