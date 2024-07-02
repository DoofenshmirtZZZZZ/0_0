#include <iostream>
#include "Test.h"
#include <string>


Test one = Test();

using namespace std;

int main()
{
    cout << "Start" << endl;

    Test One = Test();
    Test Two = Test();
    Test* p = new Test;
    Test* pc = new Test[2]{ };
    Test Three = One;
    delete p;
    delete[] pc;

    Child ok = Child();

    Aggregate kk = Aggregate(One);

    AggregateT<Test> j = AggregateT<Test>{ One };
    AggregateT<Child> l = AggregateT<Child>{ One };

    cout << "End" << endl;
}

