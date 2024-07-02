#include <iostream>
#include "Str.h"
using namespace std;

int main()
{
	Str s = "12";
	Str b = "345678912";
	s += b;
	cout << s << endl;
	Str a = "12";
	
	cout << s.rfind(a, 10) << endl;
}

