#include "Test.h"

int Test::nCount = 0;
int i;

Test::Test()
{
	i = 1;
	nCount++;
	cout << "Test_Constructor / nCount = " << nCount << endl;
}
Test::~Test()
{
	nCount--;
	cout << "Test_Destructor  / nCount = " << nCount << endl;
}
Test::Test(const Test& s)
{
	nCount++;
	i = s.i;
	cout << "Test_Copi / nCount = " << nCount << endl;
}

Child::Child()
{
	cout << "Child_Constructor " << endl;
}
Child::~Child()
{
	cout << "Child_Destructor " << endl;
}

Aggregate::Aggregate(Test m_objTest)
{
	cout << "Aggregate_Constructor " << endl;
}
Aggregate::~Aggregate()
{
	cout << "Aggregate_Destructor " << endl;
}
