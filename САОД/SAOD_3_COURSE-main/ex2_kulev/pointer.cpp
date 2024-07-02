
#include <iostream>
#include "utils.h"

using namespace std;

int main()
{
	int a = 3, b = 5;

	int* pa = &a;
	int* pb = &b;

	Swap(pa, pb);

	cout << a << "  " << b << endl;

}


