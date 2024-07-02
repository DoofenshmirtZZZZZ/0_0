
#include <iostream>
#include "Test.h"
#include <memory>



//std::shared_ptr<Test> pt(new Test);
std::weak_ptr<Test> wp;



int main()
{
	

	{
		auto sp = std::shared_ptr<Test>{ new Test };

		cout << (bool)sp << endl; 			// 1
		cout << sp.use_count() << endl; 		// 1

		cout << "------------------" << endl;

		wp = sp;

		cout << wp.use_count() << endl;		// 1
		auto p = wp.lock();

		if (p) {
			cout << "object is alive" << endl;
			cout << p.use_count() << endl;
		}
		else
		{
			cout << "no owing object" << endl;
		}
		
	}

	auto p = wp.lock();

	if (p) {
		cout << "object is alive" << endl;
		cout << p.use_count() << endl;
	}
	else
	{
		cout << "no owing object" << endl;
	}

	
}

