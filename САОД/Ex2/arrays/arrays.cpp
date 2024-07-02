// arrays.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
using namespace std;

void rotate(int a[], int n, bool clockwise)
{
	int x;
	int *p = a;
	int *f = a;
	if (clockwise)
	{
		x = a[0];
		for (int c = 0; c <= n; c++)
			*(p + c) = *(p + c + 1);
		a[n - 1] = x;
	}
	else
	{
		x = a[n - 1];
		for (int c = n - 2; c >= 0; c--)
			*(p + c + 1) = *(p + c);
		a[0] = x;
	}

}


int main()
{
	int a[5]{ 1,2,3,4,5 };
	for (int i = 0; i < 5; i++)
		cout << a[i] << ' ';
	cout << endl;

	for (int* p = a; p - a < 5; p++)
		cout << *p << ' ';
	cout << endl;


	rotate(a, 5, true);
	
	for (int* p = a; p - a < 5; p++)
		cout << *p << ' ';
	cout << endl;
}
