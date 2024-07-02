#include <iostream>
using std::string;
using std::cout;
using std::endl;


class Test {
public:

	int val;

	Test() {
		val = 0;
		cout << "Constructor / "  << endl;
	};

	~Test()
	{
		// cout << "Destructor  / " << endl;
	};
};