#include <iostream>
#include "Str.h"

int main()
{
	Str a = "first_string_";
	Str b = "second_string";

	std::cout << std::endl << a << " + " << b << " = ";
	a += b;
	std::cout << a << std::endl << std::endl;


	Str test = "test_string";
	Str test_copy = test;
	test.reverse();
	std::cout << "not reversed copy of string = " << test_copy << std::endl << std::endl;


	Str palindrome = "qwewq";
	palindrome.reverse();

	return 0;
}