
#include <iostream>
using namespace std;

int len(const char* s)
{
	int i = 0;
	while (s[i] != '\0')
		++i;
	return i;
}

int compare(const char* s, const char* t)
{
	return len(s) - len(t);
}

int main()
{
	char str[] = "Hello";
	cout << str << endl;
	cout << strlen(str) << ' ' << sizeof(str) << endl;

	char t[32];
	for (char* pd = t, *ps = str; *pd++ = *ps++;);

	char second[] = "12345";
	//char t[32];
	//string_copy(str, t);
	//int count;
	//count = compare(str, second);
	cout << t << endl;
}


