#include <iostream>
#include "Complex.h" 
#include <cmath>
using namespace std;

int main()
{
    Complex c = Complex();
    cout << c << endl;
    Complex a(1, 2);
    Complex b = 3;
    cout << a << ", " << b << endl;
    Complex um = a * b;
    Complex del = um / b;
    cout << a << " = " << del;
    cout << endl << " " << doubleMod(a) << endl;
    Complex nums[5] = { 1, 2, Complex(2,3) };
    for (int i = 0; i < 4; i++) {
        cout << nums[i] << " ";
    }
    cout << endl;

    int i = 0;

    Complex* pc = new Complex;
    new Complex(1);
    new Complex();
    pc = new Complex(1);
    cout << *pc << endl;
    cout << "Re = " << pc -> re << " Im = " << pc -> im << endl;
    delete pc;
    Complex* pcc = new Complex[3]{1, 1, 1};
    cout << pcc[1].re;
    delete[] pcc;
}
