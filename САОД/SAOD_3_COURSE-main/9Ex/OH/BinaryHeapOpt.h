#pragma once
#include <vector>
#include <exception>
#include <iostream>
class BinaryHeapOpt
{
public:
	int size;
	int* h;
	BinaryHeapOpt(int* ar, int len) : h(new int[len]), size(len) {
		for (int i = 0; i < len; i++)
			h[i] = ar[i];
		BuildHeap();

	};
	~BinaryHeapOpt()
	{
		delete[] h;
	};
	void FixHeap(int i, int length)
	{
		int left = 2 * i + 1, right = left + 1, largest;
		if ((left <= length) && (h[left] > h[i]))
			largest = left;
		else
			largest = i;
		if (right <= length && h[right] > h[largest])
			largest = right;
		if (largest != i)
		{
			int temp = h[i];
			h[i] = h[largest];
			h[largest] = temp;
			FixHeap(largest, length);
		}
	}

	void BuildHeap()
	{
		for (int i = size / 2; i >= 0; i--)
			FixHeap(i, size - 1);
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

