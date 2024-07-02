#include <iostream>


class Complex
{
public:	
	double re, im;

public:	
	Complex(double a = 0.0, double b = 0.0) 
	{
		re = a;
		im = b;
	}

	Complex operator +(const Complex& c)const{
				return Complex(re + c.re, im + c.im);
			}

	Complex operator -(const Complex& c)const {
		return Complex(re - c.re, im - c.im);
	}

	Complex operator *(const Complex& c)const
	{
		return Complex(re * c.re - im * c.im, re * c.im + c.re * im);
	}

	Complex operator / (const Complex& c)const
	{
		return Complex((re * c.re + im * c.im) / (c.re * c.re + c.im * c.im), (-re * c.im + c.re * im) / (c.re * c.re + c.im * c.im));
	}
};

inline std::ostream& operator << (std::ostream& o, const Complex& c){
		return o << '(' << c.re << ", " << c.im << ')';
	}

Complex Conjugate(Complex a) {
	a.im = -a.im;
	return a;
}

double doubleMod(Complex a) {
	return sqrt(a.re * a.re + a.im * a.im);
}

double Arg(Complex a) {
	if (doubleMod(a) == 0) return 0;
	if (a.re > 0) return atan(a.im / a.re);
	if (a.re < 0) {
		if (a.im >= 0) return acos(-1) + atan(a.im / a.re);
		if (a.im < 0) return -acos(-1) - atan(a.im / a.re);
	}
	else{
		if (a.im > 0) return acos(0);
		if (a.im < 0) return -acos(0);
	}
}

