#pragma once
#include <vector>
#include <exception>
#include <iostream>
class BinaryHeap
{
public:
	std::vector<int> heap;
	BinaryHeap(std::vector<int> ar, int n) : heap(n) {
		for (int i = 0; i < n; i++)
			heap[i] = ar[i];
		BuildHeap();

	}
	~BinaryHeap()
	{
	};
	void FixHeap(int i, int length)
	{
		int left = 2 * i + 1, right = left + 1, largest;
		if ((left <= length) && (heap[left] > heap[i]))
			largest = left;
		else
			largest = i;
		if (right <= length && heap[right] > heap[largest])
			largest = right;
		if (largest != i)
		{
			int temp = heap[i];
			heap[i] = heap[largest];
			heap[largest] = temp;
			FixHeap(largest, length);
		}
	}

	void BuildHeap()
	{
		for (int i = heap.size() / 2; i >= 0; i--)
			FixHeap(i, heap.size() - 1);
	}
	int operator [] (int i) const
	{
		try{
		if (i >= heap.size())
			throw std::out_of_range("Index out of range");
		}
		catch (std::out_of_range)
		{
			std::cout << '\n';
			std::cout << "Index out of range. Error index ";
			return 0;
		}
		return heap[i];
	}
};

