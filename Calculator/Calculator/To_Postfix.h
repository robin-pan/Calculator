#include "stdafx.h"
#include <iostream>
#include <stack>
#include <queue>
#include <string>
#include <sstream>
#include "Token.h"

using namespace std;

bool isOperator(string token);

string toPostfix(string exp_infix);

string queueToString(queue <string> &output);