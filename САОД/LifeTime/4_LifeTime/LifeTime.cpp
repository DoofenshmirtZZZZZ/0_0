

#include <iostream>
#include <string>
#include "Test.h"

Test Jack = Test();

using namespace std;

int main()
{
    cout << "Start work " << endl;

    Test Tom = Test();
    Test Fred = Test();
    Test* p = new Test;
    Test* pc = new Test[2]{ };
    Test Djon = Tom;
    delete p;
    delete[] pc;

    Child Liza = Child();

    Aggregate Dominic = Aggregate(Tom);

    AggregateT<Test> Eric = AggregateT<Test>{ Tom };
    AggregateT<Child> Mira = AggregateT<Child>{ Tom };

    cout << "End work " << endl;
}

