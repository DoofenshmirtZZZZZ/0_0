#include "stdafx.h"
#include "LZW.h"

#define KEY_SIZE 16
const int TBL_SIZE = (1 << KEY_SIZE) - 1; // ������������ �����, ������� ���������� � KEY_SIZE �����

/// <summary>
/// ���� ��� ����������� ������� ������ � �������. 
/// ������� ������������ ����� ��������� �������� ������� � ������� ��������.
/// </summary>
/// <param name="iPrefixCode">������ ��������� �����</param>
/// <param name="cCharacter">������ ��������</param>
/// <param name="iNumberOfCodes">���������� ����� � �������</param>
/// <param name="iSearchingPrefixCode">��� ���������� �������</param>
/// <param name="cSearchingCharacter">����������� ������</param>
/// <returns>��� � ������ ������ � -1, ���� �� ������</returns>
int SearchInStringTable(int *iPrefixCode, unsigned char *cCharacter, int iNumberOfCodes, int iSearchingPrefixCode, unsigned char cSearchingCharacter)
{
	if (iSearchingPrefixCode == -1)
	{
		return cSearchingCharacter;
	}
	else
	{
		for (int i = iSearchingPrefixCode + 1; i < iNumberOfCodes; i++){
			if ((iPrefixCode[i] == iSearchingPrefixCode) && (cCharacter[i] == cSearchingCharacter)) return i;
		}
	}
	return -1;
}

/// <summary>
/// ������� ��� �������� KEY_SIZE � �������� �����
/// ��� �� ������ ���� ������ ����� (��������, ������ 10-12-14 ���).
/// ������� �������� ������ ����� �� �������� ����������� ���� � ����� �������� ���� � ������� � �����.
/// </summary>
/// <param name="os">�������� �����</param>
/// <param name="iCode">���, ������� ����� �������� � �����</param>
/// <returns>0 ��� ������, -1 � ������ ������</returns>
int OutputCode(ofstream &os, int iCode)
{
	static unsigned char cBuffer;		// ��� �������� �������� ����������� ����
	static int iNumberOfBitsInBuffer;	// ��� �������� ����� ������� � �����
	int i2_in_power_NOBI = 1;
	
	// ����� � ����� ��������� ��� (������� �����)
	if (iCode == -1) {
		if (iNumberOfBitsInBuffer != 0) os.put(cBuffer);
		return 0;
	}

	// ���������� �����������
	if (iCode >= 0) {
		i2_in_power_NOBI <<= iNumberOfBitsInBuffer;
		for (int i = 0; i < KEY_SIZE; i++)
		{
			///  �������������� �����!
			// �������� � ����� ���� �������� ����
			cBuffer += i2_in_power_NOBI*(iCode % 2);
			iCode /= 2;
			i2_in_power_NOBI *= 2;
			iNumberOfBitsInBuffer++;
			// ���� �������� ����, �� ����� ��� � �������� �����, ���������� ����� � �������� ����������� ��������� ����
			if (iNumberOfBitsInBuffer >= 8){
				os.put(cBuffer);
				cBuffer = (unsigned char)0;
				iNumberOfBitsInBuffer = 0;
				i2_in_power_NOBI = 1;
			}
		}
		return 0;
	}
	return -1;
}






/// <summary>
/// �������������� ������� ����� ������� ������ ����� ���������� ����� 1 (�������)
/// </summary>
/// <param name="iaPrefixCode">������ ����� ���������� �������</param>
/// <param name="caCharacter">������ ��������</param>
/// <returns>������� ���������� ����� � �������</returns>
int InitializeStringTable(int *iaPrefixCode, unsigned char *caCharacter)
{
	if (iaPrefixCode[0] != -1)
		for (int i = 0; i < 256; i++){
			iaPrefixCode[i] = -1;	// ���������� ������� ���. ��� ������ ���� � �������!
			caCharacter[i] = (unsigned char)i;
		}
	return 256;
}

