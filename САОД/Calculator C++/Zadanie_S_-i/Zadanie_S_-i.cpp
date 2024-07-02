// Zadanie_S_-i.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include <string>

int main(int argc, char** argv)
{
		float temp = 0;
		int action = 0;
		for (size_t i = 0; i < argc; i++)
		{
		    std::cout << argv[i] << '\n';
		}
		return 0;
		for (size_t i = 0; i < argc; i++)
		{
			switch (isdigit(*argv[i]))
			{
			case 0:
			{
				temp = std::stoi(argv[i]);
				break;
			}
			case 1:
			{
				temp += std::stoi(argv[i]);
				action = 0;
				std::cout << temp << '\n';
				break;
			}
			case 2:
			{
				temp -= std::stoi(argv[i]);
				action = 0;
				std::cout << temp << '\n';
				break;
			}
			case 3:
			{
				temp /= std::stoi(argv[i]);
				action = 0;
				std::cout << temp << '\n';
				break;
			}
			case 4:
			{
				temp *= std::stoi(argv[i]);
				action = 0;
				std::cout << temp << '\n';
				break;
			}
				
			}
			if (!isdigit(*argv[i]))
			{
				if (*argv[i] == '+')
					action = 1;
				else if (*argv[i] == '-')
					action = 2;
				else if (*argv[i] == '/')
					action = 3;
				else if (*argv[i] == '*')
					action = 4;
			}
	  //      std::cout << argv[i] << std::endl;
		}
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
