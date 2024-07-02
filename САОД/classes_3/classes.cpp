#include <iostream>
#include "Complex.h" 
#include <cmath>
using namespace std;

int main()
{
    Complex c = Complex();
    cout << c << endl;
    Complex a(1, 2);
    Complex b(1, 2);
    cout << a << ", " << b << endl;
    Complex mul = a * b;
    Complex div = mul / b;
    cout << a << " = " << div;
    cout << endl << " " << Mod(div) << endl;
    Complex mas_n[4] = { 1, 2, Complex(2,3) };
    for (int i = 0; i < 4; i++) {
        cout << mas_n[i] << " ";
    }
    cout << endl;

    int i = 0;

    Complex* pc = new Complex;
    new Complex(1);
    new Complex();
    pc = new Complex(1, 2);
    cout << *pc << endl;
    cout << "Re = " << pc->Re << " Im = " << pc -> Im << endl;
    delete pc;
    Complex* pcc = new Complex[3]{1, 1, 1};
    cout << pcc[1].Re;
    delete[] pcc;
}
