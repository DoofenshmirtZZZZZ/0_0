
#include <iostream>
using namespace std;

int main()
{
	// -,*,/,%,|,&,^, <<, >> и любых других… 
	int x, y;
	int res;

	cout << "x = ? "; cin >> x; // Подсказка и ввод х
	cout << "y = ? "; cin >> y; // Подсказка и ввод y

	cout << x << " + " << y << " = " << x + y << endl;
	cout << x << " - " << y << " = " << x - y << endl;
	cout << x << " * " << y << " = " << x * y << endl;
	cout << x << " / " << y << " = " << x / y << endl;
	cout << x << " % " << y << " = " << x % y << endl;
	res = x | y;
	cout << x << " | " << y << " = " << res << endl;
	res = x & y;
	cout << x << " & " << y << " = " << res << endl;
	res = x ^ y;
	cout << x << " ^ " << y << " = " << res << endl;
	res = x << y;
	cout << x << " << " << y << " = " << res << endl;
	res = x >> y;
	cout << x << " >> " << y << " = " << res << endl;

}

