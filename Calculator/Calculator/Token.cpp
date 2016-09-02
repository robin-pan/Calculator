#include "Token.h"

string format(string input) {
	int input_len = input.length();

	string formatted_input = "";

	int start = 0;
	int end = input_len - 1;

	for (; start < input_len; start++) {
		if (input[start] != ' ') break;
	}

	for (; end >= start; end--) {
		if (input[end] != ' ') break;
	}

	for (int i = start; i <= end; i++) {
		formatted_input += input[i];
	}

	formatted_input += ' ';

	return formatted_input;
}

// Must be formatted first
int count_tokens(string input) {
	int token_count = 0;
	int str_len = input.length();

	for (int i = 0; i < str_len; i++) {
		if (input[i] == ' ') {
			token_count++;
		}
	}

	return token_count;
}

// Count starts from 1
int nth_space(string input, int n) {
	if (n == 0) return -1;

	int len = input.length();

	for (int i = 0; i < len; i++) {
		if (input[i] == ' ') {
			n--;
		}
		if (n == 0) {
			return i;
		}
	}

	return -1;
}

// Count starts from 1
string nth_token(string input, int n) {
	int start = 0;
	int end = 0;
	int len = 0;

	string sliced_str = "";

	if (n == 1) {
		start = 0;
		end = nth_space(input, 1);
	}
	else {
		start = nth_space(input, n - 1) + 1;
		end = nth_space(input, n);
	}

	for (int i = start; i < end; i++) {
		sliced_str += input[i];
	}

	return sliced_str;
}