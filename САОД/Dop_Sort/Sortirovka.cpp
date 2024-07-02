// Sortirovka.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//
#include <iostream>
#include <string>
using namespace std;
int main(int argc, char** argv)
{
	double* numbers = new double[argc + 2];
	bool forward = true;
	int count = 0;
	double temp;
	for (size_t i = 0; i < argc; i++)
	{
		if (*argv[i] == 'p')
			forward = true;
		else if (*argv[i] == 'b')
			forward = false;
		if (isdigit(*argv[i]))
			numbers[count++] = std::stoi(argv[i]);
	}
	for (size_t i = 0; i < count - 1; i++)
		for (size_t j = 0; j < count - i - 1; j++)
			if (((forward) && (numbers[j] > numbers[j + 1])) || ((!forward) && (numbers[j] < numbers[j + 1])))
			{
				temp = numbers[j];
				numbers[j] = numbers[j + 1];
				numbers[j + 1] = temp;
			}
	for (int i = 0; i < count; i++)
		cout << numbers[i] << endl;
	delete [] numbers;
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
