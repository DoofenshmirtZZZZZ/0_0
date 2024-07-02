#include <iostream>
#include "str.h"
void Test(Str s) {}

int main()
{
    Str s = "123";
    std::cout << s << std::endl;

    Test(s);
    std::cout << s << std::endl;

    Str t;
    t = s;
    std::cout << t << std::endl;

    s += "5371";
    std::cout << s << std::endl;

    std::cout << s + t << std::endl;

}
