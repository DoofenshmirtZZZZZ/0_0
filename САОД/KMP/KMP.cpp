// KMP.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "PF.h"
#include <bitset>



typedef unsigned char byte;
int main()
{
	// Распознаваемый код вируса HLLP.Light.4859 (один из Trojan)		
	byte vCode[] = {0x88, 0x42, 0xE0, 0x46, 0xEB, 0x27, 0x00, 0xED, 0x3F, 0x8B, 0xCE, 0xE3, 0x12, 0x8D, 0x7E, 0xE0};

	char t[sizeof(vCode)*8 + 1] = { 0 };

	string a = "s";
	int mas[8] = { 0,0,0,0,0,0,0,0 };
	int d = (int)vCode[0];
	for (int i = 0; i < 8; i++)
		mas[7 - i] = (d >> i) & 0x01;

	std::cout << mas << endl;

	const int n = sizeof(vCode);

	char chars[n + 1];
	memcpy(chars, vCode, n);
	chars[n] = '\0';       
	std::cout << chars;
	
	
	

	

	cout << t << endl;
	
	
	// Вот здесь реализация задания

	return 0;
}

