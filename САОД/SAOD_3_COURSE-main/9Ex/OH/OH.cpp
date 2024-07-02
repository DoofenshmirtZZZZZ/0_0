// OH.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//
#include <vector>
#include <iostream>
#include "BinaryHeap.h"
#include <Windows.h>
#include "BinaryHeapOpt.h"

int main()
{
	LARGE_INTEGER li1, li2, lif;
	int m = 13;
	int n = 10;
	int k = 0;
	int* pm = new int[n];
	std::vector<int> v(n);
	int ch;
	for (int i = 0; i < n; i++)
	{
		ch = rand() % n;
		v.insert(v.begin(), ch);
		pm[i] = ch;
	}
	::QueryPerformanceFrequency(&lif);
	::QueryPerformanceCounter(&li1);
	
	for (int i = 0; i < m; i++)
	{
		//BinaryHeap bh(v, n);
		//k += bh[0];
		BinaryHeapOpt bh(pm, n);
		k += pm[0];
	}
	::QueryPerformanceCounter(&li2);
	int mcSec = (int)((double)((li2.QuadPart - li1.QuadPart) * 1000000) / (double)lif.QuadPart);
	std::cout << mcSec << std::endl;
	std::cout << k << std::endl;
}

// Запуск программы: CTRL+F5 или меню "Отладка" > "Запуск без отладки"
// Отладка программы: F5 или меню "Отладка" > "Запустить отладку"

// Советы по началу работы 
//   1. В окне обозревателя решений можно добавлять файлы и управлять ими.
//   2. В окне Team Explorer можно подключиться к системе управления версиями.
//   3. В окне "Выходные данные" можно просматривать выходные данные сборки и другие сообщения.
//   4. В окне "Список ошибок" можно просматривать ошибки.
//   5. Последовательно выберите пункты меню "Проект" > "Добавить новый элемент", чтобы создать файлы кода, или "Проект" > "Добавить существующий элемент", чтобы добавить в проект существующие файлы кода.
//   6. Чтобы снова открыть этот проект позже, выберите пункты меню "Файл" > "Открыть" > "Проект" и выберите SLN-файл.
