#pragma once
#include <iostream>
#include <string>
using namespace std;

class Test
{
	public:
		static int nCount;
		int i;
		Test();
		~Test();
		Test(const Test& s);
};

class Child : public Test
{
	public:
		Child();
		~Child();
};

class Aggregate
{
	public:
		Aggregate(Test m_objTest);
		~Aggregate();
};

template <typename T> class AggregateT
{
	public:
		AggregateT(Test m_objTest);
		~AggregateT();
};
template <typename T> AggregateT<T>::AggregateT(Test m_objTest)
{
	cout << "AggregateT_Constructor " << endl;
}
template <typename T> AggregateT<T>::~AggregateT()
{
	cout << "AggregateT_Destructor " << endl;
}



