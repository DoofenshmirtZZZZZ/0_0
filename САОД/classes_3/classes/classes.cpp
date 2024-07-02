#include <iostream>
#include "Complex.h" 
#include <cmath>

using namespace std;

int main()
{
    Complex c = Complex();
    cout << c << endl;
    Complex a(1, 2);
    Complex b(3);
    cout << a << ", " << b << endl;
    Complex sol = a - b;
    Complex sol2 = sol * b;
    Complex sol3 = sol / sol2;
    cout << a << " = " << sol3;
    cout << endl << " " << Mod(sol2) << endl;
    cout << endl << " " << Arg(sol2) << endl;

    Complex v[4]{ 1,2, Complex(2,3) };
    for (int i = 0; i < 4; i++) {
        cout << v[i] << " ";
    }

    Complex* pc = new Complex;
    new Complex(1);
    new Complex();
    pc = new Complex(1, 2);
    cout << *pc << endl;
    cout << "Re = " << pc->Re << " Im = " << pc->Im << endl;
    delete pc;
    Complex* pcc = new Complex[3]{ 1, 1, 1 };
    cout << pcc[1].Re;
    delete[] pcc;
}
