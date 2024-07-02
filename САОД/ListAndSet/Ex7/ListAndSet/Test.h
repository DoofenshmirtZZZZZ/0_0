#include <iostream>
using std::string;
using std::cout;
using std::endl;


class Test {
public:

	int Val;

	Test(int valchek) {
		Val = valchek;
		cout << "Test_Constructor / Val = " << Val << endl;
	};

	~Test()
	{
		//cout << "Test_Destructor  / " << endl;
	};

	bool operator <(const Test & other) const
	{
		return this->Val < other.Val;
	};

	std::ostream& operator <<(std::ostream& s) {
		return s << this->Val << "\t";
	};

	bool operator () (const Test& _Left, const Test& _Right) const {

		return _Left < _Right;
	};
	bool operator ==(const Test& other) const {

		return this->Val == other.Val;

	};


};


