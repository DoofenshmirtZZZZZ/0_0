
#include <iostream>
#include <string>

using namespace std;

template <typename T, typename K, typename M>
int FixHeap(T arr[], K n, M i)
{
	int largest = i;
	int l = 2 * i + 1;
	int r = 2 * i + 2; 
	int result = 0;

	if (l < n && arr[l] > arr[largest])
		largest = l;

	if (r < n && arr[r] > arr[largest])
		largest = r;

	if (largest != i) {
		swap(arr[i], arr[largest]);
		result++;
	}
		
	return result;
}

template <typename T, typename K>
void printArray(T arr[], K n)
{
	for (int i = 0; i < n; ++i)
		cout << arr[i] << " ";
	cout << "\n";
}

template <typename T, typename K>
int HeapSort(T arr[], K n)
{
	int result = 0;
	
	for (int i = n / 2 - 1; i >= 0; i--) 
		result += FixHeap(arr, n, i);
	
	for (int i = n - 1; i > 0; i--) 
	{
		swap(arr[0], arr[i]); 
		result++;
		result += FixHeap(arr, i, 0);
		
	}
	return result;
}


int main()
{
	cout << "-------------ineger-------------" << endl;

	int arrr[] = { 1, 2, 3, 4, 5, 6 };
	int k= sizeof(arrr) / sizeof(arrr[0]);

	printArray(arrr, k);
	int int_cout = HeapSort(arrr, k);

	cout << "Sorted array is \n";
	cout << int_cout << endl;
	printArray(arrr, k);
	

	cout << "-------------double-------------"<< endl;

	double arr[] = { 12.5, 11.9, 6.9, 5.3, 6, 7 };
	int n = sizeof(arr) / sizeof(arr[0]);

	printArray(arr, n);
	int dubb_cout = HeapSort(arr, n);

	cout << "Sorted array is \n";
	cout << dubb_cout << endl;
	printArray(arr, n);

	cout << "--------------string------------" << endl;

	string arr_2[] = {"rt", "a", "ss"};
	int m = sizeof(arr_2) / sizeof(arr_2[0]);

	printArray(arr_2, m);
	int str_cout = HeapSort(arr_2, m);

	cout << "Sorted array is \n";
	cout << str_cout << endl;
	printArray(arr_2, m);
}