/// <summary>
/// ��������� ���������� �������� ������ � �������� 
/// </summary>
/// <param name="is">������� �����</param>
/// <param name="os">�������� �����</param>
/// <returns>0 � ������ ������ � -1 ��� ������</returns>
int CompressFile(ifstream &is, ofstream &os)
{
	// ���������� ������� ��� �����������
	int iPrefixCode[TBL_SIZE]{0};
	unsigned char cCharacter[TBL_SIZE];

	unsigned char cCurrentCharacter;
	int iReturnCode;

	// �������������� ����� �������
	int iCurrentPrefixCode = -1;	// ��� ������� ������� � ������������������
	int iNumberOfCodes = InitializeStringTable(iPrefixCode, cCharacter);

	is.get((char&)cCurrentCharacter);
	while (!is.eof()){
		// ��� ���� � �������
		if ((iReturnCode = SearchInStringTable(iPrefixCode, cCharacter, iNumberOfCodes, iCurrentPrefixCode, cCurrentCharacter)) >= 0){
			iCurrentPrefixCode = iReturnCode;
		}
		else {
			// ����� ��������� ��� � ������� � ����������� ���������� �����.
			iPrefixCode[iNumberOfCodes] = iCurrentPrefixCode;
			cCharacter[iNumberOfCodes] = cCurrentCharacter;
			iNumberOfCodes++;
			// ������� ���������� ��� � �������� �����.
			// ����� �������, � ������ ������ ����, ������� ��� ���� � �������!
			if (OutputCode(os, iCurrentPrefixCode)<0) {
				return -1;
			}
			// �������� ������� ����� ������� � ���������� ������� ����������� � ������� �������.
			iCurrentPrefixCode = (unsigned int)cCurrentCharacter;
		}

		if (iNumberOfCodes >= TBL_SIZE){
			// ���� ������� ���������, �� �� ����� ��������������������.
			if (OutputCode(os, iCurrentPrefixCode)<0) {
				return -1;
			}
			// ������� ������� �������� � ����� �������
			if (OutputCode(os, TBL_SIZE)<0) { // code for overflowing of string table = (TABLE_SIZE-1)+1;
				return -1;
			}

			// �������� ����������� ������� ����� �������!
			iNumberOfCodes = InitializeStringTable(iPrefixCode, cCharacter);
			iCurrentPrefixCode = -1;
		}
		is.get((char&)cCurrentCharacter);
	}
	// ���������� ������� ���
	if (OutputCode(os, iCurrentPrefixCode)<0) {
		return -1;
	}
	// ���������� ��������� ���� ����������� ����
	if (OutputCode(os, -1)<0) {
		return -1;
	}
	return 0;
}



/// <summary>
/// ��� � ����� �������������� ������� ������
/// ������� �������� ������ ������ ���� �������
/// </summary>
/// <param name="iPrefixCode">������ ���������</param>
/// <param name="cCharacter">������ �������� (�������)</param>
/// <param name="iCurrentCode">������� ���</param>
/// <returns>1-��� ������ �������, ��������������� ����</returns>
unsigned char GetFirstCharacterForCode(int *iPrefixCode, unsigned char *cCharacter, int iCurrentCode)
{
	//��������� �� ������� ���������, ���� �� ����� -1.
	while (iPrefixCode[iCurrentCode] >= 0){
		iCurrentCode = iPrefixCode[iCurrentCode];
	}
	//������ � ���� ������� � ������������� ������� ������� �������.
	return (cCharacter[iCurrentCode]);
}

/// <summary>
/// ������� ������������������ ������ ��� ������� ���� � �����.
/// ������� ������������ ��������� ������ � ����� ���������� �������
/// </summary>
/// <param name="iaPrefixCode">������ ����� ���������� �������</param>
/// <param name="caCharacter">������ ��������� ������ �������</param>
/// <param name="os">�������� �����</param>
/// <param name="iCurrentCode">��� ������������������</param>
/// <returns>0 � ������ ������ � -1 � ������ ������</returns>
int OutputStringForCode(int *iPrefixCode, unsigned char *cCharacter, ofstream &os, int iCurrentCode)
{
	static string sOutputString;
	if (iCurrentCode >= 0){
		int iCode = iCurrentCode;
		int iLengthOfString = 0;
		while (iPrefixCode[iCode] >= 0){
			iCode = iPrefixCode[iCode];
			iLengthOfString++;
		}
		sOutputString.resize(iLengthOfString + 1);
		iCode = iCurrentCode;
		for (int i = iLengthOfString; i >= 0; i--){
			sOutputString[i] = cCharacter[iCode];
			iCode = iPrefixCode[iCode];
		}
		os.write((char*)sOutputString.c_str(), iLengthOfString + 1);
		return 0;
	}
	else return -1;
}

