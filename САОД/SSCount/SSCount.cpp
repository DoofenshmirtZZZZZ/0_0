// KMP.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "PF.h"

int main()
{
	// ѕример использовани€ класса PF.
	char s[] = "ghfhgfghfhfhgfhfhgfhghghghgf";
	PF pf;
	pf.Init(s);
	cout << s << endl;
	for (int i = 0; i < pf; i++)
		cout << pf[i];
	cout << endl;

	// ѕример перебора всех подстрок s длины 8, использу€ класс string.
	cout << endl;
	string str(s);
	for (int i = 0; i < str.length() - 7; i++)
		cout << str.substr(i, 8) << endl;

	// ѕример генерации случайной строки длины N.
	cout << endl;
	const int N = 50;
	char t[N]{ 0 };
	for (int i = 0; i < N - 1; i++)
		t[i] = rand() % ('z' - 'a') + 'a';
	cout << t << endl;

	return 0;
}
