#include "Test.h"

int Test::nCount = 0;
int g;

Test::Test()
{
	g = 1;
	nCount++;
	cout << "Test_class_Constructor / nCount = " << nCount << endl;
}
Test::~Test()
{
	nCount--;
	cout << "Test_class_Destructor  / nCount = " << nCount << endl;
}
Test::Test(const Test& s)
{
	nCount++;
	g = s.g;
	cout << "Test_class_Cop / nCount = " << nCount << endl;
}

Child::Child()
{
	cout << "Child_class_Constructor " << endl;
}
Child::~Child()
{
	cout << "Child_class_Destructor " << endl;
}

Aggregate::Aggregate(Test m_objTest)
{
	cout << "Aggregate_class_Constructor " << endl;
}
Aggregate::~Aggregate()
{
	cout << "Aggregate_class_Destructor " << endl;
}
