// Main.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "LZW.h"
#include <ctime>


int main(int argc, char* argv[])
{
	string sFInName, sFOutName;
	ofstream os;
	ifstream is;
	char cRead;
	cout<<"Enter the first letter of the operation (c - compressing; d - decompressing):";
	cin >> cRead; cin.get();

	if (cRead != 'c' && cRead != 'd'){
		printf("Error: can't recognize this operation!..\n");
		return -1;
	}

	cout << "Enter name of Input File:" << endl;
	getline(cin, sFInName);
	cout<<"Enter name of Output File:"<<endl;
	getline(cin, sFOutName);


	// Открываем потоки для ввода и вывода
	is.open(sFInName, ios::binary);
	os.open(sFOutName, ios::binary);

	if (!is.is_open()){
		cout << "Error: can't open file with name " << sFInName << "!.." << endl;
		return -1;
	}
	if (!os.is_open()){
		cout << "Error: can't open file with name " << sFOutName<<"!.."<<endl;
		return -1;
	}
	if (cRead == 'c')
	{
		cout << time(0) << endl;
		if (CompressFile(is, os) >= 0){
			cout<<"Compressing finished successfully!"<<endl;
		}
		else {
			cout<<"Compressing finished UNsuccessfully!"<<endl;
		}
		cout << time(0) << endl;
	}
	
	else if (cRead == 'd')
	{
		if (DecompressFile(is, os) >= 0){
			cout << "Decompressing finished successfully!" << endl;
		}
		else {
			cout << "Decompressing finished UNsuccessfully!" << endl;
		}
	}
	return 0;
}

