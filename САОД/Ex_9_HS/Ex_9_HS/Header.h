#pragma once
#include <vector>
#include <exception>
#include <iostream>
class HeapHeap
{
public:
	int size;
	int* h;
	HeapHeap(int* ar, int len) : h(new int[len]), size(len) {
		for (int i = 0; i < len; i++)
			h[i] = ar[i];
		BuildHeap();

	};
	~HeapHeap()
	{
		delete[] h;
	};
	int FixHeap(int i, int v[], int N) // i - индекс с которого нужно исправить кучу, v – массив, который представляет кучу, а N – его длина
	{
		int left = 2 * i + 1, right = left + 1, largest, count_fix;

		if ((left <= N) && (v[left] > v[i])) {
			largest = left;
			count_fix++;
		}	
		else
			largest = i;
		if (right <= N && v[right] > v[largest]) {
			largest = right;
			count_fix++;
		}
		if (largest != i)
		{
			int temp = h[i];
			h[i] = h[largest];
			h[largest] = temp;
			FixHeap(largest, v, N);
		}
	}

	void BuildHeap()
	{
		for (int i = size / 2; i >= 0; i--)
			FixHeap(i,h, size - 1);
	}
	int operator [] (int i) const
	{
		try {
			if (i >= size)
				throw std::out_of_range("Index out of range");
		}
		catch (std::out_of_range)
		{
			std::cout << '\n';
			std::cout << "Index out of range. Error index ";
			return 2;
		}
		return h[i];
	}
};


