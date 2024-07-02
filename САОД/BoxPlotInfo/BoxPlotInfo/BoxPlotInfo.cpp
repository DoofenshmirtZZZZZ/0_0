#include <iostream>
#include <vector>
#include <algorithm>
#include <numeric>
#include <cmath>
#include <stdlib.h>
#include <tuple>
#include <stdexcept>
double max, min;

double foo(double x, double y) {	
	return x + pow(y, 2);
}


 std::tuple<double, double, double > boxInfo(std::vector<double> Vector, int numb_z)
{
	std::cout.precision(numb_z);
	sort(Vector.begin(), Vector.end());
	
	double median;
	if (Vector.size() % 2 != 0)
		median = Vector[Vector.size() / 2];
	else median = (Vector[Vector.size() / 2] + Vector[Vector.size() / 2 - 1]) / 2;
	
	double lq;
	if (Vector.size() % 2 != 0)
		lq = Vector[(Vector.size() / 2) / 2];
	else lq = (Vector[(Vector.size() / 2) / 2] + Vector[(Vector.size() / 2) / 2 + 1]) / 2;
	
	double uq;
	if (Vector.size() % 2 != 0)
		uq = Vector[(Vector.size() / 2) + (Vector[(Vector.size() / 2) / 2])];
	else uq = (Vector[(Vector.size() / 2) / 2] + Vector[(Vector.size() / 2) / 2 + 1]) / 2;
	
	double mean = std::accumulate(Vector.begin(), Vector.end(), 0.0);     
	mean /= Vector.size();														

	// мат ожид и дисперсия => сред квадр
	double mx = std::accumulate(Vector.begin(), Vector.end(), 0.0); // м х

	std::vector<double> v1(Vector);
	for (int i = 0; Vector.size() > i; i++) {

		v1[i] *= Vector[i];
	}
	
	mx /= Vector.size();
	mx = pow(mx, 2);

	double m_x2 = std::accumulate(v1.begin(), v1.end(), 0.0, foo);    // м где х в квадрате
	//m_x2 /= Vector.size();

	double d_x = m_x2 - mx;

	//Квадратичное
	double stddev = pow(d_x, 0.5);

	//Межквартильное
	double mq = uq - lq;


	//Верхняя и нижняя граница выброса / если менять коэф то рез более похожий
	max = uq + mq * 1.5;
	min = lq - mq * 1.5;
	

	std::cout << "min       " << std::scientific <<  min << std::endl;
	std::cout << "lq        " << lq << std::endl;
	std::cout << "median    " << median << std::endl;
	std::cout << "mean      " << mean << std::endl;
	std::cout << "stddev    " << stddev << std::endl;
	std::cout << "uq        " << uq << std::endl;
	std::cout << "max       " << max << std::endl;
	std::cout << "out       "; std::for_each(Vector.cbegin(), Vector.cend(), [](double x) {if ((x > max) || (x < min)) std::cout << x << " "; });
	

	return std::tuple<double, double, double >(median, mean, stddev);
}

int main()
{
	std::vector<double> x = { 0.0855298042e+00,1.4513241053e+00,1.3237277269e+00,1.0128350258e+00,1.4122089148e+00,6.5826654434e-01,2.0795986652e+00,1.0230206251e+00,1.4231411219e+00,1.1091691256e+00,1.7714337111e+00,1.3986129761e+00,1.0640757084e+00,1.4216910601e+00,1.2402026653e+00 };
	auto result = boxInfo(x, 2);
	std::cout <<  std::endl;
	std::cout <<  std::endl;

	std::cout << std::get<0>(result) << ' ' << std::get<1>(result) << ' ' << std::get<2>(result) << std::endl;
}

