﻿
#include <iostream>
#include "utils.h"

using namespace std;

int main()
{
	/*
	int x = 3;
	int* p = &x;
	cout << x << ' ' << *p << ' ' << p << endl;

	p++;
	cout << p << endl;

	cout << p - &x << endl;

	typedef unsigned char byte; 	// Нет встроенного byte
	byte* pb = (byte*)--p;		// вернули указатель на x и преобразовали
	for (byte* pt = pb; pt - pb < sizeof(int); pt++)
		cout << (int)*pt << ' ';	// выводим как int
	cout << endl;
	*/

	// обявляем переменные, затем делаем указатели, после вызываем функцию Swap 
	// куда передаем указатели для обмена значениями, выводим ответ

	int a = 3, b = 5;

	int* pa = &a;
	int* pb = &b;

	Swap(pa, pb);

	cout << a << "  " << b << endl;

}