/// <summary>
/// ������ ��������� ��� ������������������ �� ������
/// �������� �������� ��� OutputCode.
/// </summary>
/// <param name="is">������� �����</param>
/// <returns>���</returns>
int GetNextCodeFromFile(ifstream &is)
{
	static unsigned char cBuffer;
	static int iNumberOfBitsInBuffer = 0;

	int i2_in_power_i = 1;
	int iCode = 0;
	int i = 0;
	for (int i = 0; i<KEY_SIZE; i++){
		if (iNumberOfBitsInBuffer == 0){
			is.get((char&)cBuffer);
			if (is.eof())
				return -1;
			iNumberOfBitsInBuffer = 8;
		}
		iCode += (cBuffer % 2)*i2_in_power_i;
		cBuffer /= 2;
		iNumberOfBitsInBuffer--;
		i2_in_power_i *= 2;
	}
	return iCode;
}

/// <summary>
/// ��������� ������������ �������� ������ lzw � ��������
/// </summary>
/// <param name="is">������� �����</param>
/// <param name="os">�������� �����</param>
/// <returns>0 ��� ������, -1 � ������ ������</returns>
int DecompressFile(ifstream &is, ofstream &os)
{
	int iPrefixCode[TBL_SIZE]{0};
	unsigned char cCharacter[TBL_SIZE];
	
	int iNumberOfCodes = InitializeStringTable(iPrefixCode, cCharacter);
	int iCurrentCode = GetNextCodeFromFile(is);
	if (OutputStringForCode(iPrefixCode, cCharacter, os, iCurrentCode)<0) {
		return -1;
	}

	int iOldCode = iCurrentCode;

	unsigned char cCurrentCharacter;
	while ((iCurrentCode = GetNextCodeFromFile(is)) >= 0){
		// ��� ����������������� �������
		if (iCurrentCode == TBL_SIZE){
			iNumberOfCodes = InitializeStringTable(iPrefixCode, cCharacter);
			iCurrentCode = GetNextCodeFromFile(is);
			if (iCurrentCode<0) break;
			if (OutputStringForCode(iPrefixCode, cCharacter, os, iCurrentCode)<0) {
				return -1;
			}
			iOldCode = iCurrentCode;
		}
		else {
			// ���� ��� ��� ���� � �������, ��������� ��� ���� ������������������
			if (iCurrentCode < iNumberOfCodes){
				if (OutputStringForCode(iPrefixCode, cCharacter, os, iCurrentCode)<0) {
					return -1;
				}
				// ��������� ��� ��� ������� �� ������� ����� ������� �������� ���� 
				// � ����������� ���� �� �������� ������ � �������.
				// ��� ��������������� ������� � ������� �������� ������������ ��� ���������� 
				cCurrentCharacter = GetFirstCharacterForCode(iPrefixCode, cCharacter, iCurrentCode);
				iPrefixCode[iNumberOfCodes] = iOldCode;
				cCharacter[iNumberOfCodes] = cCurrentCharacter;
			}
			// ���� ���� ���, �� ������� ������� ��� �� ����������� ���� � ��� ������� �������
			// ������ � ���.
			else {
				// ��������� ��� ��� ������� �� ������� ����� ������� ����������� ���� 
				// � ����������� ���� �� �������� ������ � �������.
				// ��� ��������������� ������� � ������� �������� ������������ ��� ���������� 
				cCurrentCharacter = GetFirstCharacterForCode(iPrefixCode, cCharacter, iOldCode);
				iPrefixCode[iNumberOfCodes] = iOldCode;
				cCharacter[iNumberOfCodes] = cCurrentCharacter;
				// � ����� ������� ������� ��� ���������� ������������ ����.
				if (OutputStringForCode(iPrefixCode, cCharacter, os, iNumberOfCodes)<0) {
					return -1;
				}
			}
		
			iNumberOfCodes++;
			iOldCode = iCurrentCode;
		}
	}
	return 0;
}
