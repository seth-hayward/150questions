// Question1.2.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <string>
using namespace std;

int main(int argc, char *argv[])
{

	void reverse(char *str);

	//
	// Question 1.2
	//
	// Implement a function void reverse(char *str) in C or C++ which reverses
	// a null-terminated string.
	//

	// Not sure why if there is no parameters, argc = 1...
	if(argc == 2) {

		char *phrase_to_reverse = argv[1];
		reverse(phrase_to_reverse);

	} else {
		cout << "You passed too many parameters or not enough. There should only be one.\n";
		return 0;
	}

	return 0;
}

void reverse(char *str)
{

	//cout << "Called from the reverse method: " << str << endl;
	//cout << "Size: " << strlen(str) << endl;

	// This will iterate over the char in reverse...
	int last_index = strlen(str) - 1;
	for (int x = last_index; x >= 0; x--) {
		cout << str[x];
	}
	cout << endl;

	// but it does not work with null terminated
	// strings. This does not show the null-terminated
	// character either ('\0') -- but maybe trying
	// to support this is making the question too hard?
	//
	//for(int a = 0; a < strlen(str); a++) {
	//	cout << a << ": " << str[a] << endl;
	//}

}

