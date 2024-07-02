#include <iostream>
#include "Test.h"
#include <list>
#include <set>
#include <string>



int main() {

	Test a(5);
	Test b(3);
	Test c(7);

	std::list <Test> objs = { a, b, c };

	objs.sort();

	for (auto iter = objs.begin(); iter != objs.end(); iter++)
	{
		*iter  << cout;
	}

	cout << endl;

	std::set<Test> objs_2;

	objs_2.insert(a);
	objs_2.insert(b);

	cout << objs_2.size() << endl;

	cout << endl;

	objs.remove(a);
	
	for (auto iter = objs.begin(); iter != objs.end(); iter++)
	{
		*iter << cout;
	}

	

}

	

	