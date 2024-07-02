#include <iostream>


class Complex
{
public:	
	double Re, Im;

public:	
	Complex(double a = 0.0, double b = 0.0) 
	{
		Re = a;
		Im = b;
	}

	Complex operator +(const Complex& c)const{
				return Complex(Re + c.Re, Im + c.Im);
			}

	Complex operator -(const Complex& c)const {
		return Complex(Re - c.Re, Im - c.Im);
	}

	Complex operator *(const Complex& c)const
	{
		return Complex(Re * c.Re - Im * c.Im, Re * c.Im + c.Re * Im);
	}

	Complex operator / (const Complex& c)const
	{
		return Complex((Re * c.Re + Im * c.Im) / (c.Re * c.Re + c.Im * c.Im), (-Re * c.Im + c.Re * Im) / (c.Re * c.Re + c.Im * c.Im));
	}
};

inline std::ostream& operator << (std::ostream& o, const Complex& c){
		return o << '(' << c.Re << ", " << c.Im << ')';
	}

Complex Conjugate(Complex a) {
	a.Im = -a.Im;
	return a;
}

double Mod(Complex a) {
	return sqrt(a.Re * a.Re + a.Im * a.Im);
}

double Arg(Complex a) {
	if (Mod(a) == 0) return 0;
	if (a.Re > 0) return atan(a.Im / a.Re);
	if (a.Re < 0) {
		if (a.Im >= 0) return acos(-1) + atan(a.Im / a.Re);
		if (a.Im < 0) return -acos(-1) - atan(a.Im / a.Re);
	}
	else{
		if (a.Im > 0) return acos(0);
		if (a.Im < 0) return -acos(0);
	}
}

